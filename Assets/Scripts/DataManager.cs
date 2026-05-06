using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.Rendering;
using System.Net.NetworkInformation;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public UDPSender UDPSender;
    public int sessionNum;
    public string exerciseName;

    [Header("Data Source Configuration")]
    public TargetPosturePanel TargetPosturePanel;

    [Header("Current Session State")]
    public Session currentSession;
    public Exercise activeExercise; // The container we are currently filling

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // --- 1. START SESSION (Triggered by Profile Confirmation) ---
    public void StartNewSession()
    {
        UserProfile user = ProfileManager.Instance.activeProfile;
        if (user == null) return;

        // Calculate Session ID (Iterative)
        int newSessionID = user.totalSessionsRun + 1;
        sessionNum = newSessionID;

        // Create and Store Session
        currentSession = new Session(newSessionID);
        user.sessionHistory.Add(currentSession);
        user.totalSessionsRun++;

        Debug.Log($"Session {newSessionID} started for {user.userName}");
        ProfileManager.Instance.SaveCurrentProfile();
    }

    // --- 2. THE RECORDING FUNCTION ---
    public void RecordCurrentRepData()
    {
        if (currentSession == null)
        {
            StartNewSession(); // Auto-start if they forgot
        }

        // --- A. DETERMINE EXERCISE NAME ---
        exerciseName = "Unknown";
        if (TargetPosturePanel.objectType == "(Credit Card)") { exerciseName = "Lateral"; }
        else if (TargetPosturePanel.objectType == "(Marble)") { exerciseName = "Pinch"; }
        else if (TargetPosturePanel.objectType == "(Block)") { exerciseName = "Power"; }

        // --- B. FIND OR CREATE THE EXERCISE CONTAINER ---
        // Search the current session to see if we already started doing this exercise earlier today
        activeExercise = currentSession.exercisesPerformed.Find(ex => ex.exerciseName == exerciseName);

        // If we haven't done this exercise yet in this session, create a new container for it
        if (activeExercise == null)
        {
            activeExercise = new Exercise(exerciseName);
            currentSession.exercisesPerformed.Add(activeExercise);
            Debug.Log($"Created new recording container for: {exerciseName}");
        }

        // --- C. CREATE AND SAVE REP ---
        Repetition newRep = new Repetition();

        // Auto-calculate which rep number this is based on how many are already in the list
        // Note: You may need to add 'public int repNumber;' to your Repetition class if you haven't!
        newRep.repNumber = activeExercise.reps.Count + 1; 

        newRep.max_finger_stim = UDPSender.fingerTempMax;
        newRep.max_thumb_stim = UDPSender.thumbTempMax;
        newRep.timestamp = DateTime.Now.ToString("HH:mm:ss");

        activeExercise.reps.Add(newRep);

        Debug.Log($"PULLED DATA -> Exercise: {exerciseName} | Finger Max: {newRep.max_finger_stim} | Thumb Max: {newRep.max_thumb_stim}");

        // --- D. SAVE TO FILE ---
        ProfileManager.Instance.SaveCurrentProfile();
    }
}