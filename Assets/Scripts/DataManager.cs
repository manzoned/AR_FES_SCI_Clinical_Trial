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
    // DRAG YOUR EXISTING SCRIPT HERE IN THE INSPECTOR
    [Tooltip("Drag the object with your ExerciseController script here")]
    // public ExerciseController exerciseSource;
    public TargetPosturePanel TargetPosturePanel;

    [Header("Current Session State")]
    public Session currentSession;
    public Exercise activeExercise; // The container we are currently filling

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // Safety Check
        //if (exerciseSource == null)
        //{
        //    Debug.LogError("DataManager is missing a reference to your ExerciseController! Please drag it in.");
        //}
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
    // Call this ONLY when a rep is finished.
    // It will automatically go fetch the variables from your other script.
    public void RecordCurrentRepData()
    {
        if (currentSession == null)
        {
            StartNewSession(); // Auto-start if they forgot
        }

        // --- A. PULL DATA FROM YOUR SCRIPT ---
        // REPLACE these variable names with the REAL names from your script!
        //string exerciseName = exerciseSource.currentExerciseName;
        //float score = exerciseSource.lastRepScore;
        //float duration = exerciseSource.lastRepDuration;

        if (TargetPosturePanel.objectType == "(Marble)") { exerciseName = "Pinch"; }
        if (TargetPosturePanel.objectType == "(Credit Card)") { exerciseName = "Lateral"; }
        if (TargetPosturePanel.objectType == "(Block)") { exerciseName = "Power"; }

        //string exerciseName = TargetPosturePanel.objectType;

        // --- B. MANAGE THE EXERCISE CONTAINER ---
        // If we switched exercises (e.g. from "Squat" to "Lunge"), make a new container
        if (activeExercise == null || activeExercise.exerciseName != exerciseName)
        {
            activeExercise = new Exercise(exerciseName);
            currentSession.exercisesPerformed.Add(activeExercise);
            Debug.Log($"Switched recording to new exercise: {exerciseName}");
        }

        // --- C. CREATE AND SAVE REP ---
        Repetition newRep = new Repetition();
        //newRep.score = score;
        //newRep.duration = duration;
        newRep.max_finger_stim = UDPSender.fingerTempMax;
        newRep.max_thumb_stim = UDPSender.thumbTempMax;
        newRep.timestamp = DateTime.Now.ToString("HH:mm:ss");

        activeExercise.reps.Add(newRep);

        Debug.Log($"PULLED DATA -> Exercise: {exerciseName}");

        // --- D. SAVE TO FILE ---
        ProfileManager.Instance.SaveCurrentProfile();

    }
}