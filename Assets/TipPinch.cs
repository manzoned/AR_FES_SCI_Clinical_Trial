using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
//using UnityEditor.Build.Content;

//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TipPinch : MonoBehaviour
{
    public int GraspState;
    public LargeDiameter LargeDiameter;
    public Lateral Lateral;
    public TipPinch tipPinch;
    public RegTipPinch RegTipPinch;
    public RegTipPinchHolder RegTipPinchHolder;
    public TherapistJoints TherapistJoints;
    public MainCamera MainCamera;
    public PalmPos PalmPos;
    public Vector3 localPos;
    public Quaternion localRot;
    public Quaternion tempRot;
    public HandTracking1 HandTracking;
    public float TargetDiff;
    public float calibrateRatio;
    public Vector3 calibrateRatioVector;
    public int calibrateState;
    public int postureState;
    public int waitKey;
    public int targetParented;
    public int Resized;
    public TipPinchWristPos TipPinchWristPos;
    public TipPinchIndexKnucklePos TipPinchIndexKnucklePos;
    public TrialNumberController TrialNumberController;
    public BlockingPlaneTipPinch BlockingPlaneTipPinch;
    public TipPinchPalmPos TipPinchPalmPos;
    //public LineCodeTarget LineCodeTarget;
    public int Redraw;
    public FeedbackTest FeedbackTest;
    public ChooseTargetPrompt ChooseTargetPrompt;
    public SetPosturePrompt SetPosturePrompt;
    public TargetPosturePanel TargetPosturePanel;   
    public ErrorScoreScript_v2 ErrorScoreScript;
    public TimerTextBox TimerTextBox;
     
    private int labelTime;
   
    public void Appear()
    {
        if(TimerTextBox.ParticipantInitiated == false)
        {
            TimerTextBox.StartTimer();
            TargetPosturePanel.ScorePromptOn();
        }
        if(HandTracking.initialCal == 1)
        {

            if (LargeDiameter.GraspState == 0 && Lateral.GraspState == 0 && TherapistJoints.GraspState == 0)
            {

                if(GraspState == 0)
                {
                    //TrialNumberController.trialCounter++;
                    //TrialNumberController.tipPinchCounter++;
                }
                if (gameObject.activeInHierarchy)
                {

                }
                else
                {
                    gameObject.SetActive(true);
                    tipPinch.transform.parent = MainCamera.transform;
                    GraspState = 1;
                    RegTipPinch.GraspState = 1;
                    BlockingPlaneTipPinch.BlockGuidance();
                    FeedbackTest.GuidanceInstructions();
                    ChooseTargetPrompt.ChooseTargetOff();
                    SetPosturePrompt.SetPosturePromptOn();
                    TargetPosturePanel.ScreenOn();
                    labelTime = 0;
                }

            }
        }



    }

    public void TriggerLabeling()
    {

        ErrorScoreScript.TargetLabeling();
        labelTime++;

    }
    public void Disappear()
    { 
        gameObject.SetActive(false);
        GraspState = 0;
        PalmPos.StartAlign = 0;
    }

    public void Resize()
    {
        TargetDiff = Mathf.Sqrt(Mathf.Pow(TipPinchIndexKnucklePos.tempPosition.x - TipPinchWristPos.tempPosition.x, 2)
                        + Mathf.Pow(TipPinchIndexKnucklePos.tempPosition.y - TipPinchWristPos.tempPosition.y, 2)
                        + Mathf.Pow(TipPinchIndexKnucklePos.tempPosition.z - TipPinchWristPos.tempPosition.z, 2));
        calibrateRatio = HandTracking.calibrateDiff / TargetDiff;
        //calibrateRatioVector = new Vector3 (calibrateRatio, calibrateRatio, calibrateRatio);
        calibrateRatioVector = new Vector3(1f, 1f, 1f); // no registration between target and actual so they dont need to be the same size
        calibrateState = 1; // calibrateState == 1
        Resized = 1;

        //Debug.Log(TargetDiff);

    }

    public void HandSwitch()
    {
        if (Resized == 1)
        {
            if (HandTracking.HandUsed == 1)
            {
                transform.localScale = new Vector3(calibrateRatioVector.x, calibrateRatioVector.y, calibrateRatioVector.z);
                localPos = new Vector3 (-0.08f, localPos.y, localPos.z);
                localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, -16.05f, localRot.eulerAngles.z);

            }
            if (HandTracking.HandUsed == 2)
            {
                transform.localScale = new Vector3(calibrateRatioVector.x * -1, calibrateRatioVector.y, calibrateRatioVector.z);
                //localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, localRot.eulerAngles.y * -1, localRot.eulerAngles.z);
                localPos = new Vector3(0f, localPos.y, localPos.z);
                localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, 30f, localRot.eulerAngles.z);
            }

            transform.SetLocalPositionAndRotation(localPos, localRot);
            Redraw = 0;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        // include handedness details here... if left, flip the x scale and will also have to move to the right
        if (HandTracking.HandUsed == 1)
        {
            localPos = new Vector3(-0.14f, 0.01f, 0.4f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            localRot.eulerAngles = new Vector3 (-7.215f, -8f, 4.463f);
        }

        else if (HandTracking.HandUsed == 2)
        {
            localPos = new Vector3(0.17f, 0.01f, 0.4f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            localRot.eulerAngles = new Vector3(-7.215f, 8f, 4.463f);
        }

        //localRot.SetEulerRotation(-7.215f, -4.233f, 4.463f);
        calibrateState = 0;
        postureState = 0;
        targetParented = 0;
        Resized = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(GraspState == 1 && waitKey < 2) // waitKey < 2
        {
            if (waitKey == 1 && targetParented == 0)
            {

                transform.SetLocalPositionAndRotation(localPos, localRot);


                targetParented++;
            }


            waitKey++;
            
        }
        if (Redraw < 5)
        {
            if (postureState == 1 && calibrateState == 0)
            {
                Resize();
                transform.localScale = calibrateRatioVector;
                if (HandTracking.HandUsed == 2)
                {
                    transform.localScale = new Vector3(calibrateRatioVector.x * -1, calibrateRatioVector.y, calibrateRatioVector.z);
                    //RegTipPinchHolder.gameObject.SetActive(true);
                }
                RegTipPinchHolder.gameObject.SetActive(true);


            }


            if (HandTracking.HandUsed == 1)
            {
                if (Redraw > 2)
                {
                    RegTipPinch.transform.localScale = new Vector3(calibrateRatioVector.x, calibrateRatioVector.y, calibrateRatioVector.z);

                }

            }
            if (HandTracking.HandUsed == 2)
            {
                if (Redraw > 2)
                {
                    RegTipPinch.transform.localScale = new Vector3(calibrateRatioVector.x * -1, calibrateRatioVector.y, calibrateRatioVector.z);

                }
            }


            if (Redraw == 4)
            {
                RegTipPinchHolder.gameObject.SetActive(false);
            }

        }
        Redraw++;

        postureState++;

        if(GraspState == 1 && labelTime < 5)
        {
            TriggerLabeling();
        }
        
    }
}
