using UnityEngine;
using UnityEngine.UI;
using TMPro; // Assuming you use TextMeshPro for clear text

public class ProfileSelectorUI : MonoBehaviour
{
    [Header("References")]
    public GameObject buttonPrefab;  // The button we will copy
    public Transform gridContainer;  // The parent object (Grid Layout)

    void Start()
    {
        GenerateButtons();
    }

    void GenerateButtons()
    {
        // 1. Get the list of names we created in step 2
        string[] names = ProfileManager.Instance.preMadeUserNames;

        // 2. Loop through each name
        foreach (string profileName in names)
        {
            // Create a new button inside the container
            GameObject newBtn = Instantiate(buttonPrefab, gridContainer);

            // Set the label text (Use GetComponentInChildren to find the text label)
            TextMeshProUGUI label = newBtn.GetComponentInChildren<TextMeshProUGUI>();
            if (label != null) label.text = profileName;

            // 3. Add the "Click" listener
            // When clicked, it calls "OnProfileClicked" with this specific name
            Button btn = newBtn.GetComponent<Button>();
            btn.onClick.AddListener(() => OnProfileClicked(profileName));
        }
    }

    void OnProfileClicked(string name)
    {
        Debug.Log("User selected: " + name);

        // Tell the Manager to load the data!
        ProfileManager.Instance.LoadProfile(name);

        // Optional: Hide this menu now that we are logged in
        // gameObject.SetActive(false); 
    }
}