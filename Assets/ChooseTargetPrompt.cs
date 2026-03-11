using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseTargetPrompt : MonoBehaviour
{
    public int promptState;
    public HandTracking1 HandTracking;
    public TipPinch TipPinch;
    public Lateral Lateral;
    public TherapistGrasp TherapistGrasp;
    public LargeDiameter LargeDiameter;
    public TextMeshProUGUI targetPromptOutput;
    public SolverHandler SolverHandler;
    public string promptText;
    public ScorePrompt ScorePrompt;
    public SetPosturePrompt SetPosturePrompt;
    public RepetitionPrompt RepetitionPrompt;

    public void ChooseTargetOn()
    {
        if(HandTracking.initialCal == 1)
        {
            if (TipPinch.GraspState == 0 && Lateral.GraspState == 0 && LargeDiameter.GraspState == 0 && TherapistGrasp.GraspState == 0)
            {
                if (ScorePrompt.promptState == 0 && SetPosturePrompt.promptState == 0)
                {
                    promptState = 1;
                    gameObject.SetActive(true);
                    RepetitionPrompt.RepetitionPromptOn();
                    //promptText = "Choose a target posture" + "\n" + "(say: 'Marble' or 'Block' or 'Credit Card')";
                    //targetPromptOutput.text = promptText;
                }

            }
        }

    }

    public void ChooseTargetOff()
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
