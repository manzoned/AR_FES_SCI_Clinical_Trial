using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class InstructionsPart5 : MonoBehaviour
{
    public int guidanceFreq;
    public int State;
    public InstructionsPart1 InstructionsPart1;
    public InstructionsPart2 InstructionsPart2;
    public InstructionsPart3 InstructionsPart3;
    public InstructionsPart4 InstructionsPart4;
    public HandUse HandUse;
    public void InstructionsOn()
    {
        InstructionsPart1.gameObject.SetActive(false);
        InstructionsPart2.gameObject.SetActive(false);
        InstructionsPart3.gameObject.SetActive(false);
        InstructionsPart4.gameObject.SetActive(false);
        HandUse.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    public void InstructionsOff()
    { gameObject.SetActive(false); }

    public void lowGuidance()
    {
        guidanceFreq = 1;
    }

    public void mediumGuidance() 
    { guidanceFreq = 2;}
    
    public void highGuidance() 
    {  guidanceFreq = 3;}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
