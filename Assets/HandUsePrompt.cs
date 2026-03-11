using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUsePrompt : MonoBehaviour
{
    public int promptState;
    public HandTracking1 Handtracking;
    public HandUse HandUse;
    public CalibrationPrompt CalibrationPrompt;

    public void HandUsePromptOn()
    {
        if(Handtracking.HandUsed == 0)
        {
            promptState = 1;
            gameObject.SetActive(true);
        }

    }

    public void HandUsePromptOff()
    {
        promptState = 0;
        gameObject.SetActive(false);
        CalibrationPrompt.CalibrationPromptOn();
    }

    
}
