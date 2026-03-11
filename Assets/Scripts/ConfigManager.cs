using UnityEngine;
using System.IO;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance;
    public string targetIPAddress;

    public AppConfig currentConfig;
    private string fileName = "config.json";

    private void Awake()
    {
        if (Instance == null) Instance = this;

        LoadConfig();
    }

    public void LoadConfig()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(path))
        {
            // 1. Read the existing file
            string json = File.ReadAllText(path);
            currentConfig = JsonUtility.FromJson<AppConfig>(json);
            Debug.Log($"Loaded Config from file. Target IP: {currentConfig.targetIPAddress}");

        }
        else
        {
            // 2. No file found? Create a default one!
            Debug.LogWarning("Config file not found. Creating default config.json...");
            currentConfig = new AppConfig();
            SaveConfig(); // Write it to disk so the user can edit it later
        }
        targetIPAddress = currentConfig.targetIPAddress;
    }

    // Call this if you ever update the IP via voice and want to save the new one
    public void SaveConfig()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        string json = JsonUtility.ToJson(currentConfig, true);
        File.WriteAllText(path, json);
        Debug.Log($"Config saved to: {path}");
    }
}