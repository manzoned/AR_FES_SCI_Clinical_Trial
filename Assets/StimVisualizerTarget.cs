using UnityEngine;
using UnityEngine.UI;

public class StimulationVisualizerTarget : MonoBehaviour
{
    public static StimulationVisualizerTarget Instance;

    [Header("Drag the 'Fill' Images here")]
    public Image fingerFill;
    public Image thumbFill;
    public Image handFill;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void UpdateVisuals(float fingerVal, float thumbVal, float handVal)
    {
        // Updates the UI bars (0.0 to 1.0)
        if (fingerFill != null) fingerFill.fillAmount = fingerVal;
        if (thumbFill != null) thumbFill.fillAmount = thumbVal;
        if (handFill != null) handFill.fillAmount = handVal;
    }
}