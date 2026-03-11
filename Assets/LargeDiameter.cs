using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LargeDiameter : MonoBehaviour
{
    public int GraspState;
    public TipPinch TipPinch;
    public Lateral Lateral;
    public LargeDiameter largeDiameter;
    public TherapistJoints TherapistJoints;
    public RegLargeDiameter RegLargeDiameter;
    public MainCamera MainCamera;
    public PalmPos PalmPos;
    private Vector3 localPos;
    private Quaternion localRot;
    public HandTracking1 HandTracking;
    public float TargetDiff;
    public float calibrateRatio;
    public Vector3 calibrateRatioVector;
    public int calibrateState;
    public int postureState;
    public int waitKey;
    public int targetParented;
    public int Resized;
    public LargeDiameterWristPos LargeDiameterWristPos;
    public LargeDiameterIndexKnucklePos LargeDiameterIndexKnucklePos;
    public TrialNumberController TrialNumberController;
    public BlockingPlaneLargeDiameter BlockingPlaneLargeDiameter;
    public int Redraw;
    public RegLargeDiameterHolder RegLargeDiameterHolder;
    public FeedbackTest FeedbackTest;
    public ChooseTargetPrompt ChooseTargetPrompt;
    public SetPosturePrompt SetPosturePrompt;
    public TargetPosturePanel TargetPosturePanel;
    public ErrorScoreScript_v2 ErrorScoreScript;
    private int labelTime;

    public void Appear()
    {
        if(HandTracking.initialCal == 1)
        {
            if(TipPinch.GraspState == 0 && Lateral.GraspState == 0 && TherapistJoints.GraspState == 0)
            {
                if(GraspState == 0)
                {
                    //TrialNumberController.trialCounter++;
                    //TrialNumberController.largeDiameterCounter++;
                }

                if(gameObject.activeInHierarchy)
                {

                }
                else
                {
                    gameObject.SetActive(true);
                    largeDiameter.transform.parent = MainCamera.transform;
                    GraspState = 1;
                    RegLargeDiameter.GraspState = 1;
                    BlockingPlaneLargeDiameter.BlockGuidance();
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
        TargetDiff = Mathf.Sqrt(Mathf.Pow(LargeDiameterIndexKnucklePos.tempPosition.x - LargeDiameterWristPos.tempPosition.x, 2)
        + Mathf.Pow(LargeDiameterIndexKnucklePos.tempPosition.y - LargeDiameterWristPos.tempPosition.y, 2)
        + Mathf.Pow(LargeDiameterIndexKnucklePos.tempPosition.z - LargeDiameterWristPos.tempPosition.z, 2));
        calibrateRatio = HandTracking.calibrateDiff / TargetDiff;
        //calibrateRatioVector = new Vector3(calibrateRatio, calibrateRatio, calibrateRatio);
        calibrateRatioVector = new Vector3(1f, 1f, 1f); // no registration between target and actual so they dont need to be the same size
        calibrateState = 1;
        Resized = 1;
    }

    public void HandSwitch()
    {
        if (Resized == 1)
        {
            if (HandTracking.HandUsed == 1)
            {
                transform.localScale = new Vector3(calibrateRatioVector.x, calibrateRatioVector.y, calibrateRatioVector.z);
                //localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, 21f, localRot.eulerAngles.z);
                localPos = new Vector3(0f, localPos.y, localPos.z);
                localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, -8.58f, localRot.eulerAngles.z);

            }
            if (HandTracking.HandUsed == 2)
            {
                transform.localScale = new Vector3(calibrateRatioVector.x * -1, calibrateRatioVector.y, calibrateRatioVector.z);
                //localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, 5.5f, localRot.eulerAngles.z);
                //localPos = new Vector3(0.04f, -0.01f, 0.29f);
                localPos = new Vector3(0f, localPos.y, localPos.z);
                localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, 11.8f, localRot.eulerAngles.z);

            }

            transform.SetLocalPositionAndRotation(localPos, localRot);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if (HandTracking.HandUsed == 1)
        {
            localPos = new Vector3(0f, -0.02f, 0.29f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            localRot.eulerAngles = new Vector3(-9.28f, -8.58f, -2.617f);
        }
        if (HandTracking.HandUsed == 2)
        {
            localPos = new Vector3(0.04f, -0.01f, 0.29f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            localRot.eulerAngles = new Vector3(-9.28f, 5.536f, -2.617f);
        }

        calibrateState = 0;
        postureState = 0;
        targetParented = 0;
        Resized = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GraspState == 1 && waitKey < 2) // waitKey < 2
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
                    //RegLargeDiameterHolder.gameObject.SetActive(true);
                }
                RegLargeDiameterHolder.gameObject.SetActive(true);

            }

            if (HandTracking.HandUsed == 1)
            {
                if (Redraw > 2)
                {
                    RegLargeDiameter.transform.localScale = new Vector3(calibrateRatioVector.x, calibrateRatioVector.y, calibrateRatioVector.z);

                }

            }
            if (HandTracking.HandUsed == 2)
            {
                if (Redraw > 2)
                {
                    RegLargeDiameter.transform.localScale = new Vector3(calibrateRatioVector.x * -1, calibrateRatioVector.y, calibrateRatioVector.z);

                }
            }
            if (Redraw == 4)
            {
                RegLargeDiameterHolder.gameObject.SetActive(false);
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
