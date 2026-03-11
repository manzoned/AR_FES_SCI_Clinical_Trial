using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;
using System.Linq;
using System;
using Unity.VisualScripting;
using UnityEngine.XR.OpenXR.Features.Interactions;
using Unity.Mathematics;

public class HandTracking1 : MonoBehaviour

{
    public Camera arCamera;
    public TipPinch TipPinch;
    public Lateral Lateral;
    public LargeDiameter LargeDiameter;
    public RegTipPinch RegTipPinch;
    public RegLateral RegLateral;
    public RegLargeDiameter RegLargeDiameter;
    public ChooseTargetPrompt ChooseTargetPrompt;
    public CalibrationPrompt CalibrationPrompt;
    public RepetitionPrompt RepetitionPrompt;

    public GameObject sphereMarker;
    public GameObject squareMarker;
    public Vector3 thumbTipPos;
    public Vector3 thumbDistalPos;
    public Vector3 thumbProximalPos;
    public Vector3 metaThumbPos;
    public Vector3 indexTipPos;
    public Vector3 indexDistalPos;
    public Vector3 indexMiddlePos;
    public Vector3 indexKnucklePos;
    public Vector3 metaIndexPos;
    public Vector3 middleTipPos;
    public Vector3 middleDistalPos;
    public Vector3 middleMiddlePos;
    public Vector3 middleKnucklePos;
    public Vector3 metaMiddlePos;
    public Vector3 ringTipPos;
    public Vector3 ringDistalPos;
    public Vector3 ringMiddlePos;
    public Vector3 ringKnucklePos;
    public Vector3 metaRingPos;
    public Vector3 pinkyTipPos;
    public Vector3 pinkyDistalPos;
    public Vector3 pinkyMiddlePos;
    public Vector3 pinkyKnucklePos;
    public Vector3 metaPinkyPos;
    public Vector3 wristPos;
    public Quaternion wristRot;

    public Vector3 palmPos;
    public quaternion palmRot;
    public quaternion indexKnuckleRot;
    public quaternion indexTipRot;
    public quaternion indexMiddleRot;
    /*public quaternion palmPos;*/

    LineRenderer lineRenderer;

    // Thumb
    GameObject thumbTipObject;
    GameObject thumbDistalObject;
    GameObject thumbProximalObject;

    // Index
    GameObject indexTipObject;
    GameObject indexDistalObject;
    GameObject indexMiddleObject;
    GameObject indexKnuckleObject;

    // Middle
    GameObject middleTipObject;
    GameObject middleDistalObject;
    GameObject middleMiddleObject;
    GameObject middleKnuckleObject;

    // Ring
    GameObject ringTipObject;
    GameObject ringDistalObject;
    GameObject ringMiddleObject;
    GameObject ringKnuckleObject;

    //Pinky
    GameObject pinkyTipObject;
    GameObject pinkyDistalObject;
    GameObject pinkyMiddleObject;
    GameObject pinkyKnuckleObject;

    // Metacarpals
    GameObject metaThumbObject;
    GameObject metaIndexObject;
    GameObject metaMiddleObject;
    GameObject metaRingObject;
    GameObject metaPinkyObject;

    // Wrist
    GameObject wristObject;

    // Palm
    GameObject palmObject;

    public Vector3 calibrateIndexKnuckle;
    public Vector3 calibrateWrist;
    public float calibrateDiff;
    public int initialCal;
    public int redoCal;

    public int HandUsed; // 1 if right hand, 2 is left hand; default as 1 for now
    public int tempHandUsed; // store hand as temporary so can detect if it changes from left to right hand
    public int HandSwitchCounter;

