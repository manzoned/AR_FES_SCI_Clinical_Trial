using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
    public TargetPosturePanel targetPosturePanel;
    public UDPSender UDPSender;
    public TimerTextBox TimerTextBox;
    public ProfileManager ProfileManager;
    public HandTracking1 HandTracking;

    [Header("UI Text References (Reused for both modes)")]
    public TextMeshPro TitleText;
    public TextMeshPro InstructionsText;
    public TextMeshPro LateralRepsCount;
    public TextMeshPro PinchRepsCount;
    public TextMeshPro PowerRepsCount;

    public TextMeshPro LateralStimCount;
    public TextMeshPro PinchStimCount;
    public TextMeshPro PowerStimCount;

    // --- STATE ---
    private bool showingHistory = false;

    void Start()
    {
        RefreshDisplay();
    }

    public void ScreenOn()
    {
        if(ProfileManager.ProfileSet == true)
        {
            if(HandTracking.HandUsed != 0)
            {
                if (UDPSender.StopStimState == true)
                {
                    gameObject.SetActive(true);
                    targetPosturePanel.gameObject.SetActive(false);
                    showingHistory = false; // Default to current session when turning on
                    RefreshDisplay();
                }

                if (UDPSender.StopStimState == false)
                {
                    UDPSender.StopStim();
                    TimerTextBox.StopStim();
                    gameObject.SetActive(true);
                    targetPosturePanel.gameObject.SetActive(false);
                    showingHistory = false; // Default to current session when turning on
                    RefreshDisplay();
                }
            }

        }

    }

    public void ScreenOff()
    {
        gameObject.SetActive(false);
    }

    // --- EXPLICIT VOICE COMMAND FUNCTIONS ---

    // Map to voice commands: "Current" or "Stats"
    public void ShowCurrentStats()
    {
        if (showingHistory == true)
        {
            showingHistory = false;
            RefreshDisplay();
        }
    }

    // Map to voice command: "History"
    public void ShowHistoricalStats()
    {
        if (showingHistory == false)
        {
            showingHistory = true;
            RefreshDisplay();
        }
    }

    // Tells the panel to redraw whatever mode it is currently in
    private void RefreshDisplay()
    {
        if (showingHistory)
        {
            UpdateHistoricalStats();
        }
        else
        {
            UpdateCurrentSessionStats();
        }
    }

    // --------------------------------------------------------
    // 1. CURRENT SESSION
    // --------------------------------------------------------
    public void UpdateCurrentSessionStats()
    {
        if (DataManager.Instance == null || DataManager.Instance.currentSession == null) return;

        Session current = DataManager.Instance.currentSession;

        int latReps = 0; float latStimSum = 0f;
        int pinReps = 0; float pinStimSum = 0f;
        int powReps = 0; float powStimSum = 0f;

        foreach (Exercise ex in current.exercisesPerformed)
        {
            if (ex.exerciseName == "Lateral")
            {
                latReps += ex.reps.Count;
                foreach (Repetition rep in ex.reps) latStimSum += (rep.max_finger_stim + rep.max_thumb_stim) / 2f;
            }
            else if (ex.exerciseName == "Pinch")
            {
                pinReps += ex.reps.Count;
                foreach (Repetition rep in ex.reps) pinStimSum += (rep.max_finger_stim + rep.max_thumb_stim) / 2f;
            }
            else if (ex.exerciseName == "Power")
            {
                powReps += ex.reps.Count;
                foreach (Repetition rep in ex.reps) powStimSum += (rep.max_finger_stim + rep.max_thumb_stim) / 2f;
            }
        }

        float latAvg = latReps > 0 ? (latStimSum / latReps) : 0f;
        float pinAvg = pinReps > 0 ? (pinStimSum / pinReps) : 0f;
        float powAvg = powReps > 0 ? (powStimSum / powReps) : 0f;

        // ONLY update the UI text if we are actually looking at the Current view
        if (!showingHistory)
        {
            if (TitleText != null) TitleText.text = "Exercise Statistics (Current Session)";
            if (InstructionsText != null) InstructionsText.text = "To see averages across previous sessions say: \"History\" \n" +
                    "To exit the screen say \"Home\" or \"Reset\"";

            if (LateralRepsCount != null) LateralRepsCount.text = latReps.ToString();
            if (PinchRepsCount != null) PinchRepsCount.text = pinReps.ToString();
            if (PowerRepsCount != null) PowerRepsCount.text = powReps.ToString();

            if (LateralStimCount != null) LateralStimCount.text = latAvg.ToString("F2");
            if (PinchStimCount != null) PinchStimCount.text = pinAvg.ToString("F2");
            if (PowerStimCount != null) PowerStimCount.text = powAvg.ToString("F2");
        }
    }

    // --------------------------------------------------------
    // 2. HISTORICAL SESSIONS
    // --------------------------------------------------------
    public void UpdateHistoricalStats()
    {
        if (ProfileManager.Instance == null || ProfileManager.Instance.activeProfile == null) return;

        UserProfile user = ProfileManager.Instance.activeProfile;
        int currentSessionID = DataManager.Instance?.currentSession?.sessionID ?? -1;

        int latTotalReps = 0; float latStimSum = 0f;
        int pinTotalReps = 0; float pinStimSum = 0f;
        int powTotalReps = 0; float powStimSum = 0f;

        int pastSessionCount = 0;

        foreach (Session session in user.sessionHistory)
        {
            if (session.sessionID == currentSessionID) continue;

            pastSessionCount++;

            foreach (Exercise ex in session.exercisesPerformed)
            {
                if (ex.exerciseName == "Lateral")
                {
                    latTotalReps += ex.reps.Count;
                    foreach (Repetition rep in ex.reps) latStimSum += (rep.max_finger_stim + rep.max_thumb_stim) / 2f;
                }
                else if (ex.exerciseName == "Pinch")
                {
                    pinTotalReps += ex.reps.Count;
                    foreach (Repetition rep in ex.reps) pinStimSum += (rep.max_finger_stim + rep.max_thumb_stim) / 2f;
                }
                else if (ex.exerciseName == "Power")
                {
                    powTotalReps += ex.reps.Count;
                    foreach (Repetition rep in ex.reps) powStimSum += (rep.max_finger_stim + rep.max_thumb_stim) / 2f;
                }
            }
        }

        float latAvg = latTotalReps > 0 ? (latStimSum / latTotalReps) : 0f;
        float pinAvg = pinTotalReps > 0 ? (pinStimSum / pinTotalReps) : 0f;
        float powAvg = powTotalReps > 0 ? (powStimSum / powTotalReps) : 0f;

        int avgLatReps = pastSessionCount > 0 ? Mathf.RoundToInt((float)latTotalReps / pastSessionCount) : 0;
        int avgPinReps = pastSessionCount > 0 ? Mathf.RoundToInt((float)pinTotalReps / pastSessionCount) : 0;
        int avgPowReps = pastSessionCount > 0 ? Mathf.RoundToInt((float)powTotalReps / pastSessionCount) : 0;

        // ONLY update the UI text if we are actually looking at the History view
        if (showingHistory)
        {
            if (TitleText != null) TitleText.text = "Exercise Statistics (Historical Average)";
            if (InstructionsText != null) InstructionsText.text = "To see current session say: \"Current\" or \"Stats\"  \n" +
                    "To exit the screen say \"Home\" or \"Reset\"";

            if (LateralRepsCount != null) LateralRepsCount.text = avgLatReps.ToString();
            if (PinchRepsCount != null) PinchRepsCount.text = avgPinReps.ToString();
            if (PowerRepsCount != null) PowerRepsCount.text = avgPowReps.ToString();

            if (LateralStimCount != null) LateralStimCount.text = latAvg.ToString("F2");
            if (PinchStimCount != null) PinchStimCount.text = pinAvg.ToString("F2");
            if (PowerStimCount != null) PowerStimCount.text = powAvg.ToString("F2");
        }
    }
}