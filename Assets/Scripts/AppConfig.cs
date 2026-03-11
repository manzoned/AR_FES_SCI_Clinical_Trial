[System.Serializable]
public class AppConfig
{
    public string targetIPAddress;
    public int targetPort; // Optional, but often useful

    // Constructor with a default value (e.g., localhost)
    public AppConfig()
    {
        targetIPAddress = "192.168.1.100";
        targetPort = 8080;
    }
}