    public void Calibrate()
    {
        calibrateIndexKnuckle = indexKnucklePos;
        calibrateWrist = wristPos;
        calibrateDiff = Mathf.Sqrt(Mathf.Pow(calibrateIndexKnuckle.x - calibrateWrist.x,2)
                        + Mathf.Pow(calibrateIndexKnuckle.y - calibrateWrist.y,2)
                        + Mathf.Pow(calibrateIndexKnuckle.z -  calibrateWrist.z,2));
        if (calibrateDiff < 0.001)
        {
            initialCal = 0;
            redoCal = 1;
        }
        if (calibrateDiff > 0.001)
        {
            initialCal = 1;
            redoCal = 0;
            CalibrationPrompt.CalibrationPromptOff();
            ChooseTargetPrompt.ChooseTargetOn();
            RepetitionPrompt.RepetitionPromptOn();

        }

    }

    

    MixedRealityPose pose;
    MixedRealityPose rotation;

    List<string> updatepositions = new List<string>();
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        HandUsed = 0;

        // Thumb
        thumbTipObject = Instantiate(sphereMarker, this.transform);
        thumbDistalObject = Instantiate(sphereMarker, this.transform);
        thumbProximalObject = Instantiate(sphereMarker, this.transform);

        // Index
        indexTipObject = Instantiate(sphereMarker, this.transform);
        indexDistalObject = Instantiate(sphereMarker, this.transform);
        indexMiddleObject = Instantiate(sphereMarker, this.transform);
        indexKnuckleObject = Instantiate(sphereMarker, this.transform);

        // Middle
        middleTipObject = Instantiate(sphereMarker, this.transform);
        middleDistalObject = Instantiate(sphereMarker, this.transform);
        middleMiddleObject = Instantiate(sphereMarker, this.transform);
        middleKnuckleObject = Instantiate(sphereMarker, this.transform);

        // Ring
        ringTipObject = Instantiate(sphereMarker, this.transform);
        ringDistalObject = Instantiate(sphereMarker, this.transform);
        ringMiddleObject = Instantiate(sphereMarker, this.transform);
        ringKnuckleObject = Instantiate(sphereMarker, this.transform);

        // Pinky
        pinkyTipObject = Instantiate(sphereMarker, this.transform);
        pinkyDistalObject = Instantiate(sphereMarker, this.transform);
        pinkyMiddleObject = Instantiate(sphereMarker, this.transform);
        pinkyKnuckleObject = Instantiate(sphereMarker, this.transform);

        // Metacarpals
        metaThumbObject = Instantiate(sphereMarker, this.transform);
        metaIndexObject = Instantiate(sphereMarker, this.transform);
        metaMiddleObject = Instantiate(sphereMarker, this.transform);
        metaRingObject = Instantiate(sphereMarker, this.transform);
        metaPinkyObject = Instantiate(sphereMarker, this.transform);

        // Wrist
        wristObject = Instantiate(sphereMarker, this.transform);

