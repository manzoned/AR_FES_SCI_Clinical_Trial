using UnityEngine;
using UnityEngine.UI;

public class ButtonBridge : MonoBehaviour
{
    public void ClickMe()
    {
        // Force the Unity Button to click
        GetComponent<Button>().onClick.Invoke();
    }
}