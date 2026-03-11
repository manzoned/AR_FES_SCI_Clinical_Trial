using System.Collections.Generic;
using System;

// 1. A single repetition (The smallest unit of data)
[System.Serializable]
public class Repetition
{
    public float max_finger_stim;      // e.g., 0.85 (85% accuracy)
    public float max_thumb_stim;
    //public float duration;   // e.g., 3.5 seconds
    public string timestamp; // The time it finished (e.g., "14:30:05")
}

// 2. An Exercise (A collection of reps, e.g., "Bicep Curl")
[System.Serializable]
public class Exercise
{
    public string exerciseName;
    public List<Repetition> reps;

    // Constructor to initialize the list
    public Exercise(string name)
    {
        exerciseName = name;
        reps = new List<Repetition>();
    }
}

// 3. A Session (One full workout/login)
[System.Serializable]
public class Session
{
    public int sessionID;        // 1, 2, 3...
    public string startTime;     // When the session started
    public List<Exercise> exercisesPerformed;

    public Session(int id)
    {
        sessionID = id;
        startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        exercisesPerformed = new List<Exercise>();
    }
}

// 4. The User Profile (The main file that gets saved)
[System.Serializable]
public class UserProfile
{
    public string userName;      // "Participant 1"
    public string userID;        // Unique ID (optional)
    public int totalSessionsRun; // Counter for session IDs
    public List<Session> sessionHistory;

    // attach stimulation amplitudes to each profile
    public float finger_min;
    public float finger_max;
    public float thumb_min;
    public float thumb_max;
    public float open_max;

    public UserProfile(string name, string id)
    {
        userName = name;
        userID = id;
        totalSessionsRun = 0;
        sessionHistory = new List<Session>();

        // Initialize with safe defaults (0 means "off")
        finger_min = 0f;
        finger_max = 0f;
        thumb_min = 0f;
        thumb_max = 0f;
        open_max = 0f;
    }
}