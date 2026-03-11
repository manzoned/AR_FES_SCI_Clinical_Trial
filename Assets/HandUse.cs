using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUse : MonoBehaviour
{
    public int State;
    public InstructionsPart1 InstructionsPart1;
    public InstructionsPart2 InstructionsPart2;
    public InstructionsPart3 InstructionsPart3;
    public InstructionsPart4 InstructionsPart4;
    public InstructionsPart5 InstructionsPart5;
    public HandTracking1 HandTracking;
    public HandUsePrompt HandUsePrompt;

    public void InstructionsOn()
    {
        InstructionsPart1.gameObject.SetActive(false);
        InstructionsPart2.gameObject.SetActive(false);
        InstructionsPart3.gameObject.SetActive(false);
        InstructionsPart4.gameObject.SetActive(false);
        InstructionsPart5.gameObject.SetActive(false);
        gameObject.SetActive(true);
        State = 1;
    }

    public void InstructionsOff()
    {
        gameObject.SetActive(false);
        State = 0;
        HandUsePrompt.HandUsePromptOn();
    }

    public void RightHand()
    {
        HandTracking.HandUsed = 1;
        HandUsePrompt.HandUsePromptOff();
    }

    public void LeftHand() 
    { 
        HandTracking.HandUsed = 2;
        HandUsePrompt.HandUsePromptOff();
    }
    // Start is called before the first frame update
    void Start()
    {
        State = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
