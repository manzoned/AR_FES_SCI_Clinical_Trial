using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TargetPosturePanel : MonoBehaviour
{
    public TargetPosturePanel targetPosturePanel;
    public TipPinch TipPinch;
    public Lateral Lateral;
    public LargeDiameter LargeDiameter;
    public TherapistGrasp TherapistGrasp;
    public TipPinchRig TipPinchRig;
    public LateralRig LateralRig;
    public LargeDiameterRig LargeDiameterRig;
    public TherapistRig TherapistRig;
    public HandTracking1 HandTracking;
    public SolverHandler SolverHandler;
    public MainCamera MainCamera;
    public TextMeshPro RepPromptOutput;
    public TextMeshPro InstructionsPromptOutput;
    public TrialNumberController TrialNumberController;
    public InstructionsTextBox InstructionsTextBox;
    public RepetitionTextBox RepetitionTextBox;
    public TimerTextBox TimerTextBox;
    public Timer Timer;
    public TextMeshPro TitleTextbox;
    public InstructionsBackPlate InstructionsBackPlate;
    public InstructionsTextHolder InstructionsTextHolder;
    public StimulationVisualizerTarget StimulationVisualizerTarget;
    public StimDashBackPlate StimDashBackPlate;
    public StatsPrompt StatsPrompt;
    public int ScreenIsOn;
    public int ScreenTime;
    public int ScreenPositionSetRight;
    public int ScreenPositionSetLeft;
    public Vector3 skeletonPos;
    public Quaternion skeletonRot;
    public Vector3 targetRigPos;
    public Quaternion targetRigRot;
    public Vector3 localScaleSkeleton;
    public Vector3 localScaleRig;
    public Vector3 originalSkeletonPos;
    public Quaternion originalSkeletonRot;
    public Vector3 originalRigPos;
    public Vector3 originalRigRot;
    public string TargetName;
    public string InstructionsText;
    public string RepPromptText;
    public string objectType;
    public string scorePromptText;
   
    public void ScreenRight()
    {
        SolverHandler.AdditionalOffset = new Vector3(SolverHandler.AdditionalOffset.x + 0.05f, SolverHandler.AdditionalOffset.y, SolverHandler.AdditionalOffset.z);
    }

    public void ScreenLeft()
    {
        SolverHandler.AdditionalOffset = new Vector3(SolverHandler.AdditionalOffset.x - 0.05f, SolverHandler.AdditionalOffset.y, SolverHandler.AdditionalOffset.z);
    }

    public void ScreenUp()
    {
        SolverHandler.AdditionalOffset = new Vector3(SolverHandler.AdditionalOffset.x, SolverHandler.AdditionalOffset.y + 0.05f, SolverHandler.AdditionalOffset.z);
    }

    public void ScreenDown()
    {
        SolverHandler.AdditionalOffset = new Vector3(SolverHandler.AdditionalOffset.x, SolverHandler.AdditionalOffset.y - 0.05f, SolverHandler.AdditionalOffset.z);

    }
    public void ScorePromptOn()
    {
        //scorePromptText = "Stimulation starting in:";
        //InstructionsPromptOutput.text = scorePromptText; // easier to just replace the instructions box that is already there
        if (ScreenIsOn == 1)
        {
            Timer.gameObject.SetActive(true);
            InstructionsPromptOutput.text = "";
        }


    }

    public void ScreenOn() // call this after calling an object
    {
        gameObject.SetActive(true);
        ScreenIsOn = 1;
        InstructionsBackPlate.gameObject.SetActive(true);
        InstructionsTextHolder.transform.localPosition = new Vector3(0f, -0.02f, 0f);
        //StatsPrompt.gameObject.SetActive(true);
        StimulationVisualizerTarget.gameObject.SetActive(false);
        StimDashBackPlate.gameObject.SetActive(false);

        if (HandTracking.HandUsed == 1)
        {
            ScreenPositionSetRight++;
            // put the screen on the opposite side of the hand 
            InstructionsTextBox.transform.localPosition = new Vector3(-0.126f, -0.048f, 0.19f);
            if(ScreenPositionSetRight == 1)
            {
                SolverHandler.AdditionalOffset = new Vector3(-0.18f, -0.088f, 0f);
            }

        }
        if (HandTracking.HandUsed == 2)
        {
            ScreenPositionSetLeft++;
            InstructionsTextBox.transform.localPosition = new Vector3(-0.132f, -0.048f, 0.19f);
            if(ScreenPositionSetLeft == 1)
            {
                SolverHandler.AdditionalOffset = new Vector3(0.18f, -0.088f, 0f);
            }

        }

    }


    public void AttachtoScreen()
    {

        if (TipPinch.GraspState == 1)
        {
            // attach to screen
            TitleTextbox.text = "Target Posture (Pinch)";
            TipPinch.transform.parent = targetPosturePanel.transform;
            TipPinchRig.transform.parent = targetPosturePanel.transform;

            // change scales to match values before becoming children

            if(HandTracking.HandUsed == 1)
            {
                localScaleSkeleton = new Vector3(TipPinch.calibrateRatioVector.x - 0.28f, TipPinch.calibrateRatioVector.y - 0.28f, TipPinch.calibrateRatioVector.z - 0.28f);
                localScaleRig = new Vector3(TipPinch.calibrateRatioVector.x - 0.36f, TipPinch.calibrateRatioVector.y - 0.36f, TipPinch.calibrateRatioVector.z - 0.36f);
                skeletonPos = new Vector3(0.08f, 0.03f, -0.2f);
                skeletonRot.eulerAngles = new Vector3(-7.22f, -21.57f, 4.46f);
                targetRigPos = new Vector3(0.06f, 0f, 0.12f);
                targetRigRot.eulerAngles = new Vector3(-191.2f, 0f, 48.9f);
            }
            if (HandTracking.HandUsed == 2)
            {
                localScaleSkeleton = new Vector3(TipPinch.calibrateRatioVector.x * -1f + 0.28f, TipPinch.calibrateRatioVector.y - 0.28f, TipPinch.calibrateRatioVector.z - 0.28f);
                localScaleRig = new Vector3(TipPinch.calibrateRatioVector.x * -1f + 0.36f, TipPinch.calibrateRatioVector.y - 0.36f, TipPinch.calibrateRatioVector.z - 0.36f);
                skeletonPos = new Vector3(0f, 0.04f, -0.2f);
                skeletonRot.eulerAngles = new Vector3(-7.22f, 8f, 4.46f);
                targetRigPos = new Vector3(-0.06f, 0f, 0.12f);
                targetRigRot.eulerAngles = new Vector3(-191.2f, 0f, -48.9f);
            }

            TipPinch.transform.SetLocalPositionAndRotation(skeletonPos, skeletonRot);
            TipPinch.transform.localScale = localScaleSkeleton;
            TipPinchRig.transform.SetLocalPositionAndRotation(targetRigPos, targetRigRot);
            TipPinchRig.transform.localScale = localScaleRig;
            TargetName = "TipPinch";
            objectType = "(Marble)";

            InstructionsText = "Grasp the object between the tips of you index finger and thumb.";
            RepPromptText = "Repetitions " + objectType + $" = {TrialNumberController.tipPinchCounter}" + "\n" +
             $"Total Repetitions = {TrialNumberController.trialCounter}";
        }

        if(Lateral.GraspState == 1)
        {
            TitleTextbox.text = "Target Posture (Lateral Key)";
            Lateral.transform.parent = targetPosturePanel.transform;
            LateralRig.transform.parent = targetPosturePanel.transform;

            if (HandTracking.HandUsed == 1)
            {
                localScaleSkeleton = new Vector3(Lateral.calibrateRatioVector.x - 0.28f, Lateral.calibrateRatioVector.y - 0.28f, Lateral.calibrateRatioVector.z - 0.28f);
                localScaleRig = new Vector3(Lateral.calibrateRatioVector.x - 0.36f, Lateral.calibrateRatioVector.y - 0.36f, Lateral.calibrateRatioVector.z - 0.36f);
                skeletonPos = new Vector3(-0.02f, 0.018f, -0.2f);
                skeletonRot.eulerAngles = new Vector3(-7.22f, -21.57f, 4.46f);
                targetRigPos = new Vector3(0.04f, 0.01f, 0.12f);
                targetRigRot.eulerAngles = new Vector3(-85.2f, -1000.8f, -61.9f);
            }
            if (HandTracking.HandUsed == 2)
            {
                localScaleSkeleton = new Vector3(Lateral.calibrateRatioVector.x * -1f + 0.28f, Lateral.calibrateRatioVector.y - 0.28f, Lateral.calibrateRatioVector.z - 0.28f);
                localScaleRig = new Vector3(Lateral.calibrateRatioVector.x * -1f + 0.36f, Lateral.calibrateRatioVector.y - 0.36f, Lateral.calibrateRatioVector.z - 0.36f);
                skeletonPos = new Vector3(0.09f, 0.034f, -0.2f);
                skeletonRot.eulerAngles = new Vector3(-7.22f, 8f, 4.46f);
                targetRigPos = new Vector3(-0.045f, 0.01f, 0.12f);
                targetRigRot.eulerAngles = new Vector3(-92.9f, -595.8f, 218.3f);
            }

            Lateral.transform.SetLocalPositionAndRotation(skeletonPos, skeletonRot);
            Lateral.transform.localScale = localScaleSkeleton;
            LateralRig.transform.SetLocalPositionAndRotation(targetRigPos, targetRigRot);
            LateralRig.transform.localScale = localScaleRig;
            TargetName = "Lateral";
            objectType = "(Credit Card)";

            InstructionsText = "Grasp the object between your thumb and the side of your index finger.";
            RepPromptText = "Repetitions " + objectType + $" = {TrialNumberController.lateralCounter}" + "\n" +
                         $"Total Repetitions = {TrialNumberController.trialCounter}";
        }

        if (LargeDiameter.GraspState == 1)
        {
            TitleTextbox.text = "Target Posture (Power)";
            LargeDiameter.transform.parent = targetPosturePanel.transform;
            LargeDiameterRig.transform.parent = targetPosturePanel.transform;

            if (HandTracking.HandUsed == 1)
            {
                localScaleSkeleton = new Vector3(LargeDiameter.calibrateRatioVector.x - 0.28f, LargeDiameter.calibrateRatioVector.y - 0.28f, LargeDiameter.calibrateRatioVector.z - 0.28f);
                localScaleRig = new Vector3(LargeDiameter.calibrateRatioVector.x - 0.36f, LargeDiameter.calibrateRatioVector.y - 0.36f, LargeDiameter.calibrateRatioVector.z - 0.36f);
                skeletonPos = new Vector3(0.12f, 0.034f, -0.22f);
                skeletonRot.eulerAngles = new Vector3(-5.58f, -13.11f, -6.82f);
                targetRigPos = new Vector3(0.05f, 0.01f, 0.12f);
                targetRigRot.eulerAngles = new Vector3(-122.5f, -375f, 41.07f);
            }
            if (HandTracking.HandUsed == 2)
            {
                localScaleSkeleton = new Vector3(LargeDiameter.calibrateRatioVector.x * -1f + 0.28f, LargeDiameter.calibrateRatioVector.y - 0.28f, LargeDiameter.calibrateRatioVector.z - 0.28f);
                localScaleRig = new Vector3(LargeDiameter.calibrateRatioVector.x * -1f + 0.36f, LargeDiameter.calibrateRatioVector.y - 0.36f, LargeDiameter.calibrateRatioVector.z - 0.36f);
                skeletonPos = new Vector3(-0.09f, 0.034f, -0.2f);
                skeletonRot.eulerAngles = new Vector3(-7.22f, 8f, 4.46f);
                targetRigPos = new Vector3(-0.05f, 0.01f, 0.12f);
                targetRigRot.eulerAngles = new Vector3(-132.6f, -349.7f, -33.7f);
            }

            LargeDiameter.transform.SetLocalPositionAndRotation(skeletonPos, skeletonRot);
            LargeDiameter.transform.localScale = localScaleSkeleton;
            LargeDiameterRig.transform.SetLocalPositionAndRotation(targetRigPos, targetRigRot);
            LargeDiameterRig.transform.localScale = localScaleRig;
            TargetName = "LargeDiameter";
            objectType = "(Block)";

            InstructionsText = "Grasp the object between all of your fingers.";
            RepPromptText = "Repetitions " + objectType + $" = {TrialNumberController.largeDiameterCounter}" + "\n" +
             $"Total Repetitions = {TrialNumberController.trialCounter}";
        }
        if(TimerTextBox.ParticipantInitiated)
        {
            //InstructionsText = InstructionsText + "\n" + "\n" + "When ready, start stimulation." + "\n" + "(say: 'Ready' or 'Start Stim')";
            InstructionsText = InstructionsText + "\n" + "\n" + "To start stimulation say:" + "\n" + "'READY' or 'START'";
            InstructionsPromptOutput.text = InstructionsText;
        
        }
        else { InstructionsPromptOutput.text = ""; }

        //RepPromptOutput.text = RepPromptText;
    }

/*    public void AdjustPositions()
    {
        handholderpos = new Vector3(-0.015f, 0f, 0f);
        handholderrot.eulerAngles = new Vector3(0f, 0f, 0f);
        HandHolderTarget.transform.SetLocalPositionAndRotation(handholderpos, handholderrot);

    }*/
    public void ScreenOff() // call this when asking for the feedback screen
    {
        // re parent everything to it's original state
        if(TargetName == "TipPinch")
        {
            TipPinch.transform.parent = MainCamera.transform;
            TipPinchRig.transform.parent = MainCamera.transform;

        }
        if(TargetName == "Lateral")
        {
            Lateral.transform.parent = MainCamera.transform;
            LateralRig.transform.parent = MainCamera.transform;
        }
        if(TargetName == "LargeDiameter")
        {
            LargeDiameter.transform.parent = MainCamera.transform;
            LargeDiameterRig.transform.parent = MainCamera.transform;
        }
        gameObject.SetActive(false);
        ScreenIsOn = 0;
        ScreenTime = 0;
        Timer.gameObject.SetActive(false);

    }

    public void TrialIterator()
    {
        if(ScreenIsOn == 1)
        {
            TrialNumberController.trialCounter++;
            if (TipPinch.GraspState == 1) 
            { 
                TrialNumberController.tipPinchCounter++;
                RepPromptText = "Repetitions " + objectType + $" = {TrialNumberController.tipPinchCounter}" + "\n" +
                     $"Total Repetitions = {TrialNumberController.trialCounter}";
            }
            if (Lateral.GraspState == 1) 
            { 
                TrialNumberController.lateralCounter++;
                RepPromptText = "Repetitions " + objectType + $" = {TrialNumberController.lateralCounter}" + "\n" +
                     $"Total Repetitions = {TrialNumberController.trialCounter}";
            }
            if (LargeDiameter.GraspState == 1) 
            { 
                TrialNumberController.largeDiameterCounter++;
                RepPromptText = "Repetitions " + objectType + $" = {TrialNumberController.largeDiameterCounter}" + "\n" +
                     $"Total Repetitions = {TrialNumberController.trialCounter}";
            }
        }


        //RepPromptOutput.text = RepPromptText;
        //Debug.Log("here");
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ScreenIsOn == 1)
        {
            ScreenTime++;
        }
        if(ScreenTime == 10)
        {
            AttachtoScreen();
        }
        if(ScreenTime == 11)
        {
            //AdjustPositions();
        }
    }
}
