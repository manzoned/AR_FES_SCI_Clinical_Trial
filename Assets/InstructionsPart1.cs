using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InstructionsPart1 : MonoBehaviour
{
    public int State;
    public InstructionsPart2 InstructionsPart2;
    public InstructionsPart3 InstructionsPart3;
    public InstructionsPart4 InstructionsPart4;
    public InstructionsPart5 InstructionsPart5;
    public HandUse HandUse;
    public void InstructionsOn()
    {
 
        InstructionsPart2.gameObject.SetActive(false);
        InstructionsPart3.gameObject.SetActive(false); 
        InstructionsPart4.gameObject.SetActive(false);
        InstructionsPart5.gameObject.SetActive(false);
        HandUse.gameObject.SetActive(false);
        gameObject.SetActive(true);

    }

    public void InstructionsOff()
    { 
        gameObject.SetActive(false);
        State = 0;
    }    
    // Start is called before the first frame update
    void Start()
    {
        //State = 1; // only for instructions part 1 because this will be present when app is first opened
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
