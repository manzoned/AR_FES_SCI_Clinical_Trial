using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;
using System.Linq;
using System.IO;
using System;
using System.Globalization;

public class HandTracking : MonoBehaviour

{


    public GameObject sphereMarker;
   
    LineRenderer lineRenderer;
   /* LineRenderer lineRenderer2;*/

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

    

    MixedRealityPose pose;

    List<string> updatepositions = new List<string>();
    int i = 0;
    /*List<string> updatetime = new List<string>();*/

    // Start is called before the first frame update
    void Start()
    {
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

       

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        i++;

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

        

        // Draw joint positions /////////////////////////////////////////



        // Thumb

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out pose))
        {
            thumbTipObject.GetComponent<Renderer>().enabled = true;
            thumbTipObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbDistalJoint, Handedness.Right, out pose))
        {
            thumbDistalObject.GetComponent<Renderer>().enabled = true;
            thumbDistalObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbProximalJoint, Handedness.Right, out pose))
        {
            thumbProximalObject.GetComponent<Renderer>().enabled = true;
            thumbProximalObject.transform.position = pose.Position;

        }

        // Index

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
        {
            indexTipObject.GetComponent<Renderer>().enabled = true;
            indexTipObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexDistalJoint, Handedness.Right, out pose))
        {
            indexDistalObject.GetComponent<Renderer>().enabled = true;
            indexDistalObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMiddleJoint, Handedness.Right, out pose))
        {
            indexMiddleObject.GetComponent<Renderer>().enabled = true;
            indexMiddleObject.transform.position = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexKnuckle, Handedness.Right, out pose))
        {
            indexKnuckleObject.GetComponent<Renderer>().enabled = true;
            indexKnuckleObject.transform.position = pose.Position;
        }
        // Middle

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out pose))
        {
            middleTipObject.GetComponent<Renderer>().enabled = true;
            middleTipObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleDistalJoint, Handedness.Right, out pose))
        {
            middleDistalObject.GetComponent<Renderer>().enabled = true;
            middleDistalObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMiddleJoint, Handedness.Right, out pose))
        {
            middleMiddleObject.GetComponent<Renderer>().enabled = true;
            middleMiddleObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleKnuckle, Handedness.Right, out pose))
        {
            middleKnuckleObject.GetComponent<Renderer>().enabled = true;
            middleKnuckleObject.transform.position = pose.Position;
        }

        // Ring

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out pose))
        {
            ringTipObject.GetComponent<Renderer>().enabled = true;
            ringTipObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingDistalJoint, Handedness.Right, out pose))
        {
            ringDistalObject.GetComponent<Renderer>().enabled = true;
            ringDistalObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMiddleJoint, Handedness.Right, out pose))
        {
            ringMiddleObject.GetComponent<Renderer>().enabled = true;
            ringMiddleObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingKnuckle, Handedness.Right, out pose))
        {
            ringKnuckleObject.GetComponent<Renderer>().enabled = true;
            ringKnuckleObject.transform.position = pose.Position;
        }

        // Pinky
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out pose))
        {
            pinkyTipObject.GetComponent<Renderer>().enabled = true;
            pinkyTipObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyDistalJoint, Handedness.Right, out pose))
        {
            pinkyDistalObject.GetComponent<Renderer>().enabled = true;
            pinkyDistalObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMiddleJoint, Handedness.Right, out pose))
        {
            pinkyMiddleObject.GetComponent<Renderer>().enabled = true;
            pinkyMiddleObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyKnuckle, Handedness.Right, out pose))
        {
            pinkyKnuckleObject.GetComponent<Renderer>().enabled = true;
            pinkyKnuckleObject.transform.position = pose.Position;
        }

        // Metacarpals

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbMetacarpalJoint, Handedness.Right, out pose))
        {
            metaThumbObject.GetComponent<Renderer>().enabled = true;
            metaThumbObject.transform.position = pose.Position;

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMetacarpal, Handedness.Right, out pose))
        {
            metaIndexObject.GetComponent<Renderer>().enabled = true;
            metaIndexObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMetacarpal, Handedness.Right, out pose))
        {
            metaMiddleObject.GetComponent<Renderer>().enabled = true;
            metaMiddleObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMetacarpal, Handedness.Right, out pose))
        {
            metaRingObject.GetComponent<Renderer>().enabled = true;
            metaRingObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMetacarpal, Handedness.Right, out pose))
        {
            metaPinkyObject.GetComponent<Renderer>().enabled = true;
            metaPinkyObject.transform.position = pose.Position;
        }
        // Wrist

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Right, out pose))
        {
            wristObject.GetComponent<Renderer>().enabled = true;
            wristObject.transform.position = pose.Position;

        }


        // Create variables for joint positions ////////////////////////////
        var thumbTipPos = thumbTipObject.transform.position; float[] thumbTipF = new float[3] { thumbTipPos.x, thumbTipPos.y, thumbTipPos.z };
        var thumbDistalPos = thumbDistalObject.transform.position; float[] thumbDistalF = new float[3] { thumbDistalPos.x, thumbDistalPos.y, thumbDistalPos.z };
        var thumbProximalPos = thumbProximalObject.transform.position; float[] thumbProximalF = new float[3] { thumbProximalPos.x, thumbProximalPos.y, thumbProximalPos.z };
        var metaThumbPos = metaThumbObject.transform.position; float[] metaThumbF = new float[3] { metaThumbPos.x, metaThumbPos.y, metaThumbPos.z };
        var indexTipPos = indexTipObject.transform.position; float[] indexTipF = new float[3] { indexTipPos.x, indexTipPos.y, indexTipPos.z };
        var indexDistalPos = indexDistalObject.transform.position; float[] indexDistalF = new float[3] { indexDistalPos.x, indexDistalPos.y, indexDistalPos.z };
        var indexMiddlePos = indexMiddleObject.transform.position; float[] indexMiddleF = new float[3] { indexMiddlePos.x, indexMiddlePos.y, indexMiddlePos.z };
        var indexKnucklePos = indexKnuckleObject.transform.position; float[] indexKnuckleF = new float[3] { indexKnucklePos.x, indexKnucklePos.y, indexKnucklePos.z };
        var metaIndexPos = metaIndexObject.transform.position; float[] metaIndexF = new float[3] { metaIndexPos.x, metaIndexPos.y, metaIndexPos.z };
        var middleTipPos = middleTipObject.transform.position; float[] middleTipF = new float[3] { middleTipPos.x, middleTipPos.y, middleTipPos.z };
        var middleDistalPos = middleDistalObject.transform.position; float[] middleDistalF = new float[3] { middleDistalPos.x, middleDistalPos.y, middleDistalPos.z };
        var middleMiddlePos = middleMiddleObject.transform.position; float[] middleMiddleF = new float[3] { middleMiddlePos.x, middleMiddlePos.y, middleMiddlePos.z };
        var middleKnucklePos = middleKnuckleObject.transform.position; float[] middleKnuckleF = new float[3] { middleKnucklePos.x, middleKnucklePos.y, middleKnucklePos.z };
        var metaMiddlePos = metaMiddleObject.transform.position; float[] metaMiddleF = new float[3] { metaMiddlePos.x, metaMiddlePos.y, metaMiddlePos.z };
        var ringTipPos = ringTipObject.transform.position; float[] ringTipF = new float[3] { ringTipPos.x, ringTipPos.y, ringTipPos.z };
        var ringDistalPos = ringDistalObject.transform.position; float[] ringDistalF = new float[3] { ringDistalPos.x, ringDistalPos.y, ringDistalPos.z };
        var ringMiddlePos = ringMiddleObject.transform.position; float[] ringMiddleF = new float[3] { ringMiddlePos.x, ringMiddlePos.y, ringMiddlePos.z };
        var ringKnucklePos = ringKnuckleObject.transform.position; float[] ringKnuckleF = new float[3] { ringKnucklePos.x, ringKnucklePos.y, ringKnucklePos.z };
        var metaRingPos = metaRingObject.transform.position; float[] metaRingF = new float[3] { metaRingPos.x, metaRingPos.y, metaRingPos.z };
        var pinkyTipPos = pinkyTipObject.transform.position; float[] pinkyTipF = new float[3] { pinkyTipPos.x, pinkyTipPos.y, pinkyTipPos.z };
        var pinkyDistalPos = pinkyDistalObject.transform.position; float[] pinkyDistalF = new float[3] { pinkyDistalPos.x, pinkyDistalPos.y, pinkyDistalPos.z };
        var pinkyMiddlePos = pinkyMiddleObject.transform.position; float[] pinkyMiddleF = new float[3] { pinkyMiddlePos.x, pinkyMiddlePos.y, pinkyMiddlePos.z };
        var pinkyKnucklePos = pinkyKnuckleObject.transform.position; float[] pinkyKnuckleF = new float[3] { pinkyKnucklePos.x, pinkyKnucklePos.y, pinkyKnucklePos.z };
        var metaPinkyPos = metaPinkyObject.transform.position; float[] metaPinkyF = new float[3] { metaPinkyPos.x, metaPinkyPos.y, metaPinkyPos.z };
        var wristPos = wristObject.transform.position; float[] wristF = new float[3] { wristPos.x, wristPos.y, wristPos.z };

        // Write everything to one array

        float[] AllPositions = thumbTipF.Concat(thumbDistalF).Concat(thumbProximalF).Concat(metaThumbF).Concat(indexTipF).
                                Concat(indexDistalF).Concat(indexMiddleF).Concat(indexKnuckleF).Concat(metaIndexF).Concat(middleTipF).
                                Concat(middleDistalF).Concat(middleMiddleF).Concat(middleKnuckleF).Concat(metaMiddleF).Concat(ringTipF).
                                Concat(ringDistalF).Concat(ringMiddleF).Concat(ringKnuckleF).Concat(metaRingF).Concat(pinkyTipF).
                                Concat(pinkyDistalF).Concat(pinkyMiddleF).Concat(pinkyKnuckleF).Concat(metaPinkyF).Concat(wristF).ToArray();

        // convert it all to one string
        string AllPositionsString = String.Join(" ", AllPositions.Select(f => f.ToString(CultureInfo.CurrentCulture)));
        // append new positions to list on each frame
        updatepositions.Add(AllPositionsString);
        string combinedstring = String.Join("\n", updatepositions);
        // save it to a text file on each frame    
        System.IO.File.WriteAllText("C:\\Users\\manzond\\Downloads\\test.txt", combinedstring);

        /*        float time = Time.time;
                string timestring = String.Join(" ", time.ToString(CultureInfo.CurrentCulture));
                updatetime.Add(timestring);
                string combinedtime = String.Join("\n", updatetime);
                System.IO.File.WriteAllText("C:\\Users\\manzond\\Downloads\\time.txt", combinedtime);*/

        //Debug.Log(i);

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

        if (Input.GetKey(KeyCode.Escape))
        {
            var thumbtest = thumbTipPos;
            Debug.Log(thumbtest);

        }

/*        if (Input.GetKeyDown("f"))
        {

            lineRenderer2 = GetComponent<LineRenderer>();
            lineRenderer2.startWidth = 0.01f;
            lineRenderer2.endWidth = 0.01f;
            lineRenderer2.positionCount = 47;

            StartCoroutine(StopPose());
            Debug.Log("key was pressed");
        }

        IEnumerator StopPose()
        {
            lineRenderer2.SetPosition(0, thumbTipPos);
            lineRenderer2.SetPosition(1, thumbDistalPos);
            lineRenderer2.SetPosition(2, thumbProximalPos);
            yield return null;
        }*/



    }

}

