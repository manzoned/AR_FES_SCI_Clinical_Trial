using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeshController : MonoBehaviour
{
    public ErrorScoreScript_v2 ErrorScoreScript;
    public TherapistThumb1 TherapistThumb1;
    public TherapistThumb2 TherapistThumb2;
    public TherapistThumb3 TherapistThumb3;
    public TherapistPointer1 TherapistPointer1;
    public TherapistPointer2 TherapistPointer2;
    public TherapistPointer3 TherapistPointer3;
    public TherapistMiddle1 TherapistMiddle1;
    public TherapistMiddle2 TherapistMiddle2;
    public TherapistMiddle3 TherapistMiddle3;
    public TherapistRing1 TherapistRing1;
    public TherapistRing2 TherapistRing2;
    public TherapistRing3 TherapistRing3;
    public TherapistPinky1 TherapistPinky1;
    public TherapistPinky2 TherapistPinky2;
    public TherapistPinky3 TherapistPinky3;
    public Vector3 localPos;
    public Quaternion localRot;
    public Vector3 tempRotation;
    public int TherapistMeshSet;
    public int initialThumbRigSet;
    public float initialRotationY;

    // create a function that uses the angles from the therapist set target to change the angles of the mesh
    //  Taxonomy:... different for thumb
    //  joint_1 = knuckle angle
    //  joint_2 = middle angle
    //  joint_3 = distal angle
    //  Formula:
    //  -180 + targetjointangle = z angle
    public void TherapistMesh() 
    {
        if (initialThumbRigSet == 0)
        {
            initialRotationY = -360f + TherapistThumb1.transform.localEulerAngles.y;
        }

        if(TherapistMeshSet == 0)
        {
            tempRotation.z = TherapistThumb1.transform.localEulerAngles.z;
            //tempRotation.x = TherapistThumb1.transform.localEulerAngles.x;
            tempRotation.x = ErrorScoreScript.targetThumbTriangleAngle - 15f;
            //tempRotation.y = -360f + TherapistThumb1.transform.localEulerAngles.y - (-180f + ErrorScoreScript.TargetMetaThumbAngle);
            tempRotation.y = initialRotationY - (-180f + ErrorScoreScript.TargetMetaThumbAngle);
            //tempRotation.y = initialRotationY;
            localPos = TherapistThumb1.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistThumb1.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.TargetThumbKnuckleAngle + 10f;
            tempRotation.x = TherapistThumb2.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistThumb2.transform.localEulerAngles.y;
            localPos = TherapistThumb2.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistThumb2.transform.SetLocalPositionAndRotation(localPos, localRot);

            if (ErrorScoreScript.TargetThumbDistalAngle > 150 && ErrorScoreScript.TargetThumbDistalAngle < 180)
            {
                tempRotation.z = 0;
            }
            else
            {
                tempRotation.z = -180f + ErrorScoreScript.ThumbDistalAngle;
            }

            tempRotation.x = TherapistThumb3.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistThumb3.transform.localEulerAngles.y;
            localPos = TherapistThumb3.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistThumb3.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.TargetIndexKnuckleAngle;
            tempRotation.x = TherapistPointer1.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistPointer1.transform.localEulerAngles.y;
            localPos = TherapistPointer1.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistPointer1.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.TargetIndexMiddleAngle;
            tempRotation.x = TherapistPointer2.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistPointer2.transform.localEulerAngles.y;
            localPos = TherapistPointer2.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistPointer2.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.TargetIndexDistalAngle;
            tempRotation.x = TherapistPointer3.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistPointer3.transform.localEulerAngles.y;
            localPos = TherapistPointer3.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistPointer3.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.TargetMiddleKnuckleAngle;
            tempRotation.x = TherapistMiddle1.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistMiddle1.transform.localEulerAngles.y;
            localPos = TherapistMiddle1.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistMiddle1.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.TargetMiddleMiddleAngle;
            tempRotation.x = TherapistMiddle2.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistMiddle2.transform.localEulerAngles.y;
            localPos = TherapistMiddle2.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistMiddle2.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.TargetMiddleDistalAngle;
            tempRotation.x = TherapistMiddle3.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistMiddle3.transform.localEulerAngles.y;
            localPos = TherapistMiddle3.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistMiddle3.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.TargetRingKnuckleAngle;
            tempRotation.x = TherapistRing1.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistRing1.transform.localEulerAngles.y;
            localPos = TherapistRing1.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistRing1.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.TargetRingMiddleAngle;
            tempRotation.x = TherapistRing2.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistRing2.transform.localEulerAngles.y;
            localPos = TherapistRing2.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistRing2.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.TargetRingDistalAngle;
            tempRotation.x = TherapistRing3.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistRing3.transform.localEulerAngles.y;
            localPos = TherapistRing3.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistRing3.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.TargetPinkyKnuckleAngle;
            tempRotation.x = TherapistPinky1.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistPinky1.transform.localEulerAngles.y;
            localPos = TherapistPinky1.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistPinky1.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.TargetPinkyMiddleAngle;
            tempRotation.x = TherapistPinky2.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistPinky2.transform.localEulerAngles.y;
            localPos = TherapistPinky2.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistPinky2.transform.SetLocalPositionAndRotation(localPos, localRot);

            tempRotation.z = -180f + ErrorScoreScript.TargetPinkyDistalAngle;
            tempRotation.x = TherapistPinky3.transform.localEulerAngles.x;
            tempRotation.y = -360f + TherapistPinky3.transform.localEulerAngles.y;
            localPos = TherapistPinky3.transform.localPosition;
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = tempRotation;
            TherapistPinky3.transform.SetLocalPositionAndRotation(localPos, localRot);

            
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        //localRot = new Quaternion(0f, 0f, 0f, 0f);
        //TherapistMeshSet = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            TherapistMesh();
        }
    }
}
