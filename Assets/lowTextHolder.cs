using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowTextHolder : MonoBehaviour
{
    public InstructionsPart5 Instructions;
    public void lowGuidance()
    {
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
/*        if (Instructions.guidanceFreq == 1)
        {
            gameObject.SetActive(true);
        }*/
/*        if (Instructions.guidanceFreq == 2 || Instructions.guidanceFreq == 3)
        {
            gameObject.SetActive(false);
        }*/
    }
}
