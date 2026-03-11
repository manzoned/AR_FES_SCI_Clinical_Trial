using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsPart2 : MonoBehaviour
{
    public int State;
    public InstructionsPart1 InstructionsPart1;
    public InstructionsPart3 InstructionsPart3;
    public InstructionsPart4 InstructionsPart4;
    public InstructionsPart5 InstructionsPart5;
    public HandUse HandUse;
    public void InstructionsOn()
    {
        InstructionsPart1.gameObject.SetActive(false);
        InstructionsPart3.gameObject.SetActive(false);
        InstructionsPart4.gameObject.SetActive(false);
        InstructionsPart5.gameObject.SetActive(false);
        HandUse.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    public void InstructionsOff()
    { gameObject.SetActive(false); }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