        // Palm
        palmObject = Instantiate(squareMarker, this.transform);

    }

    // Update is called once per frame
    void Update()
    {
        if (HandUsed > 0)
        {
            
            if(tempHandUsed != HandUsed)
            {
                //HandSwitchCounter = HandSwitchCounter + 1;

                // call function to redraw target postures...maybe call these at different times...can't call them all at once
                TipPinch.HandSwitch();
                RegTipPinch.HandSwitch();
                LargeDiameter.HandSwitch();
                RegLargeDiameter.HandSwitch();
                Lateral.HandSwitch();
                RegLateral.HandSwitch();

            
                //TipPinch.postureState = 1;
                //TipPinch.calibrateState = 0;
                //TipPinch.waitKey = 0;

            }       
            tempHandUsed = HandUsed;
        }

        // Debug.Log(arCamera.worldToCameraMatrix.ToString());
        

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 47;


        // Thumb
        thumbTipObject.GetComponent<Renderer>().enabled = false;
        thumbDistalObject.GetComponent<Renderer>().enabled = false;
        thumbProximalObject.GetComponent<Renderer>().enabled = false;

        // Index
        indexTipObject.GetComponent<Renderer>().enabled = false;
        indexDistalObject.GetComponent<Renderer>().enabled = false;
        indexMiddleObject.GetComponent<Renderer>().enabled = false;
        indexKnuckleObject.GetComponent<Renderer>().enabled = false;

        // Middle
        middleTipObject.GetComponent<Renderer>().enabled = false;
        middleDistalObject.GetComponent<Renderer>().enabled = false;
        middleMiddleObject.GetComponent<Renderer>().enabled = false;
        middleKnuckleObject.GetComponent<Renderer>().enabled = false;

        // Ring
        ringTipObject.GetComponent<Renderer>().enabled = false;
        ringDistalObject.GetComponent<Renderer>().enabled = false;
        ringMiddleObject.GetComponent<Renderer>().enabled = false;
        ringKnuckleObject.GetComponent<Renderer>().enabled = false;

        // Pinky
        pinkyTipObject.GetComponent<Renderer>().enabled = false;
        pinkyDistalObject.GetComponent<Renderer>().enabled = false;
        pinkyMiddleObject.GetComponent<Renderer>().enabled = false;
        pinkyKnuckleObject.GetComponent<Renderer>().enabled = false;

        // Metacarpals
        metaThumbObject.GetComponent<Renderer>().enabled = false;
        metaIndexObject.GetComponent<Renderer>().enabled = false;
        metaMiddleObject.GetComponent<Renderer>().enabled = false;
        metaRingObject.GetComponent<Renderer>().enabled = false;
        metaPinkyObject.GetComponent<Renderer>().enabled = false;

        // Wrist
        wristObject.GetComponent<Renderer>().enabled = false;

        // Palm
        palmObject.GetComponent<Renderer>().enabled = false;



        // Draw joint positions /////////////////////////////////////////
        // Determine what hand they are using... will be easiest by voice... but just put in some code toggling handedness for now

        if (HandUsed == 1)
        {
            // Thumb

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out pose))
            {
                thumbTipObject.GetComponent<Renderer>().enabled = true;
                thumbTipObject.transform.position = pose.Position;
                thumbTipPos = pose.Position;

                thumbTipObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbDistalJoint, Handedness.Right, out pose))
            {
                thumbDistalObject.GetComponent<Renderer>().enabled = true;
                thumbDistalObject.transform.position = pose.Position;
                thumbDistalPos = pose.Position;

                thumbDistalObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbProximalJoint, Handedness.Right, out pose))
            {
                thumbProximalObject.GetComponent<Renderer>().enabled = true;
                thumbProximalObject.transform.position = pose.Position;
                thumbProximalPos = pose.Position;

                thumbProximalObject.transform.rotation = pose.Rotation;
            }

            // Index

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
            {
                indexTipObject.GetComponent<Renderer>().enabled = true;
                indexTipObject.transform.position = pose.Position;
                indexTipPos = pose.Position;
                indexTipRot = pose.Rotation;
    /*            indexTest = pose.Rotation;
    */
                indexTipObject.transform.rotation = pose.Rotation;

            }

        
            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexDistalJoint, Handedness.Right, out pose))
            {
                indexDistalObject.GetComponent<Renderer>().enabled = true;
                indexDistalObject.transform.position = pose.Position;
                indexDistalPos = pose.Position;

                indexDistalObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMiddleJoint, Handedness.Right, out pose))
            {
                indexMiddleObject.GetComponent<Renderer>().enabled = true;
                indexMiddleObject.transform.position = pose.Position;
                indexMiddlePos = pose.Position;
                indexMiddleRot = pose.Rotation;

                indexMiddleObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexKnuckle, Handedness.Right, out pose))
            {
                indexKnuckleObject.GetComponent<Renderer>().enabled = true;
                indexKnuckleObject.transform.position = pose.Position;
                indexKnucklePos = pose.Position;
                indexKnuckleRot = pose.Rotation;

                indexKnuckleObject.transform.rotation = pose.Rotation;
            }
            // Middle

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out pose))
            {
                middleTipObject.GetComponent<Renderer>().enabled = true;
                middleTipObject.transform.position = pose.Position;
                middleTipPos = pose.Position;

                middleTipObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleDistalJoint, Handedness.Right, out pose))
            {
                middleDistalObject.GetComponent<Renderer>().enabled = true;
                middleDistalObject.transform.position = pose.Position;
                middleDistalPos = pose.Position;

                middleDistalObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMiddleJoint, Handedness.Right, out pose))
            {
                middleMiddleObject.GetComponent<Renderer>().enabled = true;
                middleMiddleObject.transform.position = pose.Position;
                middleMiddlePos = pose.Position;

                middleMiddleObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleKnuckle, Handedness.Right, out pose))
            {
                middleKnuckleObject.GetComponent<Renderer>().enabled = true;
                middleKnuckleObject.transform.position = pose.Position;
                middleKnucklePos = pose.Position;

                middleKnuckleObject.transform.rotation = pose.Rotation;
            }

            // Ring

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out pose))
            {
                ringTipObject.GetComponent<Renderer>().enabled = true;
                ringTipObject.transform.position = pose.Position;
                ringTipPos = pose.Position;

                ringTipObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingDistalJoint, Handedness.Right, out pose))
            {
                ringDistalObject.GetComponent<Renderer>().enabled = true;
                ringDistalObject.transform.position = pose.Position;
                ringDistalPos = pose.Position;

                ringDistalObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMiddleJoint, Handedness.Right, out pose))
            {
                ringMiddleObject.GetComponent<Renderer>().enabled = true;
                ringMiddleObject.transform.position = pose.Position;
                ringMiddlePos = pose.Position;

                ringMiddleObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingKnuckle, Handedness.Right, out pose))
            {
                ringKnuckleObject.GetComponent<Renderer>().enabled = true;
                ringKnuckleObject.transform.position = pose.Position;
                ringKnucklePos = pose.Position;

                ringKnuckleObject.transform.rotation = pose.Rotation;
            }

            // Pinky
            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out pose))
            {
                pinkyTipObject.GetComponent<Renderer>().enabled = true;
                pinkyTipObject.transform.position = pose.Position;
                pinkyTipPos = pose.Position;

                pinkyTipObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyDistalJoint, Handedness.Right, out pose))
            {
                pinkyDistalObject.GetComponent<Renderer>().enabled = true;
                pinkyDistalObject.transform.position = pose.Position;
                pinkyDistalPos = pose.Position;

                pinkyDistalObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMiddleJoint, Handedness.Right, out pose))
            {
                pinkyMiddleObject.GetComponent<Renderer>().enabled = true;
                pinkyMiddleObject.transform.position = pose.Position;
                pinkyMiddlePos = pose.Position;

                pinkyMiddleObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyKnuckle, Handedness.Right, out pose))
            {
                pinkyKnuckleObject.GetComponent<Renderer>().enabled = true;
                pinkyKnuckleObject.transform.position = pose.Position;
                pinkyKnucklePos = pose.Position;

                pinkyKnuckleObject.transform.rotation = pose.Rotation;

            }

            // Metacarpals

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbMetacarpalJoint, Handedness.Right, out pose))
            {
                metaThumbObject.GetComponent<Renderer>().enabled = true;
                metaThumbObject.transform.position = pose.Position;
                metaThumbPos = pose.Position;

                metaThumbObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMetacarpal, Handedness.Right, out pose))
            {
                metaIndexObject.GetComponent<Renderer>().enabled = true;
                metaIndexObject.transform.position = pose.Position;
                metaIndexPos = pose.Position;

                metaIndexObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMetacarpal, Handedness.Right, out pose))
            {
                metaMiddleObject.GetComponent<Renderer>().enabled = true;
                metaMiddleObject.transform.position = pose.Position;
                metaMiddlePos = pose.Position;

                metaMiddleObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMetacarpal, Handedness.Right, out pose))
            {
                metaRingObject.GetComponent<Renderer>().enabled = true;
                metaRingObject.transform.position = pose.Position;
                metaRingPos = pose.Position;

                metaRingObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMetacarpal, Handedness.Right, out pose))
            {
                metaPinkyObject.GetComponent<Renderer>().enabled = true;
                metaPinkyObject.transform.position = pose.Position;
                metaPinkyPos = pose.Position;

                metaPinkyObject.transform.rotation = pose.Rotation;
            }
            // Wrist

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Right, out pose))
            {
                wristObject.GetComponent<Renderer>().enabled = true;
                wristObject.transform.position = pose.Position;
                wristPos = pose.Position;
                wristObject.transform.rotation = pose.Rotation;
                wristRot = pose.Rotation;

            }

            // Palm

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Right, out pose))
            {
                palmObject.GetComponent<Renderer>().enabled = true;
                palmObject.transform.position = pose.Position;
                palmObject.transform.rotation = pose.Rotation;
                palmPos = pose.Position;
                palmRot = pose.Rotation;
            }
        }

        else if (HandUsed == 2)
        {
            // Thumb

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out pose))
            {
                thumbTipObject.GetComponent<Renderer>().enabled = true;
                thumbTipObject.transform.position = pose.Position;
                thumbTipPos = pose.Position;

                thumbTipObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbDistalJoint, Handedness.Left, out pose))
            {
                thumbDistalObject.GetComponent<Renderer>().enabled = true;
                thumbDistalObject.transform.position = pose.Position;
                thumbDistalPos = pose.Position;

                thumbDistalObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbProximalJoint, Handedness.Left, out pose))
            {
                thumbProximalObject.GetComponent<Renderer>().enabled = true;
                thumbProximalObject.transform.position = pose.Position;
                thumbProximalPos = pose.Position;

                thumbProximalObject.transform.rotation = pose.Rotation;
            }

            // Index

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out pose))
            {
                indexTipObject.GetComponent<Renderer>().enabled = true;
                indexTipObject.transform.position = pose.Position;
                indexTipPos = pose.Position;
                indexTipRot = pose.Rotation;
                /*            indexTest = pose.Rotation;
                */
                indexTipObject.transform.rotation = pose.Rotation;

            }


            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexDistalJoint, Handedness.Left, out pose))
            {
                indexDistalObject.GetComponent<Renderer>().enabled = true;
                indexDistalObject.transform.position = pose.Position;
                indexDistalPos = pose.Position;

                indexDistalObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMiddleJoint, Handedness.Left, out pose))
            {
                indexMiddleObject.GetComponent<Renderer>().enabled = true;
                indexMiddleObject.transform.position = pose.Position;
                indexMiddlePos = pose.Position;
                indexMiddleRot = pose.Rotation;

                indexMiddleObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexKnuckle, Handedness.Left, out pose))
            {
                indexKnuckleObject.GetComponent<Renderer>().enabled = true;
                indexKnuckleObject.transform.position = pose.Position;
                indexKnucklePos = pose.Position;
                indexKnuckleRot = pose.Rotation;

                indexKnuckleObject.transform.rotation = pose.Rotation;
            }
            // Middle

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out pose))
            {
                middleTipObject.GetComponent<Renderer>().enabled = true;
                middleTipObject.transform.position = pose.Position;
                middleTipPos = pose.Position;

                middleTipObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleDistalJoint, Handedness.Left, out pose))
            {
                middleDistalObject.GetComponent<Renderer>().enabled = true;
                middleDistalObject.transform.position = pose.Position;
                middleDistalPos = pose.Position;

                middleDistalObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMiddleJoint, Handedness.Left, out pose))
            {
                middleMiddleObject.GetComponent<Renderer>().enabled = true;
                middleMiddleObject.transform.position = pose.Position;
                middleMiddlePos = pose.Position;

                middleMiddleObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleKnuckle, Handedness.Left, out pose))
            {
                middleKnuckleObject.GetComponent<Renderer>().enabled = true;
                middleKnuckleObject.transform.position = pose.Position;
                middleKnucklePos = pose.Position;

                middleKnuckleObject.transform.rotation = pose.Rotation;
            }

            // Ring

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out pose))
            {
                ringTipObject.GetComponent<Renderer>().enabled = true;
                ringTipObject.transform.position = pose.Position;
                ringTipPos = pose.Position;

                ringTipObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingDistalJoint, Handedness.Left, out pose))
            {
                ringDistalObject.GetComponent<Renderer>().enabled = true;
                ringDistalObject.transform.position = pose.Position;
                ringDistalPos = pose.Position;

                ringDistalObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMiddleJoint, Handedness.Left, out pose))
            {
                ringMiddleObject.GetComponent<Renderer>().enabled = true;
                ringMiddleObject.transform.position = pose.Position;
                ringMiddlePos = pose.Position;

                ringMiddleObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingKnuckle, Handedness.Left, out pose))
            {
                ringKnuckleObject.GetComponent<Renderer>().enabled = true;
                ringKnuckleObject.transform.position = pose.Position;
                ringKnucklePos = pose.Position;

                ringKnuckleObject.transform.rotation = pose.Rotation;
            }

            // Pinky
            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out pose))
            {
                pinkyTipObject.GetComponent<Renderer>().enabled = true;
                pinkyTipObject.transform.position = pose.Position;
                pinkyTipPos = pose.Position;

                pinkyTipObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyDistalJoint, Handedness.Left, out pose))
            {
                pinkyDistalObject.GetComponent<Renderer>().enabled = true;
                pinkyDistalObject.transform.position = pose.Position;
                pinkyDistalPos = pose.Position;

                pinkyDistalObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMiddleJoint, Handedness.Left, out pose))
            {
                pinkyMiddleObject.GetComponent<Renderer>().enabled = true;
                pinkyMiddleObject.transform.position = pose.Position;
                pinkyMiddlePos = pose.Position;

                pinkyMiddleObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyKnuckle, Handedness.Left, out pose))
            {
                pinkyKnuckleObject.GetComponent<Renderer>().enabled = true;
                pinkyKnuckleObject.transform.position = pose.Position;
                pinkyKnucklePos = pose.Position;

                pinkyKnuckleObject.transform.rotation = pose.Rotation;

            }

            // Metacarpals

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbMetacarpalJoint, Handedness.Left, out pose))
            {
                metaThumbObject.GetComponent<Renderer>().enabled = true;
                metaThumbObject.transform.position = pose.Position;
                metaThumbPos = pose.Position;

                metaThumbObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMetacarpal, Handedness.Left, out pose))
            {
                metaIndexObject.GetComponent<Renderer>().enabled = true;
                metaIndexObject.transform.position = pose.Position;
                metaIndexPos = pose.Position;

                metaIndexObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMetacarpal, Handedness.Left, out pose))
            {
                metaMiddleObject.GetComponent<Renderer>().enabled = true;
                metaMiddleObject.transform.position = pose.Position;
                metaMiddlePos = pose.Position;

                metaMiddleObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMetacarpal, Handedness.Left, out pose))
            {
                metaRingObject.GetComponent<Renderer>().enabled = true;
                metaRingObject.transform.position = pose.Position;
                metaRingPos = pose.Position;

                metaRingObject.transform.rotation = pose.Rotation;
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMetacarpal, Handedness.Left, out pose))
            {
                metaPinkyObject.GetComponent<Renderer>().enabled = true;
                metaPinkyObject.transform.position = pose.Position;
                metaPinkyPos = pose.Position;

                metaPinkyObject.transform.rotation = pose.Rotation;
            }
            // Wrist

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Left, out pose))
            {
                wristObject.GetComponent<Renderer>().enabled = true;
                wristObject.transform.position = pose.Position;
                wristPos = pose.Position;
                wristObject.transform.rotation = pose.Rotation;
                wristRot = pose.Rotation;

            }

            // Palm

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Left, out pose))
            {
                palmObject.GetComponent<Renderer>().enabled = true;
                palmObject.transform.position = pose.Position;
                palmObject.transform.rotation = pose.Rotation;
                palmPos = pose.Position;
                palmRot = pose.Rotation;
            }
        }
        


        // Create variables for joint positions ////////////////////////////
        float[] thumbTipF = new float[3] { thumbTipPos.x, thumbTipPos.y, thumbTipPos.z };
        float[] thumbDistalF = new float[3] { thumbDistalPos.x, thumbDistalPos.y, thumbDistalPos.z };
        float[] thumbProximalF = new float[3] { thumbProximalPos.x, thumbProximalPos.y, thumbProximalPos.z };
        float[] metaThumbF = new float[3] { metaThumbPos.x, metaThumbPos.y, metaThumbPos.z };
        float[] indexTipF = new float[3] { indexTipPos.x, indexTipPos.y, indexTipPos.z };
        float[] indexDistalF = new float[3] { indexDistalPos.x, indexDistalPos.y, indexDistalPos.z };
        float[] indexMiddleF = new float[3] { indexMiddlePos.x, indexMiddlePos.y, indexMiddlePos.z };
        float[] indexKnuckleF = new float[3] { indexKnucklePos.x, indexKnucklePos.y, indexKnucklePos.z };
        float[] metaIndexF = new float[3] { metaIndexPos.x, metaIndexPos.y, metaIndexPos.z };
        float[] middleTipF = new float[3] { middleTipPos.x, middleTipPos.y, middleTipPos.z };
        float[] middleDistalF = new float[3] { middleDistalPos.x, middleDistalPos.y, middleDistalPos.z };
        float[] middleMiddleF = new float[3] { middleMiddlePos.x, middleMiddlePos.y, middleMiddlePos.z };
        float[] middleKnuckleF = new float[3] { middleKnucklePos.x, middleKnucklePos.y, middleKnucklePos.z };
        float[] metaMiddleF = new float[3] { metaMiddlePos.x, metaMiddlePos.y, metaMiddlePos.z };
        float[] ringTipF = new float[3] { ringTipPos.x, ringTipPos.y, ringTipPos.z };
        float[] ringDistalF = new float[3] { ringDistalPos.x, ringDistalPos.y, ringDistalPos.z };
        float[] ringMiddleF = new float[3] { ringMiddlePos.x, ringMiddlePos.y, ringMiddlePos.z };
        float[] ringKnuckleF = new float[3] { ringKnucklePos.x, ringKnucklePos.y, ringKnucklePos.z };
        float[] metaRingF = new float[3] { metaRingPos.x, metaRingPos.y, metaRingPos.z };
        float[] pinkyTipF = new float[3] { pinkyTipPos.x, pinkyTipPos.y, pinkyTipPos.z };
        float[] pinkyDistalF = new float[3] { pinkyDistalPos.x, pinkyDistalPos.y, pinkyDistalPos.z };
        float[] pinkyMiddleF = new float[3] { pinkyMiddlePos.x, pinkyMiddlePos.y, pinkyMiddlePos.z };
        float[] pinkyKnuckleF = new float[3] { pinkyKnucklePos.x, pinkyKnucklePos.y, pinkyKnucklePos.z };
        float[] metaPinkyF = new float[3] { metaPinkyPos.x, metaPinkyPos.y, metaPinkyPos.z };
        float[] wristF = new float[3] { wristPos.x, wristPos.y, wristPos.z };
        float[] palmF = new float[3] {palmPos.x, palmPos.y, palmPos.z };


        // Write everything to one array

        float[] AllPositions = thumbTipF.Concat(thumbDistalF).Concat(thumbProximalF).Concat(metaThumbF).Concat(indexTipF).
                                Concat(indexDistalF).Concat(indexMiddleF).Concat(indexKnuckleF).Concat(metaIndexF).Concat(middleTipF).
                                Concat(middleDistalF).Concat(middleMiddleF).Concat(middleKnuckleF).Concat(metaMiddleF).Concat(ringTipF).
                                Concat(ringDistalF).Concat(ringMiddleF).Concat(ringKnuckleF).Concat(metaRingF).Concat(pinkyTipF).
                                Concat(pinkyDistalF).Concat(pinkyMiddleF).Concat(pinkyKnuckleF).Concat(metaPinkyF).Concat(wristF).
                                Concat(palmF).ToArray();



        // Draw lines based on joint positions /////////////////////////////
        lineRenderer.SetPosition(0, thumbTipPos);
        lineRenderer.SetPosition(1, thumbDistalPos);
        lineRenderer.SetPosition(2, thumbProximalPos);
        lineRenderer.SetPosition(3, metaThumbPos);
        lineRenderer.SetPosition(4, wristPos);
        lineRenderer.SetPosition(5, wristPos);
        lineRenderer.SetPosition(6, metaIndexPos);
        lineRenderer.SetPosition(7, indexKnucklePos);
        lineRenderer.SetPosition(8, indexMiddlePos);
        lineRenderer.SetPosition(9, indexDistalPos);
        lineRenderer.SetPosition(10, indexTipPos);
        lineRenderer.SetPosition(11, indexTipPos);
        lineRenderer.SetPosition(12, indexDistalPos);
        lineRenderer.SetPosition(13, indexMiddlePos);
        lineRenderer.SetPosition(14, indexKnucklePos);
        lineRenderer.SetPosition(15, metaIndexPos);
        lineRenderer.SetPosition(16, wristPos);
        lineRenderer.SetPosition(17, wristPos);
        lineRenderer.SetPosition(18, metaMiddlePos);
        lineRenderer.SetPosition(19, middleKnucklePos);
        lineRenderer.SetPosition(20, middleMiddlePos);
        lineRenderer.SetPosition(21, middleDistalPos);
        lineRenderer.SetPosition(22, middleTipPos);
        lineRenderer.SetPosition(23, middleTipPos);
        lineRenderer.SetPosition(24, middleDistalPos);
        lineRenderer.SetPosition(25, middleMiddlePos);
        lineRenderer.SetPosition(26, middleKnucklePos);
        lineRenderer.SetPosition(27, metaMiddlePos);
        lineRenderer.SetPosition(28, wristPos);
        lineRenderer.SetPosition(29, wristPos);
        lineRenderer.SetPosition(30, metaRingPos);
        lineRenderer.SetPosition(31, ringKnucklePos);
        lineRenderer.SetPosition(32, ringMiddlePos);
        lineRenderer.SetPosition(33, ringDistalPos);
        lineRenderer.SetPosition(34, ringTipPos);
        lineRenderer.SetPosition(35, ringTipPos);
        lineRenderer.SetPosition(36, ringDistalPos);
        lineRenderer.SetPosition(37, ringMiddlePos);
        lineRenderer.SetPosition(38, ringKnucklePos);
        lineRenderer.SetPosition(39, metaRingPos);
        lineRenderer.SetPosition(40, wristPos);
        lineRenderer.SetPosition(41, wristPos);
        lineRenderer.SetPosition(42, metaPinkyPos);
        lineRenderer.SetPosition(43, pinkyKnucklePos);
        lineRenderer.SetPosition(44, pinkyMiddlePos);
        lineRenderer.SetPosition(45, pinkyDistalPos);
        lineRenderer.SetPosition(46, pinkyTipPos);
        
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.005f;



    }

}

