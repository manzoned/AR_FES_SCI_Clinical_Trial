using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    public InputField inputField;
    public string inputValue;

    void Start()
    {
        // Ensure the Input Field component is assigned
        if (inputField == null)
        {
            inputField = GetComponent<InputField>();
        }

        // Add a listener to handle the input value when it changes
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    // This method is called whenever the input value changes
    private void OnInputValueChanged(string value)
    {
        inputValue = value;
        Debug.Log("Input Value: " + inputValue);
    }
}
