using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RepetitionPrompt : MonoBehaviour
{
    public TipPinch TipPinch;
    public Lateral Lateral;
    public LargeDiameter LargeDiameter;
    public TrialNumberController TrialNumberController;
    public HandTracking1 HandTracking;
    public string promptText;
    public string objectType;
    public TextMeshProUGUI repetitionPromptOutput;
    public SolverHandler SolverHandler;

    public void RepetitionPromptOn()
    {
        //gameObject.SetActive(true);
    }

    public void RepetitionPromptOff()
    {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HandTracking.HandUsed == 1)
        {
            SolverHandler.AdditionalOffset = new Vector3(0.22f, -0.2f, 0.4f);
        }
        if(HandTracking.HandUsed == 2)
        {
            SolverHandler.AdditionalOffset = new Vector3(-0.22f, -0.2f, 0.4f);
        }

        if(TrialNumberController.trialCounter == 0)
        {
            promptText = "Total Repetitions = 0";
        }

        if(TipPinch.GraspState == 1)
        {
            objectType = "(Marble)";
            promptText = "Repetitions " + objectType + $" = {TrialNumberController.tipPinchCounter}" + "\n" +
                         $"Total Repetitions = {TrialNumberController.trialCounter}";
            
        }

        if (Lateral.GraspState == 1)
        {
            objectType = "(Credit Card)";
            promptText = "Repetitions " + objectType + $" = {TrialNumberController.lateralCounter}" + "\n" +
                         $"Total Repetitions = {TrialNumberController.trialCounter}";
        }

        if (LargeDiameter.GraspState == 1)
        {
            objectType = "(Block)";
            promptText = "Repetitions " + objectType + $" = {TrialNumberController.largeDiameterCounter}" + "\n" +
                         $"Total Repetitions = {TrialNumberController.trialCounter}";
        }

        repetitionPromptOutput.text = promptText;
        
    }
}
