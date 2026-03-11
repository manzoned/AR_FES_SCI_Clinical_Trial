using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetPosturePrompt : MonoBehaviour
{
    public TextMeshProUGUI SetPosturePromptOutput;
    public string promptText;
    public int promptState;
    public ChooseTargetPrompt ChooseTargetPrompt;
    public ScorePrompt ScorePrompt;
    public SolverHandler SolverHandler;
    public HandTracking1 HandTracking;
    public void SetPosturePromptOn()
    {
/*        if(ChooseTargetPrompt.promptState == 0 && ScorePrompt.promptState == 0)
        {
            promptState = 1;
            gameObject.SetActive(true);
            //promptText = "Set your posture" + "\n" + "(say: 'Ready' or 'Complete')";
            //SetPosturePromptOutput.text = promptText;
            if (HandTracking.HandUsed == 1)
            {
                SolverHandler.AdditionalOffset = new Vector3(0.05f, 0.08f, 0.4f);

            }
            if (HandTracking.HandUsed == 2)
            {
                SolverHandler.AdditionalOffset = new Vector3(-0.05f, 0.08f, 0.4f);

            }
        }*/

    }

    public void SetPosturePromptOff()
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
