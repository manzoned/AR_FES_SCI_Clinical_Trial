using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lateral : MonoBehaviour
{
    public int GraspState;
    public LargeDiameter LargeDiameter;
    public TipPinch TipPinch;
    public Lateral lateral;
    public RegLateral RegLateral;
    public TherapistJoints TherapistJoints;
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
    public LateralWristPos LateralWristPos;
    public LateralIndexKnucklePos LateralIndexKnucklePos;
    public TrialNumberController TrialNumberController;
    public BlockingPlaneLateral BlockingPlaneLateral;
    public int Redraw;
    public RegLateralHolder RegLateralHolder;
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
            if (LargeDiameter.GraspState == 0 && TipPinch.GraspState == 0 && TherapistJoints.GraspState == 0)
            {
                if(GraspState == 0)
                {
                    //TrialNumberController.trialCounter++;
                    //TrialNumberController.lateralCounter++;
                }
                if (gameObject.activeInHierarchy)
                {

                }
                else
                {
                    gameObject.SetActive(true);
                    lateral.transform.parent = MainCamera.transform;
                    GraspState = 1;
                    RegLateral.GraspState = 1;
                    BlockingPlaneLateral.BlockGuidance();
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
        TargetDiff = Mathf.Sqrt(Mathf.Pow(LateralIndexKnucklePos.tempPosition.x - LateralWristPos.tempPosition.x, 2)
                + Mathf.Pow(LateralIndexKnucklePos.tempPosition.y - LateralWristPos.tempPosition.y, 2)
                + Mathf.Pow(LateralIndexKnucklePos.tempPosition.z - LateralWristPos.tempPosition.z, 2));
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
                //localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, -11.73f, localRot.eulerAngles.z);
                //localPos = new Vector3(0.05f, 0.04f, 0.3f);
                localPos = new Vector3(0f, localPos.y, localPos.z);
                localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, -40f, localRot.eulerAngles.z);

            }
            if (HandTracking.HandUsed == 2)
            {
                transform.localScale = new Vector3(calibrateRatioVector.x * -1, calibrateRatioVector.y, calibrateRatioVector.z);
                //localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, 9.4f, localRot.eulerAngles.z);
                //localPos = new Vector3(0.25f, 0.04f, 0.3f);
                localPos = new Vector3(0.25f, localPos.y, localPos.z);
                localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, 14f, localRot.eulerAngles.z);

            }

           transform.SetLocalPositionAndRotation(localPos, localRot);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        if (HandTracking.HandUsed == 1) // try changing this to the other side
        {
            localPos = new Vector3(-0.15f, 0.05f, 0.4f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            //localRot.eulerAngles = new Vector3(-0.95f, 11.73f, 0.084f);
            localRot.eulerAngles = new Vector3(-0.95f, -23.35f, 0.084f);

        }
        if (HandTracking.HandUsed == 2)
        {
            localPos = new Vector3(0.25f, 0.04f, 0.3f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            localRot.eulerAngles = new Vector3(-0.95f, 11.73f, 0.084f);
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
                    //RegLateralHolder.gameObject.SetActive(true);
                }
                RegLateralHolder.gameObject.SetActive(true);

            }

            if (HandTracking.HandUsed == 1)
            {
                if (Redraw > 2)
                {
                    RegLateral.transform.localScale = new Vector3(calibrateRatioVector.x, calibrateRatioVector.y, calibrateRatioVector.z);

                }

            }
            if (HandTracking.HandUsed == 2)
            {
                if (Redraw > 2)
                {
                    RegLateral.transform.localScale = new Vector3(calibrateRatioVector.x * -1, calibrateRatioVector.y, calibrateRatioVector.z);

                }
            }
            if (Redraw == 4)
            {
                RegLateralHolder.gameObject.SetActive(false);
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
