using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualMeshController : MonoBehaviour
{
    public ErrorScoreScript_v2 ErrorScoreScript;
    public TipPinch TipPinch;
    public Lateral Lateral;
    public LargeDiameter LargeDiameter;
    public HandTracking1 HandTracking;
    public ActualThumb1 ActualThumb1;
    public ActualThumb2 ActualThumb2;
    public ActualThumb3 ActualThumb3;
    public ActualPointer1 ActualPointer1;
    public ActualPointer2 ActualPointer2;
    public ActualPointer3 ActualPointer3;
    public ActualMiddle1 ActualMiddle1;
    public ActualMiddle2 ActualMiddle2;
    public ActualMiddle3 ActualMiddle3;
    public ActualRing1 ActualRing1;
    public ActualRing2 ActualRing2;
    public ActualRing3 ActualRing3;
    public ActualPinky1 ActualPinky1;
    public ActualPinky2 ActualPinky2;
    public ActualPinky3 ActualPinky3;
    public Vector3 localPos;
    public Quaternion localRot;
    public Vector3 tempRotation;
    public int ActualMeshSet;
    public int initialThumbRigSetActual;
    public float initialRotationYActual;
    public int initialThumbRigSetActualLeft;
    public float initialRotationYActualLeft;

    // create a function that uses the angles from the therapist set target to change the angles of the mesh
    //  Taxonomy:... different for thumb
    //  joint_1 = knuckle angle
    //  joint_2 = middle angle
    //  joint_3 = distal angle
    //  Formula:
    //  -180 + targetjointangle = z angle

    public void ActualMesh()
    {
        if (initialThumbRigSetActual == 0)
        {
            initialRotationYActual = -360f + ActualThumb1.transform.localEulerAngles.y;

            // if left hand... then needs to be opposite ( + 20f);
        }
        if (initialThumbRigSetActualLeft == 0)
        {
            initialRotationYActualLeft = -360f + ActualThumb1.transform.localEulerAngles.y;
        }

        // set up left hand stuff here

        if (ActualMeshSet == 0)
        {
            tempRotation.z = ActualThumb1.transform.localEulerAngles.z;
            //tempRotation.x = ActualThumb1.transform.localEulerAngles.x;

            tempRotation.x = ErrorScoreScript.ActualThumbTriangleAngle - 15f;

            if (Lateral.GraspState == 1)
            {
                tempRotation.x = ErrorScoreScript.ActualThumbTriangleAngle;

            }
            //tempRotation.x = 100 - (ErrorScoreScript.ThumbIndexDistance * 1000);
            //tempRotation.y = -360f + ActualThumb1.transform.localEulerAngles.y - (-180f + ErrorScoreScript.TargetMetaThumbAngle);
            if (HandTracking.HandUsed == 1)
            {
                tempRotation.y = initialRotationYActual - (-180f + ErrorScoreScript.MetaThumbAngle);
            }
            if (HandTracking.HandUsed == 2)
            {
                tempRotation.y = initialRotationYActualLeft - (-180f + ErrorScoreScript.MetaThumbAngle);
            }

            if (Lateral.GraspState == 1)
            {
                tempRotation.y = (ErrorScoreScript.ThumbKnuckleAngle * -1) + 45f;

            }

            localPos = ActualThumb1.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualThumb1.transform.SetLocalPositionAndRotation(localPos, localRot);

            // tempRotation.z = -180f + ErrorScoreScript.ThumbKnuckleAngle + 10f;
            tempRotation.z = -180f + ErrorScoreScript.ThumbKnuckleAngle;

            //tempRotation.x = ActualThumb2.transform.localEulerAngles.x;
            //tempRotation.x = 0f;
            tempRotation.x = 50 - (ErrorScoreScript.ThumbIndexDistance * 1000);
            tempRotation.y = -360f + ActualThumb2.transform.localEulerAngles.y;
            localPos = ActualThumb2.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualThumb2.transform.SetLocalPositionAndRotation(localPos, localRot);

            if (ErrorScoreScript.TargetThumbDistalAngle > 150 && ErrorScoreScript.TargetThumbDistalAngle < 180)
            {
                tempRotation.z = 0;
            }
            else
            {
                tempRotation.z = -180f + ErrorScoreScript.ThumbDistalAngle;
            }
            /*
                        if (ErrorScoreScript.ThumbTipPos.tempPosition.y < ErrorScoreScript.ThumbDistalPos.tempPosition.y)
                        {
                            tempRotation.z = -180f + ErrorScoreScript.ThumbDistalAngle;
                        }*/
            tempRotation.x = ActualThumb3.transform.localEulerAngles.x;
            tempRotation.y = -360f + ActualThumb3.transform.localEulerAngles.y;
            localPos = ActualThumb3.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualThumb3.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.IndexKnuckleAngle;
            tempRotation.x = ActualPointer1.transform.localEulerAngles.x;
            tempRotation.y = -360f + ActualPointer1.transform.localEulerAngles.y;
            localPos = ActualPointer1.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualPointer1.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.IndexMiddleAngle;
            tempRotation.x = ActualPointer2.transform.localEulerAngles.x;
            tempRotation.y = -360f + ActualPointer2.transform.localEulerAngles.y;
            localPos = ActualPointer2.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualPointer2.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.IndexDistalAngle;
            tempRotation.x = ActualPointer3.transform.localEulerAngles.x;
            tempRotation.y = -360f + ActualPointer3.transform.localEulerAngles.y;
            localPos = ActualPointer3.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualPointer3.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.MiddleKnuckleAngle;
            tempRotation.x = ActualMiddle1.transform.localEulerAngles.x;
            tempRotation.y = -360f + ActualMiddle1.transform.localEulerAngles.y;
            localPos = ActualMiddle1.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualMiddle1.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.MiddleMiddleAngle;
            tempRotation.x = ActualMiddle2.transform.localEulerAngles.x;
            tempRotation.y = -360f + ActualMiddle2.transform.localEulerAngles.y;
            localPos = ActualMiddle2.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualMiddle2.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.MiddleDistalAngle;
            tempRotation.x = ActualMiddle3.transform.localEulerAngles.x;
            tempRotation.y = -360f + ActualMiddle3.transform.localEulerAngles.y;
            localPos = ActualMiddle3.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualMiddle3.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.RingKnuckleAngle;
            tempRotation.x = ActualRing1.transform.localEulerAngles.x;
            tempRotation.y = -360f + ActualRing1.transform.localEulerAngles.y;
            localPos = ActualRing1.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualRing1.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.RingMiddleAngle;
            tempRotation.x = ActualRing2.transform.localEulerAngles.x;
            tempRotation.y = -360f + ActualRing2.transform.localEulerAngles.y;
            localPos = ActualRing2.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualRing2.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.RingDistalAngle;
            tempRotation.x = ActualRing3.transform.localEulerAngles.x;
            tempRotation.y = -360f + ActualRing3.transform.localEulerAngles.y;
            localPos = ActualRing3.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualRing3.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.PinkyKnuckleAngle;
            tempRotation.x = ActualPinky1.transform.localEulerAngles.x;
            tempRotation.y = -360f + ActualPinky1.transform.localEulerAngles.y;
            localPos = ActualPinky1.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualPinky1.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.PinkyMiddleAngle;
            tempRotation.x = ActualPinky2.transform.localEulerAngles.x;
            tempRotation.y = -360f + ActualPinky2.transform.localEulerAngles.y;
            localPos = ActualPinky2.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualPinky2.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.PinkyDistalAngle;
            tempRotation.x = ActualPinky3.transform.localEulerAngles.x;
            tempRotation.y = -360f + ActualPinky3.transform.localEulerAngles.y;
            localPos = ActualPinky3.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            ActualPinky3.transform.SetLocalPositionAndRotation(localPos, localRot);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ActualMesh();
        }

        //Debug.Log(ErrorScoreScript.MetaThumbAngle);

    }
}
