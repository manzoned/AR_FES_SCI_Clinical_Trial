using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

public class SessionGraphManager : MonoBehaviour
{
    [Header("UI References - Reps Graph")]
    public LineChart repsChart;           // Your original LineChart
    public GameObject repsCanvas;         // Your original Canvas

    [Header("UI References - Avg Stim Graph")]
    public LineChart avgStimChart;        // Your duplicated LineChart
    public GameObject avgStimCanvas;      // Your duplicated Canvas

    [Header("Shared UI References")]
    public GameObject textStatsContainer; // The empty object holding your yellow boxes
    public TMPro.TextMeshPro titleText;   // To update the title

    // --------------------------------------------------------
    // COMMAND 1: SHOW REPETITIONS (e.g., "Show Progress")
    // --------------------------------------------------------
    public void ShowRepsGraph()
    {
        if (ProfileManager.Instance == null || ProfileManager.Instance.activeProfile == null) return;

        // Toggle UI Visibility (Hide stats and avg stim, show reps graph)
        textStatsContainer.SetActive(false);
        avgStimCanvas.SetActive(false);
        repsCanvas.SetActive(true);

        if (titleText != null) titleText.text = "Exercise Statistics (Repetitions Over Time)";

        UserProfile user = ProfileManager.Instance.activeProfile;
        repsChart.ClearData();
        int sessionCounter = 1;

        foreach (Session session in user.sessionHistory)
        {
            repsChart.AddXAxisData(sessionCounter.ToString());

            int latReps = 0; int pinReps = 0; int powReps = 0;

            foreach (Exercise ex in session.exercisesPerformed)
            {
                if (ex.exerciseName == "Lateral") latReps += ex.reps.Count;
                else if (ex.exerciseName == "Pinch") pinReps += ex.reps.Count;
                else if (ex.exerciseName == "Power") powReps += ex.reps.Count;
            }

            repsChart.AddData(0, latReps);
            repsChart.AddData(1, pinReps);
            repsChart.AddData(2, powReps);

            sessionCounter++;
        }
        Debug.Log($"Reps Graph drawn successfully with {sessionCounter - 1} sessions.");
    }

    // --------------------------------------------------------
    // COMMAND 2: SHOW AVERAGE STIM (e.g., "Show Average Stim")
    // --------------------------------------------------------
    public void ShowAvgStimGraph()
    {
        if (ProfileManager.Instance == null || ProfileManager.Instance.activeProfile == null) return;

        // Toggle UI Visibility (Hide stats and reps, show avg stim graph)
        textStatsContainer.SetActive(false);
        repsCanvas.SetActive(false);
        avgStimCanvas.SetActive(true);

        // Optional: Update title to reflect it's a percentage/normalized
        if (titleText != null) titleText.text = "Exercise Statistics (Average Stimulation %)";

        UserProfile user = ProfileManager.Instance.activeProfile;
        avgStimChart.ClearData();

        // --- NEW: Calculate the baseline minimums for this specific user ---
        // We use the raw values from their JSON profile (e.g., min / max)
        // The ternary operator (? :) prevents dividing by zero just in case max is 0
        float baselineFingerMin = user.finger_max > 0 ? (user.finger_min / user.finger_max) : 0f;
        float baselineThumbMin = user.thumb_max > 0 ? (user.thumb_min / user.thumb_max) : 0f;

        int sessionCounter = 1;

        foreach (Session session in user.sessionHistory)
        {
            avgStimChart.AddXAxisData(sessionCounter.ToString());

            float latSum = 0; int latCount = 0;
            float pinSum = 0; int pinCount = 0;
            float powSum = 0; int powCount = 0;

            foreach (Exercise ex in session.exercisesPerformed)
            {
                foreach (Repetition rep in ex.reps)
                {
                    // --- NEW: Normalize the values between 0 and 1 ---
                    // Mathf.InverseLerp takes (MinLimit, MaxLimit, CurrentValue)
                    // If the rep value is at the baseline min, it becomes 0. If it's at 1f, it stays 1.
                    float normFinger = Mathf.InverseLerp(baselineFingerMin, 1f, rep.max_finger_stim);
                    float normThumb = Mathf.InverseLerp(baselineThumbMin, 1f, rep.max_thumb_stim);

                    // Average the NORMALIZED values together for this rep
                    float repAvgStim = (normFinger + normThumb) / 2f;

                    if (ex.exerciseName == "Lateral") { latSum += repAvgStim; latCount++; }
                    else if (ex.exerciseName == "Pinch") { pinSum += repAvgStim; pinCount++; }
                    else if (ex.exerciseName == "Power") { powSum += repAvgStim; powCount++; }
                }
            }

            // Calculate the final averages (prevent dividing by zero if they skipped an exercise)
            float latAvg = latCount > 0 ? (latSum / latCount) : 0;
            float pinAvg = pinCount > 0 ? (pinSum / pinCount) : 0;
            float powAvg = powCount > 0 ? (powSum / powCount) : 0;

            // --- CHANGED: Multiply by 100 to make it a whole percentage for the graph ---
            avgStimChart.AddData(0, latAvg * 100f);
            avgStimChart.AddData(1, pinAvg * 100f);
            avgStimChart.AddData(2, powAvg * 100f);

            sessionCounter++;
        }
        Debug.Log($"Avg Stim Graph drawn successfully with normalized data for {sessionCounter - 1} sessions.");
    }
}