using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ForearmPos : MonoBehaviour
{
    public Vector3 forearmPos;
    //public ErrorScoreScript_v2 ErrorScoreScript_v2;
    public float wristAngle;
    public float wristAngleMeta;
    public float indexKnuckleAngle;
    public int trackTest;
    public float wristAngleAdjusted;
    public float wristAnglePlane;
    //public WristPos wristPos;
    //public MiddleKnucklePos middleKnucklePos;
    public CylinderTarget cylinderTarget;
    public HandTracking1 HandTracking1;
    public PlaneCreator PlaneCreator;
    public float temp;
    public PlaneSphere PlaneSphere;
    public int trackingTimerON;
    public int trackingTimerOFF;
    public int forearmTracking = 0; // 1 is on, 0 is off 
    //public float crossedAngle;
    //public int tenodesisDetected;

    public VuforiaBehaviour VuforiaBehaviour;
    public Lateral Lateral;
    public LargeDiameter LargeDiameter;
    public TipPinch TipPinch;
    public TherapistJoints TherapistJoints;
    public ErrorScoreScript_v2 errorScoreScirpt;
    //public MainCamera MainCamera;

    public void ForearmTrackingON()
    {
        forearmTracking = 1;
    }
    public void ForearmTrackingOFF()
    {
        forearmTracking = 0;
    }
    public void WristAngle()
    {
        trackTest = 1;
        PlaneSphere.gameObject.SetActive(true);
        //trackingTimer = 1;
    }

    public void lostTrack()
    {
        trackTest = 0;
        PlaneSphere.gameObject.SetActive(false);
        //trackingTimer = 0;
    }

    public void VuforiaOn()
    {

            VuforiaBehaviour.Instance.enabled = true;


        
    }
    public void VuforiaOff()
    {

            VuforiaBehaviour.Instance.enabled = false;  
            PlaneSphere.gameObject.SetActive(false);
            trackTest = 0;
        

        //gameObject.transform.position = new Vector3(-10f, -10f, -10f);
    }

    public void TrackingTimerON()
    {
        trackingTimerON++;
    }

    public void TrackingTimerOFF()
    {
        trackingTimerOFF++;
    }

    public void Reset()
    {
        trackingTimerOFF = 0;
        trackingTimerON = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        trackTest = 0;
        trackingTimerON = 0;
        trackingTimerOFF = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (forearmTracking == 1)
        {
            if (Lateral.GraspState == 1 || LargeDiameter.GraspState == 1 || TipPinch.GraspState == 1 || TherapistJoints.GraspState == 1)
            {

                if (errorScoreScirpt.positionset == 0)
                {
                    //VuforiaBehaviour.Instance.enabled = true;
                    // put a time delay here so that can draw target posture before the forearm tracking starts...
                    if (trackingTimerON < 11)
                    {
                        TrackingTimerON();
                        if (trackingTimerON == 10)
                        {
                            VuforiaOn();
                        }

                    }

                    forearmPos = cylinderTarget.transform.position;

                    // need code in here that calculates wrist angle on every frame if it is in a detected state - at least initially in order to debug

                    if (trackTest == 1)
                    {
                        // calculate wrist angle plane here using forearm, hypothetical wrist (planesphere), middle knuckle
                        wristAnglePlane = functions.CalculateAngle(forearmPos.x, forearmPos.y, forearmPos.z,
                                                    PlaneSphere.transform.position.x, PlaneSphere.transform.position.y, PlaneSphere.transform.position.z,
                                                    HandTracking1.middleKnucklePos.x, HandTracking1.middleKnucklePos.y, HandTracking1.middleKnucklePos.z);

                        if (PlaneCreator.crossed == 0)
                        {
                            wristAngleAdjusted = 355 - wristAnglePlane;
                        }
                        else
                        {
                            wristAngleAdjusted = wristAnglePlane;
                        }

                    }
                }

                if (errorScoreScirpt.positionset == 1)
                {
                    //VuforiaBehaviour.Instance.enabled = false;
                    cylinderTarget.transform.position = new Vector3(10f, 10f, 10f);
                    // put a time delay here so that tracking turns off after the posture is set/ not at the same time
                    if (trackingTimerOFF < 11)
                    {
                        TrackingTimerOFF();
                        if (trackingTimerOFF == 10)
                        {
                            VuforiaOff();
                        }
                    }


                }




            }

            if (Lateral.GraspState == 0 && LargeDiameter.GraspState == 0 && TipPinch.GraspState == 0 && TherapistJoints.GraspState == 0)
            {

                VuforiaBehaviour.Instance.enabled = false;
            }
        }
        else
        {
            VuforiaBehaviour.Instance.enabled = false;
        }

            
    }
}
