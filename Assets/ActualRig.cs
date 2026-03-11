using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ActualRig : MonoBehaviour
{
    public HandTracking1 HandTracking;
    public MainCamera MainCamera;
    public ChooseTargetPrompt ChooseTargetPrompt;
    public ScorePrompt ScorePrompt;
    public SetPosturePrompt SetPosturePrompt;
    //public TherapistJoints TherapistJoints;
    public PalmPos PalmPos;
    public ActualMeshController ActualMeshController;
    public int GraspState;
    public Vector3 localPos;
    public Quaternion localRot;
    public Vector3 localScale;
    public float tempRotation;
    public TipPinchRig TipPinchRig;
    public LateralRig LateralRig;
    public LargeDiameterRig LargeDiameterRig;
    public TherapistRig TherapistRig;
    public TipPinch TipPinch;
    public Lateral Lateral;
    public LargeDiameter LargeDiameter;
    public TherapistGrasp TherapistGrasp;
    public TherapistJoints TherapistJoints;
    public Vector3 homePos;
    public Quaternion homeRot;

/*    public void AdjustAngle()
    {
        gameObject.transform.SetLocalPositionAndRotation(localPos, localRot);

    }*/


    public void Appear()
    {
        if(PalmPos.NewPositionSet == 1)
        {
            gameObject.SetActive(true);
            ActualMeshController.ActualMesh();
            ActualMeshController.ActualMeshSet = 1;
            if (HandTracking.HandUsed == 1)
            {
                ActualMeshController.initialThumbRigSetActual++;
            }
            if (HandTracking.HandUsed == 2)
            {
                ActualMeshController.initialThumbRigSetActualLeft++;
            }

            GraspState = 1;


            if (HandTracking.HandUsed == 1)
            {
                // set local pos and local rot based on the target grasp so that it's perspective is lined up
                // absolute balues might not work... may need to make it always relative to other hand
                if (TipPinch.GraspState == 1)
                {
                    localRot = new Quaternion(0f, 0f, 0f, 0f);
                    //localRot.eulerAngles = new Vector3(TipPinchRig.transform.eulerAngles.x, -179f, TipPinchRig.transform.eulerAngles.z - 180f);
                    localRot.eulerAngles = new Vector3(TipPinchRig.transform.eulerAngles.x, TipPinchRig.transform.eulerAngles.y - 30f, TipPinchRig.transform.eulerAngles.z - 180f);

                    localPos = new Vector3(-0.14f, -0.08f, 0.85f);
                }
                if (Lateral.GraspState == 1)
                {
                    localRot = new Quaternion(0f, 0f, 0f, 0f);
                    //localRot.eulerAngles = new Vector3(LateralRig.transform.eulerAngles.x, -305f, LateralRig.transform.eulerAngles.z - 180f);
                    localRot.eulerAngles = new Vector3(LateralRig.transform.eulerAngles.x, LateralRig.transform.eulerAngles.y - 30f, LateralRig.transform.eulerAngles.z - 180f);

                    localPos = new Vector3(-0.14f, -0.05f, 0.85f);
                }
                if (LargeDiameter.GraspState == 1)
                {
                    localRot = new Quaternion(0f, 0f, 0f, 0f);
                    localRot.eulerAngles = new Vector3(LargeDiameterRig.transform.eulerAngles.x, LargeDiameterRig.transform.eulerAngles.y - 20f, LargeDiameterRig.transform.eulerAngles.z - 180f);
                    localPos = new Vector3(-0.1f, -0.05f, 0.85f);
                }
                if (TherapistJoints.GraspState == 1)
                {
                    localRot = new Quaternion(0f, 0f, 0f, 0f);
                    localRot.eulerAngles = new Vector3(TherapistRig.transform.eulerAngles.x, TherapistRig.transform.eulerAngles.y - 15f, -180f);
                    localPos = new Vector3(-0.11f, -0.06f, 0.75f);
                }

                localScale = new Vector3(0.97f, 0.97f, 0.97f);

            }

            if (HandTracking.HandUsed == 2) // rotate and flip rig
            {
                // set local pos and local rot based on the target grasp so that it's perspective is lined up
                if (TipPinch.GraspState == 1)
                {
                    float tempZrot = TipPinchRig.transform.eulerAngles.z - 180f * -1;
                    localRot = new Quaternion(0f, 0f, 0f, 0f);
                    //localRot.eulerAngles = new Vector3(TipPinchRig.transform.eulerAngles.x, -375f, tempZrot);
                    //localRot.eulerAngles = new Vector3(TipPinchRig.transform.eulerAngles.x, TipPinchRig.transform.eulerAngles.y, tempZrot);

                    localPos = new Vector3(-0.29f, -0.05f, 0.85f);
                    // try absolute values
                    localRot.eulerAngles = new Vector3(11.2f, -180f, -48.9f);


                }
                if (Lateral.GraspState == 1)
                {
                    localRot = new Quaternion(0f, 0f, 0f, 0f);
                    localRot.eulerAngles = new Vector3(LateralRig.transform.eulerAngles.x, LateralRig.transform.eulerAngles.y - 15f, LateralRig.transform.eulerAngles.z - 180f * -1);
                    localPos = new Vector3(-0.25f, -0.05f, 0.75f);
                }
                if (LargeDiameter.GraspState == 1)
                {
                    localRot = new Quaternion(0f, 0f, 0f, 0f);
                    localRot.eulerAngles = new Vector3(LargeDiameterRig.transform.eulerAngles.x, LargeDiameterRig.transform.eulerAngles.y, LargeDiameterRig.transform.eulerAngles.z - 180f * -1);
                    localPos = new Vector3(-0.24f, -0.05f, 0.75f);
                }
                if (TherapistJoints.GraspState == 1)
                {
                    localRot = new Quaternion(0f, 0f, 0f, 0f);
                    localRot.eulerAngles = new Vector3(TherapistRig.transform.eulerAngles.x, TherapistRig.transform.eulerAngles.y - 15f, TherapistRig.transform.eulerAngles.z);
                    localPos = new Vector3(-0.25f, -0.06f, 0.75f);
                }

                localScale = new Vector3(-0.97f, 0.97f, 0.97f);
            }


            gameObject.transform.localScale = localScale;
            gameObject.transform.SetLocalPositionAndRotation(localPos, localRot);

        }


    }

    public void Disappear()
    {
        gameObject.transform.parent = MainCamera.transform;

        gameObject.transform.SetLocalPositionAndRotation(homePos, homeRot);

        gameObject.SetActive(false);
        GraspState = 0;
        ActualMeshController.ActualMeshSet = 0;
        //ActualMeshController.initialThumbRigSetActual = 0;
        ChooseTargetPrompt.ChooseTargetOn();
        SetPosturePrompt.SetPosturePromptOff();
        ScorePrompt.ScorePromptOff();
    }
    // Start is called before the first frame update
    void Start()
    {
        homePos = new Vector3(0f, 0f, 0f);
        homeRot.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ActualMeshController.ActualMeshSet);
        
    }
}
