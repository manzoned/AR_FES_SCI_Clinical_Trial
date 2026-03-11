using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class ProfileManager : MonoBehaviour
{
    public ProfilePrompt ProfilePrompt;
    public TextMeshPro Profile_PromptOutput;
    public HandUsePrompt HandUsePrompt;
    public DataManager DataManager;
    public string tempProfile;
    public static ProfileManager Instance; // Singleton pattern for easy access
    public UserProfile UserProfile;
    public UDPSender UDPSender;
    public bool ProfileSet;


    [Header("Current Status")]
    public UserProfile activeProfile; // Who is currently logged in?

    [Header("Configuration")]
    // List of names you want to pre-create
    public string[] preMadeUserNames = { "Participant 1", "Participant 2", "Participant 3", "Participant 4", "Participant 5", "Participant 6", "Participant 7","Participant 99" };

    private void Awake()
    {
        // Singleton Setup
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // Keep this alive across scenes
    }

    private void Start()
    {
        // On app start, ensure our pre-made profiles exist on the device
        InitializeProfiles();

        // prompt the participant to choose their profile
        Profile_PromptOutput.text = "What is your participant ID?";
        Profile_PromptOutput.color = new Color(255, 255, 255, 1f); 
        ProfilePrompt.gameObject.SetActive(true);
        ProfileSet = false;
    }



    // 1. Check if profiles exist. If not, create them.
    public void InitializeProfiles()
    {
        foreach (string name in preMadeUserNames)
        {
            // Create a filename based on the name (remove spaces to be safe)
            string safeName = name.Replace(" ", "_");
            string path = Path.Combine(Application.persistentDataPath, safeName + ".json");

            if (!File.Exists(path))
            {
                // Create the new empty profile
                UserProfile newProfile = new UserProfile(name, System.Guid.NewGuid().ToString());

                // Save it immediately
                string json = JsonUtility.ToJson(newProfile, true);
                File.WriteAllText(path, json);

                Debug.Log($"Created new profile: {name}");
            }
        }
    }

    // 2. Load a specific profile by name
    public void LoadProfile(string name)
    {
        string safeName = name.Replace(" ", "_");
        string path = Path.Combine(Application.persistentDataPath, safeName + ".json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            activeProfile = JsonUtility.FromJson<UserProfile>(json);
            Debug.Log($"Loaded Profile: {activeProfile.userName}");
        }
        else
        {
            Debug.LogError("Profile not found: " + name);
        }
    }

    // 3. Save the currently active profile
    public void SaveCurrentProfile()
    {
        if (activeProfile == null) return;

        string safeName = activeProfile.userName.Replace(" ", "_");
        string path = Path.Combine(Application.persistentDataPath, safeName + ".json");

        string json = JsonUtility.ToJson(activeProfile, true);
        File.WriteAllText(path, json);
        Debug.Log("Saved data for: " + activeProfile.userName);
    }

    public void ProfileOne() { Profile_PromptOutput.text = "Are you sure you are Participant 1?"; tempProfile = "Participant 1"; }
    public void ProfileTwo() { Profile_PromptOutput.text = "Are you sure you are Participant 2?"; tempProfile = "Participant 2"; }
    public void ProfileThree() { Profile_PromptOutput.text = "Are you sure you are Participant 3?"; tempProfile = "Participant 3"; }
    public void ProfileFour() { Profile_PromptOutput.text = "Are you sure you are Participant 4?"; tempProfile = "Participant 4"; }
    public void ProfileFive() { Profile_PromptOutput.text = "Are you sure you are Participant 5?"; tempProfile = "Participant 5"; }
    public void ProfileSix() { Profile_PromptOutput.text = "Are you sure you are Participant 6?"; tempProfile = "Participant 6"; }
    public void ProfileSeven() { Profile_PromptOutput.text = "Are you sure you are Participant 7?"; tempProfile = "Participant 7"; }
    public void ProfileNinetyNine() { Profile_PromptOutput.text = "Are you sure you are Participant 99?"; tempProfile = "Participant 99"; }
    public void SetProfile()
    {
        ProfilePrompt.gameObject.SetActive(false);
        LoadProfile(tempProfile);
        DataManager.StartNewSession();
        HandUsePrompt.gameObject.SetActive(true);
        UDPSender.SendInitialStimAmps();
        ProfileSet = true;
    }


    public void WrongProfile()
    {
        if(ProfileSet ==  false)
        {
            ProfilePrompt.gameObject.SetActive(true);
            HandUsePrompt.gameObject.SetActive(false);
            Profile_PromptOutput.text = "What is your participant ID?";
            Profile_PromptOutput.color = new Color(255, 255, 255, 1f);
        }


    }

    public void ProfileReset()
    {
        ProfilePrompt.gameObject.SetActive(true);
        HandUsePrompt.gameObject.SetActive(false);
        Profile_PromptOutput.text = "What is your participant ID?";
        Profile_PromptOutput.color = new Color(255, 255, 255, 1f);
    }

    public void CancelLogin()
    {
        if (activeProfile != null)
        {
            Debug.Log($"Logging out {activeProfile.userName}...");

            // 1. Save strictly to be safe (optional, but good practice)
            SaveCurrentProfile();

            // 2. Nullify the active profile
            activeProfile = null;

            // 3. (Optional) Reset any Session Data if you started one
            // DataManager.Instance.currentSession = null;

            Debug.Log("Profile unloaded. Ready for new voice command.");
        }
    }

}