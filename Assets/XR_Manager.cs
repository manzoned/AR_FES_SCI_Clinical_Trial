using UnityEngine;
using UnityEngine.XR.Management;
using UnityEngine.XR.WindowsMR;

public class XR_Manager : MonoBehaviour
{
    void Start()
    {
        // Initialize the OpenXR session
        XRGeneralSettings.Instance.Manager.InitializeLoader();
        XRGeneralSettings.Instance.Manager.StartSubsystems();
    }

    void OnApplicationQuit()
    {
        // Stop the OpenXR session
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
    }
}
