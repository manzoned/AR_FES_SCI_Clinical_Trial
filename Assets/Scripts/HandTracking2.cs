using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;
using System.Linq;
using System;
using Unity.VisualScripting;

public class HandTracking2 : MonoBehaviour

{
    public Camera arCamera;

    public GameObject sphereMarker;
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

    LineRenderer lineRenderer;

    MixedRealityPose pose;

    List<string> updatepositions = new List<string>();
    int i = 0;

    Dictionary<HandJoints2, GameObject> handJointObjects = new Dictionary<HandJoints2, GameObject>();
 //   Dictionary<HandJoints2, Vector3> handJointPos = new Dictionary<HandJoints2, Vector3>();

    // Start is called before the first frame update
    void Start()
    {

/*        foreach (HandJoints2 joint in Enum.GetValues(typeof(HandJoints)))
        {
            Debug.Log($"Current joint is {joint}");
        }*/

        foreach (HandJoints2 joint in Enum.GetValues(typeof(HandJoints)))
        {
            handJointObjects.Add(joint, Instantiate(sphereMarker, this.transform));
            
        }

    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log(arCamera.worldToCameraMatrix.ToString());

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 47;

        foreach (HandJoints2 joint in Enum.GetValues(typeof(HandJoints)))
        {
            handJointObjects[joint].GetComponent<Renderer>().enabled = false;
        }

        // Draw joint positions /////////////////////////////////////////

        // Thumb

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.thumbTipObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.thumbTipObject].transform.position = pose.Position;
            thumbTipPos = pose.Position;


        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbDistalJoint, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.thumbDistalObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.thumbDistalObject].transform.position = pose.Position;
            thumbDistalPos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbProximalJoint, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.thumbProximalObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.thumbProximalObject].transform.position = pose.Position;
            thumbProximalPos = pose.Position;

        }

        // Index

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.indexTipObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.indexTipObject].transform.position = pose.Position;
            indexTipPos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexDistalJoint, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.indexDistalObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.indexDistalObject].transform.position = pose.Position;
            indexDistalPos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMiddleJoint, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.indexMiddleObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.indexMiddleObject].transform.position = pose.Position;
            indexMiddlePos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexKnuckle, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.indexKnuckleObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.indexKnuckleObject].transform.position = pose.Position;
            indexKnucklePos = pose.Position;

        }
        // Middle

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.middleTipObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.middleTipObject].transform.position = pose.Position;
            middleTipPos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleDistalJoint, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.middleDistalObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.middleDistalObject].transform.position = pose.Position;
            middleDistalPos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMiddleJoint, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.middleMiddleObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.middleMiddleObject].transform.position = pose.Position;
            middleMiddlePos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleKnuckle, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.middleKnuckleObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.middleKnuckleObject].transform.position = pose.Position;
            middleKnucklePos = pose.Position;

        }

        // Ring

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.ringTipObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.ringTipObject].transform.position = pose.Position;
            ringTipPos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingDistalJoint, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.ringDistalObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.ringDistalObject].transform.position = pose.Position;
            ringDistalPos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMiddleJoint, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.ringMiddleObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.ringMiddleObject].transform.position = pose.Position;
            ringMiddlePos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingKnuckle, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.ringKnuckleObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.ringKnuckleObject].transform.position = pose.Position;
            ringKnucklePos = pose.Position;

        }

        // Pinky
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.pinkyTipObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.pinkyTipObject].transform.position = pose.Position;
            pinkyTipPos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyDistalJoint, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.pinkyDistalObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.pinkyDistalObject].transform.position = pose.Position;
            pinkyDistalPos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMiddleJoint, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.pinkyMiddleObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.pinkyMiddleObject].transform.position = pose.Position;
            pinkyMiddlePos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyKnuckle, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.pinkyKnuckleObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.pinkyKnuckleObject].transform.position = pose.Position;
            pinkyKnucklePos = pose.Position;

        }

        // Metacarpals

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbMetacarpalJoint, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.metaThumbObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.metaThumbObject].transform.position = pose.Position;
            metaThumbPos = pose.Position;


        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMetacarpal, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.metaIndexObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.metaIndexObject].transform.position = pose.Position;
            metaIndexPos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMetacarpal, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.metaMiddleObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.metaMiddleObject].transform.position = pose.Position;
            metaMiddlePos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMetacarpal, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.metaRingObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.metaRingObject].transform.position = pose.Position;
            metaRingPos = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMetacarpal, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.metaPinkyObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.metaPinkyObject].transform.position = pose.Position;
            metaPinkyPos = pose.Position;

        }
        // Wrist

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Right, out pose))
        {
            handJointObjects[HandJoints2.wristObject].GetComponent<Renderer>().enabled = true;
            handJointObjects[HandJoints2.wristObject].transform.position = pose.Position;
            wristPos = pose.Position;

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


        // Write everything to one array

        float[] AllPositions = thumbTipF.Concat(thumbDistalF).Concat(thumbProximalF).Concat(metaThumbF).Concat(indexTipF).
                                Concat(indexDistalF).Concat(indexMiddleF).Concat(indexKnuckleF).Concat(metaIndexF).Concat(middleTipF).
                                Concat(middleDistalF).Concat(middleMiddleF).Concat(middleKnuckleF).Concat(metaMiddleF).Concat(ringTipF).
                                Concat(ringDistalF).Concat(ringMiddleF).Concat(ringKnuckleF).Concat(metaRingF).Concat(pinkyTipF).
                                Concat(pinkyDistalF).Concat(pinkyMiddleF).Concat(pinkyKnuckleF).Concat(metaPinkyF).Concat(wristF).ToArray();



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



    }

}

