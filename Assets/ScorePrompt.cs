using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePrompt : MonoBehaviour
{
    public HandTracking1 HandTracking;
    public NewPositions NewPositions;
    public TextMeshProUGUI scorePromptOutput;
    public string promptText;
    public int promptState;
    public ChooseTargetPrompt ChooseTargetPrompt;  
    public SetPosturePrompt SetPosturePrompt;
    public SolverHandler SolverHandler;

    public void ScorePromptOn()
    {
/*        if(ChooseTargetPrompt.promptState == 0 && SetPosturePrompt.promptState == 0)
        {
            promptState = 1;
            gameObject.SetActive(true);
            //promptText = "Ask for your score (say: 'Score' or 'Performance')";
            //scorePromptOutput.text = promptText;

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

    public void ScorePromptOff()
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
