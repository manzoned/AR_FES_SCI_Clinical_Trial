using UnityEngine;
using UnityEngine.UI;

public class NumberPadManager : MonoBehaviour
{
    public GameObject numberPadPanel;
    public Button toggleButton;

    void Start()
    {
        // Ensure the number pad panel is initially hidden
        numberPadPanel.SetActive(false);

        // Add a listener to handle the button click
        toggleButton.onClick.AddListener(ToggleNumberPad);
    }

    // Method to toggle the visibility of the number pad
    private void ToggleNumberPad()
    {
        bool isActive = numberPadPanel.activeSelf;
        numberPadPanel.SetActive(!isActive);
    }
}
