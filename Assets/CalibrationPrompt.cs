using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationPrompt : MonoBehaviour
{
    public int promptState;
    public HandTracking1 HandTracking;
    public void CalibrationPromptOn()
    {
        if(HandTracking.initialCal == 0)
        {
            promptState = 1;
            gameObject.SetActive(true);
        }

    }

    public void CalibrationPromptOff()
    {
        promptState = 0;
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
