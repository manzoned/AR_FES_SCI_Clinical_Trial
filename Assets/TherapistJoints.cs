using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapistJoints : MonoBehaviour
{
    public HandTracking1 HandTracking;

    public Vector3 tempPosition;
    public Quaternion tempRotation;
    public int therapistSetActive;
    public int therapistTrigger;
    public int GraspState;
    public float TargetDiff;
    public float calibrateRatio;
    public Vector3 calibrateRatioVector;
    public int calibrateState;
    public int postureState;
    public int waitKey;
    public int targetParented;
    public int regTrigger; 
    public MainCamera MainCamera;
    public TherapistPalmPos TherapistPalmPos;
    public TherapistJoints therapistJoints;
    public TherapistGrasp TherapistGrasp;
    public RegTherapistGrasp RegTherapistGrasp;
    public TrialNumberController TrialNumberController;
    public LargeDiameter LargeDiameter;
    public TipPinch TipPinch;
    public Lateral Lateral;
    public PalmPos PalmPos;
    public TherapistWristPos TherapistWristPos;
    public TherapistIndexKnucklePos TherapistIndexKnucklePos;
    public RegTherapistJoints RegTherapistJoints;
    public BlockingPlaneTherapist BlockingPlaneTherapist;
    public MeshController MeshController;
    public TherapistErrorDialog TherapistErrorDialog;
    public Vector3 localPos;
    public Vector3 tempPos;
    public Quaternion localRot;
    public Quaternion localRotPalm;
    public Quaternion localRotCamera;

    public void Appear()
    {
        if (HandTracking.initialCal == 1 && TherapistPalmPos.therapistCreated == 1)
        {
            if (HandTracking.HandUsed == 1)
            {
                localPos = new Vector3(0.18f, 0.05f, 0.8f);
            }
            if (HandTracking.HandUsed == 2)
            {
                localPos = new Vector3(0.14f, 0.05f, 0.8f); 
            }

            localRotCamera = new Quaternion(0f, 0f, 0f, 0f);
            localRotCamera.eulerAngles = new Vector3(-25f, 0f, 0f);
            tempPos = new Vector3(localPos.x, localPos.y, localPos.z - 2f);

            if (LargeDiameter.GraspState == 0 && Lateral.GraspState == 0 && TipPinch.GraspState == 0)
            {
                if (GraspState == 0)
                {
                    //TrialNumberController.trialCounter++;
                    //TrialNumberController.customPoseCounter++;
                }
                gameObject.SetActive(true);
                therapistJoints.transform.parent = MainCamera.transform;
                GraspState = 1;
                //RegTipPinch.GraspState = 1;
                //BlockingPlaneTipPinch.BlockGuidance();
                localRotPalm = TherapistPalmPos.transform.rotation;
                // instantiate registered therapist hand
                RegTherapistJoints.gameObject.SetActive(true);
                RegTherapistJoints.transform.parent = MainCamera.transform;
                RegTherapistJoints.GraspState = 1;
                RegTherapistJoints.transform.SetLocalPositionAndRotation(tempPos, localRot);
                BlockingPlaneTherapist.BlockGuidance();
            }
        }

        if (TherapistPalmPos.therapistCreated == 0)
        {
            TherapistErrorDialog.Appear();
        }
    }

    public void Disappear()
    {
        //if(TherapistPalmPos.therapistSetActive == 1)
        //{
            gameObject.SetActive(false);
            GraspState = 0;
            PalmPos.StartAlign = 0;
            RegTherapistJoints.GraspState = 0;
            RegTherapistJoints.gameObject.SetActive(false);
            
        //}

    }

    public void TherapistReset()
    {
        GraspState = 0;
        PalmPos.StartAlign = 0;
        RegTherapistJoints.GraspState = 0;
        targetParented = 0;
        waitKey = 0;
        TherapistPalmPos.targetParented = 0;
        TherapistPalmPos.waitKey = 0;
        // postureState = 0; // think about whether it needs to be reset or not... is resizing even necessary (yes cuz will calibrate to user instead of therapist)
        // depart therapistJoints and RegTherapistJoints
        therapistJoints.transform.parent = TherapistGrasp.transform;
        RegTherapistJoints.transform.parent = RegTherapistGrasp.transform;
        Vector3 tempPos = new Vector3(0f, 0f, 0f);
        Quaternion tempRot = new Quaternion(0f, 0f, 0f, 0f);
        transform.SetLocalPositionAndRotation(tempPos, tempRot);
        RegTherapistJoints.transform.SetLocalPositionAndRotation(tempPos, tempRot);
        // make them disappear
        gameObject.SetActive(false);
        RegTherapistJoints.gameObject.SetActive(false);
        MeshController.TherapistMeshSet = 0;
        TherapistPalmPos.therapistCreated = 0;
        TrialNumberController.customPoseCounter = 0;
    }

    public void Resize()
    {
        TargetDiff = Mathf.Sqrt(Mathf.Pow(TherapistIndexKnucklePos.tempPosition.x - TherapistWristPos.tempPosition.x, 2)
                        + Mathf.Pow(TherapistIndexKnucklePos.tempPosition.y - TherapistWristPos.tempPosition.y, 2)
                        + Mathf.Pow(TherapistIndexKnucklePos.tempPosition.z - TherapistWristPos.tempPosition.z, 2));
        calibrateRatio = HandTracking.calibrateDiff / TargetDiff;
        calibrateRatioVector = new Vector3(calibrateRatio, calibrateRatio, calibrateRatio);
        calibrateState = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        targetParented = 0;
        calibrateState = 0;
        postureState = 0;

        localPos = new Vector3(0.18f, 0.05f, 0.8f); // change all this back to original...
        localRotCamera = new Quaternion(0f, 0f, 0f, 0f);
        localRotCamera.eulerAngles = new Vector3(-25f, 0f, 0f);
        tempPos = new Vector3(localPos.x, localPos.y, localPos.z-2f);
        


    }

    // Update is called once per frame
    void Update()
    {
        if (GraspState == 1 && waitKey < 2)
        {
            if (waitKey == 1 && targetParented == 0)
            {
                //tipPinch.transform.parent = MainCamera.transform;
                transform.SetLocalPositionAndRotation(localPos, localRotCamera);
                // copy position for registered hand
                RegTherapistJoints.transform.SetLocalPositionAndRotation(tempPos, localRotCamera);
                //targetParented = 1;
                targetParented++;

            }

            if (postureState == 1 && calibrateState == 0)
            {
                Resize();
                transform.localScale = calibrateRatioVector;
                // resize registered hand
                RegTherapistJoints.transform.localScale = calibrateRatioVector;

                if(HandTracking.HandUsed == 2)
                {
                    //transform.localScale = new Vector3(calibrateRatioVector.x * -1, calibrateRatioVector.y, calibrateRatioVector.z);
                    //RegTherapistJoints.transform.localScale = new Vector3(calibrateRatioVector.x * -1, calibrateRatioVector.y, calibrateRatioVector.z);
                }
            }
            //postureState = 1;
            //waitKey = 1;
            postureState++;
            waitKey++;

        }


    }
}
