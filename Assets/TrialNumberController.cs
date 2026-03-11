using JetBrains.Annotations;
using Microsoft.MixedReality.Toolkit.Physics;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrialNumberController : MonoBehaviour
{
    public TextMeshProUGUI trialOutput;
    public Lateral Lateral;
    public LargeDiameter LargeDiameter;
    public TipPinch TipPinch;
    public HandTracking1 HandTracking;
    public PalmPos PalmPos;
    public RegLateral RegLateral;
    public RegLargeDiameter RegLargeDiameter;
    public RegTipPinch RegTipPinch;
    public ErrorScoreScript_v2 errorScoreScript;
    public TipPinchRig TipPinchRig;
    public LateralRig LateralRig;
    public LargeDiameterRig LargeDiameterRig;
    public NewPositions NewPositions;
    public TherapistJoints TherapistJoints;
    public TherapistGrasp TherapistGrasp;
    public RegTherapistGrasp RegTherapistGrasp;
    public TherapistRig TherapistRig;
    public ActualRig ActualRig;
    public int trialCounter;
    public int tipPinchCounter;
    public int lateralCounter;
    public int largeDiameterCounter;
    public int customPoseCounter;

    // need function for internal counters... counter for each grasp (doesnt need to be displayed but need it for guidance state)


    public void redoTrial()

    {
        // decrease specific grasp trial counter here via grasp states perhaps
        if (Lateral.GraspState == 1)
        {
            if (lateralCounter > 0)
            {
                lateralCounter--;
            }

        }
        if (LargeDiameter.GraspState == 1)
        {
            if (largeDiameterCounter > 0)
            {
                largeDiameterCounter--;
            }

        }
        if (TipPinch.GraspState == 1)
        {
            if (tipPinchCounter > 0)
            {
                tipPinchCounter--;
            }

        }
        if (TherapistJoints.GraspState == 1)
        {
            if (customPoseCounter > 0)
            {
                customPoseCounter--;
            }
        }

        // decrease trial counter, but don't make it negative, and dont decrease it if nothing is on the screen
        if (trialCounter > 0)
        {
            if (Lateral.GraspState == 1 || TipPinch.GraspState == 1 || LargeDiameter.GraspState == 1 || TherapistJoints.GraspState == 1)
            {
                trialCounter--;
            }
        }

        // take everything off screen via their own functions

        Lateral.Disappear();
        LargeDiameter.Disappear();
        TipPinch.Disappear();
        RegLateral.Disappear();
        RegLargeDiameter.Disappear();
        RegTipPinch.Disappear();
        LateralRig.Disappear();
        LargeDiameterRig.Disappear();
        TipPinchRig.Disappear();
        TherapistJoints.Disappear();
        TherapistGrasp.Disappear();
        RegTherapistGrasp.Disappear();
        TherapistRig.Disappear();
        ActualRig.Disappear();
        NewPositions.Disappear();
        errorScoreScript.Disappear();
        PalmPos.Disappear();

    }

    // Start is called before the first frame update
    void Start()
    {
        trialCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // input a trial number counter if calibration is done

        if(HandTracking.initialCal == 1)
        {
            // iterate a trial number
            trialOutput.text = $"Repetition Number: {trialCounter}";
        }


    }
}
