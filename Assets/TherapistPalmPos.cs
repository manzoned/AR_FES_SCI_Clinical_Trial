using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapistPalmPos : MonoBehaviour
{
    public HandTracking1 HandTracking;

    public Vector3 tempPosition;
    public Quaternion tempRotation;
    public int therapistSetActive;
    public int therapistTrigger;
    public int waitKey;
    public int targetParented;
    public int therapistCounter;
    public int therapistCreated;
    public TherapistPalmPos therapistPalmPos;
    public TherapistJoints TherapistJoints;
    public RegTherapistPalmPos RegTherapistPalmPos;
    public RegTherapistJoints RegTherapistJoints;
    public TherapistGrasp TherapistGrasp;
    public RegTherapistGrasp RegTherapistGrasp;
    public Vector3 localPos;
    public ErrorScoreScript_v2 ErrorScoreScript;
    public Quaternion localRot;


    public void TherapistSet()
    {
        TherapistJoints.gameObject.SetActive(true);
        RegTherapistJoints.gameObject.SetActive(true);
        RegTherapistGrasp.gameObject.SetActive(true);
        TherapistGrasp.gameObject.SetActive(true);
        
        tempPosition = HandTracking.palmPos;
        tempRotation = HandTracking.palmRot;

        transform.position = tempPosition;
        transform.rotation = tempRotation;

        therapistSetActive = 1;
        therapistCounter = 0;
        therapistCreated = 1;
        //ErrorScoreScript.TherapistAngles();
        if (HandTracking.HandUsed == 1)
        {
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = new Vector3(0f, -70f, -100f);
        }
        if (HandTracking.HandUsed == 2)
        {
            localRot = new Quaternion(0f, 0f, 0f, 0f);
            localRot.eulerAngles = new Vector3(0f, 70f, 100f);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        localPos = new Vector3(0f, 0f, 0f); // seems pretty good for now but can adjust
        //localRot = tempRotation;
        //calibrateState = 0;
        //postureState = 0;
        targetParented = 0;
/*        localRot = new Quaternion(0f, 0f, 0f, 0f);
        localRot.eulerAngles = new Vector3(0f, -70f, -100f);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (therapistSetActive == 1)
        {
            therapistTrigger = 1;
            //therapistSetActive = 0;
            therapistCounter++;
        }

        if (therapistCounter == 10 && therapistTrigger == 1)
        {
            therapistTrigger = 0;
            therapistSetActive= 0;
            ErrorScoreScript.TherapistAngles();
        }

        if (TherapistJoints.GraspState == 1 && waitKey < 2)
        {
            if (waitKey == 1 && targetParented == 0)
            {
                //tipPinch.transform.parent = MainCamera.transform;
                //transform.SetLocalPositionAndRotation(localPos, TherapistJoints.localRotPalm);
                transform.SetLocalPositionAndRotation(localPos, localRot);
                // do the same for registered palm pos
                //RegTherapistPalmPos.transform.SetLocalPositionAndRotation(localPos, TherapistJoints.localRotPalm);
                RegTherapistPalmPos.transform.SetLocalPositionAndRotation(localPos, localRot);
                //targetParented = 1;
                targetParented++;
            }

            //postureState = 1;
            //waitKey = 1;
            //postureState++;
            waitKey++;

        }
    }
}
