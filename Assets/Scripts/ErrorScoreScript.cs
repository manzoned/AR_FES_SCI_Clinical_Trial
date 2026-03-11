using JetBrains.Annotations;
using Microsoft.MixedReality.Toolkit.Utilities;
//using NUnit.Framework.Internal.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class ErrorScoreScript : MonoBehaviour
{
    // text inputs
    public TextMeshProUGUI distance_output;
    public TextMeshProUGUI angle_output;
    

    // reference actual saved positions
    public ThumbTipPos ThumbTipPos;
    public ThumbDistalPos ThumbDistalPos;
    public ThumbProximalPos ThumbProximalPos;
    public MetaThumbPos MetaThumbPos;
    public IndexTipPos IndexTipPos;
    public IndexDistalPos IndexDistalPos;
    public IndexMiddlePos IndexMiddlePos;
    public IndexKnucklePos IndexKnucklePos;
    public MetaIndexPos MetaIndexPos;
    public MiddleTipPos MiddleTipPos;
    public MiddleDistalPos MiddleDistalPos;
    public MiddleMiddlePos MiddleMiddlePos;
    public MiddleKnucklePos MiddleKnucklePos;
    public MetaMiddlePos MetaMiddlePos;
    public RingTipPos RingTipPos;
    public RingDistalPos RingDistalPos;
    public RingMiddlePos RingMiddlePos;
    public RingKnucklePos RingKnucklePos;
    public MetaRingPos MetaRingPos;
    public PinkyTipPos PinkyTipPos;
    public PinkyDistalPos PinkyDistalPos;
    public PinkyMiddlePos PinkyMiddlePos;
    public PinkyKnucklePos PinkyKnucklePos;
    public MetaPinkyPos MetaPinkyPos;
    public WristPos WristPos;

    // reference target positions
    public TargetThumbTipPos TargetThumbTipPos;
    public TargetThumbDistalPos TargetThumbDistalPos;
    public TargetThumbProximalPos TargetThumbProximalPos;
    public TargetMetaThumbPos TargetMetaThumbPos;
    public TargetIndexTipPos TargetIndexTipPos;
    public TargetIndexDistalPos TargetIndexDistalPos;
    public TargetIndexMiddlePos TargetIndexMiddlePos;
    public TargetIndexKnucklePos TargetIndexKnucklePos;
    public TargetMetaIndexPos TargetMetaIndexPos;
    public TargetMiddleTipPos TargetMiddleTipPos;
    public TargetMiddleDistalPos TargetMiddleDistalPos;
    public TargetMiddleMiddlePos TargetMiddleMiddlePos;
    public TargetMiddleKnucklePos TargetMiddleKnucklePos;
    public TargetMetaMiddlePos TargetMetaMiddlePos;
    public TargetRingTipPos TargetRingTipPos;
    public TargetRingDistalPos TargetRingDistalPos;
    public TargetRingMiddlePos TargetRingMiddlePos;
    public TargetRingKnucklePos TargetRingKnucklePos;
    public TargetMetaRingPos TargetMetaRingPos;
    public TargetPinkyTipPos TargetPinkyTipPos;
    public TargetPinkyDistalPos TargetPinkyDistalPos;
    public TargetPinkyMiddlePos TargetPinkyMiddlePos;
    public TargetPinkyKnucklePos TargetPinkyKnucklePos;
    public TargetMetaPinkyPos TargetMetaPinkyPos;
    public TargetWristPos TargetWristPos;

    // private joint distances

    private float ThumbTipDiff;
    private float ThumbDistalDiff;
    private float ThumbProximalDiff;
    private float MetaThumbDiff;
    private float IndexTipDiff;
    private float IndexDistalDiff;
    private float IndexMiddleDiff;
    private float IndexKnuckleDiff;
    private float MetaIndexDiff;
    private float MiddleTipDiff;
    private float MiddleDistalDiff;
    private float MiddleMiddleDiff;
    private float MiddleKnuckleDiff;
    private float MetaMiddleDiff;
    private float RingTipDiff;
    private float RingDistalDiff;
    private float RingMiddleDiff;
    private float RingKnuckleDiff;
    private float MetaRingDiff;
    private float PinkyTipDiff;
    private float PinkyDistalDiff;
    private float PinkyMiddleDiff;
    private float PinkyKnuckleDiff;
    private float MetaPinkyDiff;
    private float WristPosDiff;

    // private joint angle differences

    private float ThumbKnuckleAngleDiff;
    private float ThumbDistalAngleDiff;
    private float IndexKnuckleAngleDiff;
    private float IndexDistalAngleDiff;
    private float IndexMiddleAngleDiff;
    private float MiddleKnuckleAngleDiff;
    private float MiddleDistalAngleDiff;
    private float MiddleMiddleAngleDiff;
    private float RingKnuckleAngleDiff;
    private float RingDistalAngleDiff;
    private float RingMiddleAngleDiff;
    private float PinkyKnuckleAngleDiff;
    private float PinkyDistalAngleDiff;
    private float PinkyMiddleAngleDiff;
    //private float WristAngleDiff; // need to figure out this calculation first

    // calculated variables
    public float MeanDiff;
    public float MaxJointDiff;
    public string MaxJointDiffName;
    public float MedianJointDiff;
    public string MedianJointDiffName;

    public float MeanAngleDiff;
    public float MaxJointAngleDiff;
    public string MaxJointAngleDiffName;
    public float MedianJointAngleDiff;
    public string MedianJointAngleDiffName;

    class Joint
    {
        public string JointDiffName { get; set; }
        public float JointDiffValue { get; set; }
    }
    class JointAngle
    {
        public string JointAngleName { get; set; }
        public float JointAngleValue { get; set; }
    }

    private int positionset;
    private float DiffSum;
    private float JointCount;
    private string angle_text;
    //Dictionary<ActualHandJoints, ActualHandJoints> ActualHandJoints = new Dictionary<ActualHandJoints, ActualHandJoints>();
    // Dictionary<TargetHandJoints, float> TargetHandJoints = new Dictionary<TargetHandJoints, float>();
    //Dictionary<JointDiff, float> JointDiffFloats = new Dictionary<JointDiff, float>();

    // Start is called before the first frame update
    void Start()
    {
        positionset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        /////////////////////////////////////////////////////////////////////////////
        // calculate eclidean distance between actual joint and target joint position 


        ThumbTipDiff = Mathf.Sqrt(Mathf.Pow(ThumbTipPos.tempPosition.x - TargetThumbTipPos.tempPosition.x, 2)
            + Mathf.Pow(ThumbTipPos.tempPosition.y - TargetThumbTipPos.tempPosition.y, 2)
            + Mathf.Pow(ThumbTipPos.tempPosition.z - TargetThumbTipPos.tempPosition.z, 2));
        ThumbDistalDiff = Mathf.Sqrt(Mathf.Pow(ThumbDistalPos.tempPosition.x - TargetThumbDistalPos.tempPosition.x, 2)
            + Mathf.Pow(ThumbDistalPos.tempPosition.y - TargetThumbDistalPos.tempPosition.y, 2)
            + Mathf.Pow(ThumbDistalPos.tempPosition.z - TargetThumbDistalPos.tempPosition.z, 2));
        ThumbProximalDiff = Mathf.Sqrt(Mathf.Pow(ThumbProximalPos.tempPosition.x - TargetThumbProximalPos.tempPosition.x, 2)
            + Mathf.Pow(ThumbProximalPos.tempPosition.y - TargetThumbProximalPos.tempPosition.y, 2)
            + Mathf.Pow(ThumbProximalPos.tempPosition.z - TargetThumbProximalPos.tempPosition.z, 2));
        MetaThumbDiff = Mathf.Sqrt(Mathf.Pow(MetaThumbPos.tempPosition.x - TargetMetaThumbPos.tempPosition.x, 2)
            + Mathf.Pow(MetaThumbPos.tempPosition.y - TargetMetaThumbPos.tempPosition.y, 2)
            + Mathf.Pow(MetaThumbPos.tempPosition.z - TargetMetaThumbPos.tempPosition.z, 2));
        IndexTipDiff = Mathf.Sqrt(Mathf.Pow(IndexTipPos.tempPosition.x - TargetIndexTipPos.tempPosition.x, 2)
            + Mathf.Pow(IndexTipPos.tempPosition.y - TargetIndexTipPos.tempPosition.y, 2)
            + Mathf.Pow(IndexTipPos.tempPosition.z - TargetIndexTipPos.tempPosition.z, 2));
        IndexDistalDiff = Mathf.Sqrt(Mathf.Pow(IndexDistalPos.tempPosition.x - TargetIndexDistalPos.tempPosition.x, 2)
            + Mathf.Pow(IndexDistalPos.tempPosition.y - TargetIndexDistalPos.tempPosition.y, 2)
            + Mathf.Pow(IndexDistalPos.tempPosition.z - TargetIndexDistalPos.tempPosition.z, 2));
        IndexMiddleDiff = Mathf.Sqrt(Mathf.Pow(IndexMiddlePos.tempPosition.x - TargetIndexMiddlePos.tempPosition.x, 2)
            + Mathf.Pow(IndexMiddlePos.tempPosition.y - TargetIndexMiddlePos.tempPosition.y, 2)
            + Mathf.Pow(IndexMiddlePos.tempPosition.z - TargetIndexMiddlePos.tempPosition.z, 2));
        IndexKnuckleDiff = Mathf.Sqrt(Mathf.Pow(IndexKnucklePos.tempPosition.x - TargetIndexKnucklePos.tempPosition.x, 2)
            + Mathf.Pow(IndexKnucklePos.tempPosition.y - TargetIndexKnucklePos.tempPosition.y, 2)
            + Mathf.Pow(IndexKnucklePos.tempPosition.z - TargetIndexKnucklePos.tempPosition.z, 2));
        MetaIndexDiff = Mathf.Sqrt(Mathf.Pow(MetaIndexPos.tempPosition.x - TargetMetaIndexPos.tempPosition.x, 2)
            + Mathf.Pow(MetaIndexPos.tempPosition.y - TargetMetaIndexPos.tempPosition.y, 2)
            + Mathf.Pow(MetaIndexPos.tempPosition.z - TargetMetaIndexPos.tempPosition.z, 2));
        MiddleTipDiff = Mathf.Sqrt(Mathf.Pow(MiddleTipPos.tempPosition.x - TargetMiddleTipPos.tempPosition.x, 2)
            + Mathf.Pow(MiddleTipPos.tempPosition.y - TargetMiddleTipPos.tempPosition.y, 2)
            + Mathf.Pow(MiddleTipPos.tempPosition.z - TargetMiddleTipPos.tempPosition.z, 2));
        MiddleDistalDiff = Mathf.Sqrt(Mathf.Pow(MiddleDistalPos.tempPosition.x - TargetMiddleDistalPos.tempPosition.x, 2)
            + Mathf.Pow(MiddleDistalPos.tempPosition.y - TargetMiddleDistalPos.tempPosition.y, 2)
            + Mathf.Pow(MiddleDistalPos.tempPosition.z - TargetMiddleDistalPos.tempPosition.z, 2));
        MiddleMiddleDiff = Mathf.Sqrt(Mathf.Pow(MiddleMiddlePos.tempPosition.x - TargetMiddleMiddlePos.tempPosition.x, 2)
            + Mathf.Pow(MiddleMiddlePos.tempPosition.y - TargetMiddleMiddlePos.tempPosition.y, 2)
            + Mathf.Pow(MiddleMiddlePos.tempPosition.z - TargetMiddleMiddlePos.tempPosition.z, 2));
        MiddleKnuckleDiff = Mathf.Sqrt(Mathf.Pow(MiddleKnucklePos.tempPosition.x - TargetMiddleKnucklePos.tempPosition.x, 2)
            + Mathf.Pow(MiddleKnucklePos.tempPosition.y - TargetMiddleKnucklePos.tempPosition.y, 2)
            + Mathf.Pow(MiddleKnucklePos.tempPosition.z - TargetMiddleKnucklePos.tempPosition.z, 2));
        MetaMiddleDiff = Mathf.Sqrt(Mathf.Pow(MetaMiddlePos.tempPosition.x - TargetMetaMiddlePos.tempPosition.x, 2)
            + Mathf.Pow(MetaMiddlePos.tempPosition.y - TargetMetaMiddlePos.tempPosition.y, 2)
            + Mathf.Pow(MetaMiddlePos.tempPosition.z - TargetMetaMiddlePos.tempPosition.z, 2));
        RingTipDiff = Mathf.Sqrt(Mathf.Pow(RingTipPos.tempPosition.x - TargetRingTipPos.tempPosition.x, 2)
            + Mathf.Pow(RingTipPos.tempPosition.y - TargetRingTipPos.tempPosition.y, 2)
            + Mathf.Pow(RingTipPos.tempPosition.z - TargetRingTipPos.tempPosition.z, 2));
        RingDistalDiff = Mathf.Sqrt(Mathf.Pow(RingDistalPos.tempPosition.x - TargetRingDistalPos.tempPosition.x, 2)
            + Mathf.Pow(RingDistalPos.tempPosition.y - TargetRingDistalPos.tempPosition.y, 2)
            + Mathf.Pow(RingDistalPos.tempPosition.z - TargetRingDistalPos.tempPosition.z, 2));
        RingMiddleDiff = Mathf.Sqrt(Mathf.Pow(RingMiddlePos.tempPosition.x - TargetRingMiddlePos.tempPosition.x, 2)
            + Mathf.Pow(RingMiddlePos.tempPosition.y - TargetRingMiddlePos.tempPosition.y, 2)
            + Mathf.Pow(RingMiddlePos.tempPosition.z - TargetRingMiddlePos.tempPosition.z, 2));
        RingKnuckleDiff = Mathf.Sqrt(Mathf.Pow(RingKnucklePos.tempPosition.x - TargetRingKnucklePos.tempPosition.x, 2)
            + Mathf.Pow(RingKnucklePos.tempPosition.y - TargetRingKnucklePos.tempPosition.y, 2)
            + Mathf.Pow(RingKnucklePos.tempPosition.z - TargetRingKnucklePos.tempPosition.z, 2));
        MetaRingDiff = Mathf.Sqrt(Mathf.Pow(MetaRingPos.tempPosition.x - TargetMetaRingPos.tempPosition.x, 2)
            + Mathf.Pow(MetaRingPos.tempPosition.y - TargetMetaRingPos.tempPosition.y, 2)
            + Mathf.Pow(MetaRingPos.tempPosition.z - TargetMetaRingPos.tempPosition.z, 2));
        PinkyTipDiff = Mathf.Sqrt(Mathf.Pow(PinkyTipPos.tempPosition.x - TargetPinkyTipPos.tempPosition.x, 2)
            + Mathf.Pow(PinkyTipPos.tempPosition.y - TargetPinkyTipPos.tempPosition.y, 2)
            + Mathf.Pow(PinkyTipPos.tempPosition.z - TargetPinkyTipPos.tempPosition.z, 2));
        PinkyDistalDiff = Mathf.Sqrt(Mathf.Pow(PinkyDistalPos.tempPosition.x - TargetPinkyDistalPos.tempPosition.x, 2)
            + Mathf.Pow(PinkyDistalPos.tempPosition.y - TargetPinkyDistalPos.tempPosition.y, 2)
            + Mathf.Pow(PinkyDistalPos.tempPosition.z - TargetPinkyDistalPos.tempPosition.z, 2));
        PinkyMiddleDiff = Mathf.Sqrt(Mathf.Pow(PinkyMiddlePos.tempPosition.x - TargetPinkyMiddlePos.tempPosition.x, 2)
            + Mathf.Pow(PinkyMiddlePos.tempPosition.y - TargetPinkyMiddlePos.tempPosition.y, 2)
            + Mathf.Pow(PinkyMiddlePos.tempPosition.z - TargetPinkyMiddlePos.tempPosition.z, 2));
        PinkyKnuckleDiff = Mathf.Sqrt(Mathf.Pow(PinkyKnucklePos.tempPosition.x - TargetPinkyKnucklePos.tempPosition.x, 2)
            + Mathf.Pow(PinkyKnucklePos.tempPosition.y - TargetPinkyKnucklePos.tempPosition.y, 2)
            + Mathf.Pow(PinkyKnucklePos.tempPosition.z - TargetPinkyKnucklePos.tempPosition.z, 2));
        MetaPinkyDiff = Mathf.Sqrt(Mathf.Pow(MetaPinkyPos.tempPosition.x - TargetMetaPinkyPos.tempPosition.x, 2)
            + Mathf.Pow(MetaPinkyPos.tempPosition.y - TargetMetaPinkyPos.tempPosition.y, 2)
            + Mathf.Pow(MetaPinkyPos.tempPosition.z - TargetMetaPinkyPos.tempPosition.z, 2));
        WristPosDiff = Mathf.Sqrt(Mathf.Pow(WristPos.tempPosition.x - TargetWristPos.tempPosition.x, 2)
            + Mathf.Pow(WristPos.tempPosition.y - TargetWristPos.tempPosition.y, 2)
            + Mathf.Pow(WristPos.tempPosition.z - TargetWristPos.tempPosition.z, 2));

        // create name, value pairs 

        Joint[] joints = {new Joint {JointDiffName = "ThumbTip", JointDiffValue = ThumbTipDiff},
                          new Joint {JointDiffName = "ThumbDistal", JointDiffValue = ThumbDistalDiff},
                          new Joint {JointDiffName = "ThumbProximal", JointDiffValue = ThumbProximalDiff},
                          new Joint {JointDiffName = "MetaThumb", JointDiffValue = MetaThumbDiff},
                          new Joint {JointDiffName = "IndexTip", JointDiffValue = IndexTipDiff},
                          new Joint {JointDiffName = "IndexDistal", JointDiffValue = IndexDistalDiff},
                          new Joint {JointDiffName = "IndexMiddle", JointDiffValue = IndexMiddleDiff},
                          new Joint {JointDiffName = "IndexKnuckle", JointDiffValue = IndexKnuckleDiff},
                          new Joint {JointDiffName = "MetaIndex", JointDiffValue = MetaIndexDiff},
                          new Joint {JointDiffName = "MiddleTip", JointDiffValue = MiddleTipDiff},
                          new Joint {JointDiffName = "MiddleDistal", JointDiffValue = MiddleDistalDiff},
                          new Joint {JointDiffName = "MiddleMiddle", JointDiffValue = MiddleMiddleDiff},
                          new Joint {JointDiffName = "MiddleKnuckle", JointDiffValue = MiddleKnuckleDiff},
                          new Joint {JointDiffName = "MetaMiddle", JointDiffValue = MetaMiddleDiff},
                          new Joint {JointDiffName = "RingTip", JointDiffValue = RingTipDiff},
                          new Joint {JointDiffName = "RingDistal", JointDiffValue = RingDistalDiff},
                          new Joint {JointDiffName = "RingMiddle", JointDiffValue = RingMiddleDiff},
                          new Joint {JointDiffName = "RingKnuckle", JointDiffValue = RingKnuckleDiff},
                          new Joint {JointDiffName = "MetaRing", JointDiffValue = MetaRingDiff},
                          new Joint {JointDiffName = "PinkyTip", JointDiffValue = PinkyTipDiff},
                          new Joint {JointDiffName = "PinkyDistal", JointDiffValue = PinkyDistalDiff},
                          new Joint {JointDiffName = "PinkyMiddle", JointDiffValue = PinkyMiddleDiff},
                          new Joint {JointDiffName = "PinkyKnuckle", JointDiffValue = PinkyKnuckleDiff},
                          new Joint {JointDiffName = "MetaPinky", JointDiffValue = MetaPinkyDiff},
                          new Joint{JointDiffName = "Wrist", JointDiffValue = WristPosDiff} };
        IEnumerable<Joint> query = joints.OrderBy(joint => joint.JointDiffValue);
        foreach (Joint joint in query)
        {
            MaxJointDiffName = joint.JointDiffName;
            MaxJointDiff = joint.JointDiffValue;
            DiffSum += joint.JointDiffValue; // zero this out at end of outer loop
            JointCount += 1; // zero this out at end out outer loop
            if (JointCount == 13) // middle value of total number of joints 
            {
                MedianJointDiff = joint.JointDiffValue;
                MedianJointDiffName = joint.JointDiffName;
            }

        }

        MeanDiff = DiffSum / JointCount;
        DiffSum = 0; // reset value 
        JointCount = 0; // reset value

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // calculate angles of target and actual postures, calculate differences, try showing them in registered space...

        // target angles... in the future maybe have a few set up in advance 

        float TargetThumbKnuckleAngle = functions.CalculateAngle(TargetMetaThumbPos.tempPosition.x, TargetMetaThumbPos.tempPosition.y, TargetMetaThumbPos.tempPosition.z,
                                                                 TargetThumbProximalPos.tempPosition.x, TargetThumbProximalPos.tempPosition.y, TargetThumbProximalPos.tempPosition.z,
                                                                 TargetThumbDistalPos.tempPosition.x, TargetThumbDistalPos.tempPosition.y, TargetThumbDistalPos.tempPosition.z);
        float TargetThumbDistalAngle = functions.CalculateAngle(TargetThumbProximalPos.tempPosition.x, TargetThumbProximalPos.tempPosition.y, TargetThumbProximalPos.tempPosition.z,
                                                                TargetThumbDistalPos.tempPosition.x, TargetThumbDistalPos.tempPosition.y, TargetThumbDistalPos.tempPosition.z,
                                                                TargetThumbTipPos.tempPosition.x, TargetThumbTipPos.tempPosition.y, TargetThumbTipPos.tempPosition.z);
        float TargetIndexKnuckleAngle = functions.CalculateAngle(TargetMetaIndexPos.tempPosition.x, TargetMetaIndexPos.tempPosition.y, TargetMetaIndexPos.tempPosition.z,
                                                                 TargetIndexKnucklePos.tempPosition.x, TargetIndexKnucklePos.tempPosition.y, TargetIndexKnucklePos.tempPosition.z,
                                                                 TargetIndexMiddlePos.tempPosition.x, TargetIndexMiddlePos.tempPosition.y, TargetIndexMiddlePos.tempPosition.z);
        float TargetIndexMiddleAngle = functions.CalculateAngle(TargetIndexKnucklePos.tempPosition.x, TargetIndexKnucklePos.tempPosition.y, TargetIndexKnucklePos.tempPosition.z,
                                                                TargetIndexMiddlePos.tempPosition.x, TargetIndexMiddlePos.tempPosition.y, TargetIndexMiddlePos.tempPosition.z,
                                                                TargetIndexDistalPos.tempPosition.x, TargetIndexDistalPos.tempPosition.y, TargetIndexDistalPos.tempPosition.z);
        float TargetIndexDistalAngle = functions.CalculateAngle(TargetIndexMiddlePos.tempPosition.x, TargetIndexMiddlePos.tempPosition.y, TargetIndexMiddlePos.tempPosition.z,
                                                                TargetIndexDistalPos.tempPosition.x, TargetIndexDistalPos.tempPosition.y, TargetIndexDistalPos.tempPosition.z,
                                                                TargetIndexTipPos.tempPosition.x, TargetIndexTipPos.tempPosition.y, TargetIndexTipPos.tempPosition.z);
        float TargetMiddleKnuckleAngle = functions.CalculateAngle(TargetMetaMiddlePos.tempPosition.x, TargetMetaMiddlePos.tempPosition.y, TargetMetaMiddlePos.tempPosition.z,
                                                                  TargetMiddleKnucklePos.tempPosition.x, TargetMiddleKnucklePos.tempPosition.y, TargetMiddleKnucklePos.tempPosition.z,
                                                                  TargetMiddleMiddlePos.tempPosition.x, TargetMiddleMiddlePos.tempPosition.y, TargetMiddleMiddlePos.tempPosition.z);
        float TargetMiddleMiddleAngle = functions.CalculateAngle(TargetMiddleKnucklePos.tempPosition.x, TargetMiddleKnucklePos.tempPosition.y, TargetMiddleKnucklePos.tempPosition.z,
                                                                 TargetMiddleMiddlePos.tempPosition.x, TargetMiddleMiddlePos.tempPosition.y, TargetMiddleMiddlePos.tempPosition.z,
                                                                 TargetMiddleDistalPos.tempPosition.x, TargetMiddleDistalPos.tempPosition.y, TargetMiddleDistalPos.tempPosition.z);
        float TargetMiddleDistalAngle = functions.CalculateAngle(TargetMiddleMiddlePos.tempPosition.x, TargetMiddleMiddlePos.tempPosition.y, TargetMiddleMiddlePos.tempPosition.z,
                                                                 TargetMiddleDistalPos.tempPosition.x, TargetMiddleDistalPos.tempPosition.y, TargetMiddleDistalPos.tempPosition.z,
                                                                 TargetMiddleTipPos.tempPosition.x, TargetMiddleTipPos.tempPosition.y, TargetMiddleTipPos.tempPosition.z);
        float TargetRingKnuckleAngle = functions.CalculateAngle(TargetMetaRingPos.tempPosition.x, TargetMetaRingPos.tempPosition.y, TargetMetaRingPos.tempPosition.z,
                                                                TargetRingKnucklePos.tempPosition.x, TargetRingKnucklePos.tempPosition.y, TargetRingKnucklePos.tempPosition.z,
                                                                TargetRingMiddlePos.tempPosition.x, TargetRingMiddlePos.tempPosition.y, TargetRingMiddlePos.tempPosition.z);
        float TargetRingMiddleAngle = functions.CalculateAngle(TargetRingKnucklePos.tempPosition.x, TargetRingKnucklePos.tempPosition.y, TargetRingKnucklePos.tempPosition.z,
                                                               TargetRingMiddlePos.tempPosition.x, TargetRingMiddlePos.tempPosition.y, TargetRingMiddlePos.tempPosition.z,
                                                               TargetRingDistalPos.tempPosition.x, TargetRingDistalPos.tempPosition.y, TargetRingDistalPos.tempPosition.z);
        float TargetRingDistalAngle = functions.CalculateAngle(TargetRingMiddlePos.tempPosition.x, TargetRingMiddlePos.tempPosition.y, TargetRingMiddlePos.tempPosition.z,
                                                               TargetRingDistalPos.tempPosition.x, TargetRingDistalPos.tempPosition.y, TargetRingDistalPos.tempPosition.z,
                                                               TargetRingTipPos.tempPosition.x, TargetRingTipPos.tempPosition.y, TargetRingTipPos.tempPosition.z);
        float TargetPinkyKnuckleAngle = functions.CalculateAngle(TargetMetaPinkyPos.tempPosition.x, TargetMetaPinkyPos.tempPosition.y, TargetMetaPinkyPos.tempPosition.z,
                                                                 TargetPinkyKnucklePos.tempPosition.x, TargetPinkyKnucklePos.tempPosition.y, TargetPinkyKnucklePos.tempPosition.z,
                                                                 TargetPinkyMiddlePos.tempPosition.x, TargetPinkyMiddlePos.tempPosition.y, TargetPinkyMiddlePos.tempPosition.z);
        float TargetPinkyMiddleAngle = functions.CalculateAngle(TargetPinkyKnucklePos.tempPosition.x, TargetPinkyKnucklePos.tempPosition.y, TargetPinkyKnucklePos.tempPosition.z,
                                                                TargetPinkyMiddlePos.tempPosition.x, TargetPinkyMiddlePos.tempPosition.y, TargetPinkyMiddlePos.tempPosition.z,
                                                                TargetPinkyDistalPos.tempPosition.x, TargetPinkyDistalPos.tempPosition.y, TargetPinkyDistalPos.tempPosition.z);
        float TargetPinkyDistalAngle = functions.CalculateAngle(TargetPinkyMiddlePos.tempPosition.x, TargetPinkyMiddlePos.tempPosition.y, TargetPinkyMiddlePos.tempPosition.z,
                                                                TargetPinkyDistalPos.tempPosition.x, TargetPinkyDistalPos.tempPosition.y, TargetPinkyDistalPos.tempPosition.z,
                                                                TargetPinkyTipPos.tempPosition.x, TargetPinkyTipPos.tempPosition.y, TargetPinkyTipPos.tempPosition.z);
        // wrist is tricky because don't have forearm position
        /*float TargetWristAngle = functions.CalculateAngle(TargetWristPos.tempPosition.x, TargetWristPos.tempPosition.y, TargetWristPos.tempPosition.z,
                                                          TargetMetaMiddlePos.tempPosition.x, TargetMetaMiddlePos.tempPosition.y, TargetMetaMiddlePos.tempPosition.z,
                                                          TargetMiddleKnucklePos.tempPosition.x, TargetMiddleKnucklePos.tempPosition.y, TargetMiddleKnucklePos.tempPosition.z);*/

        // actual angles
        float ThumbKnuckleAngle = functions.CalculateAngle(MetaThumbPos.tempPosition.x, MetaThumbPos.tempPosition.y, MetaThumbPos.tempPosition.z,
                                                                 ThumbProximalPos.tempPosition.x, ThumbProximalPos.tempPosition.y, ThumbProximalPos.tempPosition.z,
                                                                 ThumbDistalPos.tempPosition.x, ThumbDistalPos.tempPosition.y, ThumbDistalPos.tempPosition.z);
        float ThumbDistalAngle = functions.CalculateAngle(ThumbProximalPos.tempPosition.x, ThumbProximalPos.tempPosition.y, ThumbProximalPos.tempPosition.z,
                                                                ThumbDistalPos.tempPosition.x, ThumbDistalPos.tempPosition.y, ThumbDistalPos.tempPosition.z,
                                                                ThumbTipPos.tempPosition.x, ThumbTipPos.tempPosition.y, ThumbTipPos.tempPosition.z);
        float IndexKnuckleAngle = functions.CalculateAngle(MetaIndexPos.tempPosition.x, MetaIndexPos.tempPosition.y, MetaIndexPos.tempPosition.z,
                                                                 IndexKnucklePos.tempPosition.x, IndexKnucklePos.tempPosition.y, IndexKnucklePos.tempPosition.z,
                                                                 IndexMiddlePos.tempPosition.x, IndexMiddlePos.tempPosition.y, IndexMiddlePos.tempPosition.z);
        float IndexMiddleAngle = functions.CalculateAngle(IndexKnucklePos.tempPosition.x, IndexKnucklePos.tempPosition.y, IndexKnucklePos.tempPosition.z,
                                                                IndexMiddlePos.tempPosition.x, IndexMiddlePos.tempPosition.y, IndexMiddlePos.tempPosition.z,
                                                                IndexDistalPos.tempPosition.x, IndexDistalPos.tempPosition.y, IndexDistalPos.tempPosition.z);
        float IndexDistalAngle = functions.CalculateAngle(IndexMiddlePos.tempPosition.x, IndexMiddlePos.tempPosition.y, IndexMiddlePos.tempPosition.z,
                                                                IndexDistalPos.tempPosition.x, IndexDistalPos.tempPosition.y, IndexDistalPos.tempPosition.z,
                                                                IndexTipPos.tempPosition.x, IndexTipPos.tempPosition.y, IndexTipPos.tempPosition.z);
        float MiddleKnuckleAngle = functions.CalculateAngle(MetaMiddlePos.tempPosition.x, MetaMiddlePos.tempPosition.y, MetaMiddlePos.tempPosition.z,
                                                                  MiddleKnucklePos.tempPosition.x, MiddleKnucklePos.tempPosition.y, MiddleKnucklePos.tempPosition.z,
                                                                  MiddleMiddlePos.tempPosition.x, MiddleMiddlePos.tempPosition.y, MiddleMiddlePos.tempPosition.z);
        float MiddleMiddleAngle = functions.CalculateAngle(MiddleKnucklePos.tempPosition.x, MiddleKnucklePos.tempPosition.y, MiddleKnucklePos.tempPosition.z,
                                                                 MiddleMiddlePos.tempPosition.x, MiddleMiddlePos.tempPosition.y, MiddleMiddlePos.tempPosition.z,
                                                                 MiddleDistalPos.tempPosition.x, MiddleDistalPos.tempPosition.y, MiddleDistalPos.tempPosition.z);
        float MiddleDistalAngle = functions.CalculateAngle(MiddleMiddlePos.tempPosition.x, MiddleMiddlePos.tempPosition.y, MiddleMiddlePos.tempPosition.z,
                                                                 MiddleDistalPos.tempPosition.x, MiddleDistalPos.tempPosition.y, MiddleDistalPos.tempPosition.z,
                                                                 MiddleTipPos.tempPosition.x, MiddleTipPos.tempPosition.y, MiddleTipPos.tempPosition.z);
        float RingKnuckleAngle = functions.CalculateAngle(MetaRingPos.tempPosition.x, MetaRingPos.tempPosition.y, MetaRingPos.tempPosition.z,
                                                                RingKnucklePos.tempPosition.x, RingKnucklePos.tempPosition.y, RingKnucklePos.tempPosition.z,
                                                                RingMiddlePos.tempPosition.x, RingMiddlePos.tempPosition.y, RingMiddlePos.tempPosition.z);
        float RingMiddleAngle = functions.CalculateAngle(RingKnucklePos.tempPosition.x, RingKnucklePos.tempPosition.y, RingKnucklePos.tempPosition.z,
                                                               RingMiddlePos.tempPosition.x, RingMiddlePos.tempPosition.y, RingMiddlePos.tempPosition.z,
                                                               RingDistalPos.tempPosition.x, RingDistalPos.tempPosition.y, RingDistalPos.tempPosition.z);
        float RingDistalAngle = functions.CalculateAngle(RingMiddlePos.tempPosition.x, RingMiddlePos.tempPosition.y, RingMiddlePos.tempPosition.z,
                                                               RingDistalPos.tempPosition.x, RingDistalPos.tempPosition.y, RingDistalPos.tempPosition.z,
                                                               RingTipPos.tempPosition.x, RingTipPos.tempPosition.y, RingTipPos.tempPosition.z);
        float PinkyKnuckleAngle = functions.CalculateAngle(MetaPinkyPos.tempPosition.x, MetaPinkyPos.tempPosition.y, MetaPinkyPos.tempPosition.z,
                                                                 PinkyKnucklePos.tempPosition.x, PinkyKnucklePos.tempPosition.y, PinkyKnucklePos.tempPosition.z,
                                                                 PinkyMiddlePos.tempPosition.x, PinkyMiddlePos.tempPosition.y, PinkyMiddlePos.tempPosition.z);
        float PinkyMiddleAngle = functions.CalculateAngle(PinkyKnucklePos.tempPosition.x, PinkyKnucklePos.tempPosition.y, PinkyKnucklePos.tempPosition.z,
                                                                PinkyMiddlePos.tempPosition.x, PinkyMiddlePos.tempPosition.y, PinkyMiddlePos.tempPosition.z,
                                                                PinkyDistalPos.tempPosition.x, PinkyDistalPos.tempPosition.y, PinkyDistalPos.tempPosition.z);
        float PinkyDistalAngle = functions.CalculateAngle(PinkyMiddlePos.tempPosition.x, PinkyMiddlePos.tempPosition.y, PinkyMiddlePos.tempPosition.z,
                                                                PinkyDistalPos.tempPosition.x, PinkyDistalPos.tempPosition.y, PinkyDistalPos.tempPosition.z,
                                                                PinkyTipPos.tempPosition.x, PinkyTipPos.tempPosition.y, PinkyTipPos.tempPosition.z);

        // calculate angle differences

        ThumbKnuckleAngleDiff = MathF.Abs(TargetThumbKnuckleAngle - ThumbKnuckleAngle);
        ThumbDistalAngleDiff = MathF.Abs(TargetThumbDistalAngle - ThumbDistalAngle);
        IndexKnuckleAngleDiff = MathF.Abs(TargetIndexKnuckleAngle - IndexKnuckleAngle);
        IndexMiddleAngleDiff = MathF.Abs(TargetIndexMiddleAngle - IndexMiddleAngle);
        IndexDistalAngleDiff = MathF.Abs(TargetIndexDistalAngle - IndexDistalAngle);
        MiddleKnuckleAngleDiff = MathF.Abs(TargetMiddleKnuckleAngle - MiddleKnuckleAngle);
        MiddleMiddleAngleDiff = MathF.Abs(TargetMiddleMiddleAngle - MiddleMiddleAngle);
        MiddleDistalAngleDiff = MathF.Abs(TargetMiddleDistalAngle - MiddleDistalAngle);
        RingKnuckleAngleDiff = MathF.Abs(TargetRingKnuckleAngle - RingKnuckleAngle);
        RingMiddleAngleDiff = MathF.Abs(TargetRingMiddleAngle - RingMiddleAngle);
        RingDistalAngleDiff = MathF.Abs(TargetRingDistalAngle - RingDistalAngle);
        PinkyKnuckleAngleDiff = MathF.Abs(TargetPinkyKnuckleAngle - PinkyKnuckleAngle);
        PinkyMiddleAngleDiff = MathF.Abs(TargetPinkyMiddleAngle - PinkyMiddleAngle);
        PinkyDistalAngleDiff = MathF.Abs(TargetPinkyDistalAngle - PinkyDistalAngle);

        

        JointAngle[] jointAngles = {new JointAngle {JointAngleName = "ThumbKnuckleAngle", JointAngleValue = ThumbKnuckleAngleDiff},
                                    new JointAngle {JointAngleName = "ThumbDistalAngle", JointAngleValue = ThumbDistalAngleDiff},
                                    new JointAngle {JointAngleName = "IndexKnuckleAngle", JointAngleValue = IndexKnuckleAngleDiff},
                                    new JointAngle {JointAngleName = "IndexMiddleAngle", JointAngleValue = IndexMiddleAngleDiff},
                                    new JointAngle {JointAngleName = "IndexDistalAngle", JointAngleValue = IndexDistalAngleDiff},
                                    new JointAngle {JointAngleName = "MiddleKnuckleAngle", JointAngleValue = MiddleKnuckleAngleDiff},
                                    new JointAngle {JointAngleName = "MiddleMiddleAngle", JointAngleValue = MiddleMiddleAngleDiff},
                                    new JointAngle {JointAngleName = "MiddleDistalAngle", JointAngleValue = MiddleDistalAngleDiff},
                                    new JointAngle {JointAngleName = "RingKnuckleAngle", JointAngleValue = RingKnuckleAngleDiff},
                                    new JointAngle {JointAngleName = "RingMiddleAngle", JointAngleValue = RingMiddleAngleDiff},
                                    new JointAngle {JointAngleName = "RingDistalAngle", JointAngleValue = RingDistalAngleDiff},
                                    new JointAngle {JointAngleName = "PinkyKnuckleAngle", JointAngleValue = PinkyKnuckleAngleDiff},
                                    new JointAngle {JointAngleName = "PinkyMiddleAngle", JointAngleValue = PinkyMiddleAngleDiff},
                                    new JointAngle {JointAngleName = "PinkyDistalAngle", JointAngleValue = PinkyDistalAngleDiff} };

        IEnumerable<JointAngle> query2 = jointAngles.OrderBy(jointAngle => jointAngle.JointAngleValue);
        foreach (JointAngle jointAngle in query2)
        {
            // iterate to see largest angle difference, mean, and median
            MaxJointAngleDiffName = jointAngle.JointAngleName;
            MaxJointAngleDiff = jointAngle.JointAngleValue;
            DiffSum += jointAngle.JointAngleValue; // zero this out at end of outer loop
            JointCount += 1; // zero this out at end of outer loop
            if (JointCount == 13) // middle value of total number of joints
            {
                MedianJointAngleDiff = jointAngle.JointAngleValue;
                MedianJointAngleDiffName = jointAngle.JointAngleName;           
            }


        }

        MeanAngleDiff = DiffSum / JointCount;
        DiffSum = 0; // reset value 
        JointCount = 0; // reset value

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // text output, try to change color based on score... try this at some point
        // put some if statements in to make this more readable
        // distance
        

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            positionset = 1;
        }

        if (positionset == 0)
        {
            distance_output.text = "";
        }
        else if (positionset == 1) 
        { 
            switch (MaxJointDiffName)
            {
                case "ThumbTip":
                case "ThumbDistal":
                case "ThumbProximal":
                case "MetaThumb":
                    distance_output.text = "Farthest Finger: " + "\n"
                                            + "Thumb" + "\n"
                                            + "Mean Error: " + "\n"
                                            + MeanDiff;
                    break;

                case "IndexKnuckle":
                case "IndexMiddle":
                case "IndexDistal":
                case "IndexTip":
                case "MetaIndex":
                    distance_output.text = "Farthest Finger: " + "\n"
                                          + "Index Finger" + "\n"
                                          + "Mean Error: " + "\n"
                                          + MeanDiff;
                    break;

                case "MiddleKnuckle":
                case "MiddleMiddle":
                case "MiddleDistal":
                case "MiddleTip":
                case "MetaMiddle":
                    distance_output.text = "Farthest Finger: " + "\n"
                                          + "Middle Finger" + "\n"
                                          + "Mean Error: " + "\n"
                                          + MeanDiff;
                    break;

                case "RingKnuckle":
                case "RingMiddle":
                case "RingDistal":
                case "RingTip":
                case "MetaRing":
                    distance_output.text = "Farthest Finger: " + "\n"
                                          + "Ring Finger" + "\n"
                                          + "Mean Error: " + "\n"
                                          + MeanDiff;
                    break;

                case "PinkyKnuckle":
                case "PinkyMiddle":
                case "PinkyDistal":
                case "PinkyTip":
                case "MetaPinky":
                    distance_output.text = "Farthest Finger: " + "\n"
                                          + "Pinky Finger" + "\n"
                                          + "Mean Error: " + "\n"
                                          + MeanDiff;
                    break;

                case "Wrist":
                    distance_output.text = "Farthest Joint: " + "\n"
                                          + "Wrist" + "\n"
                                          + "Mean Error: " + "\n"
                                          + MeanDiff;
                    break;
            }

            switch (MeanDiff)
            {
                case < 0.001f:
                    distance_output.text = "";
                    break;
                case < 0.03f:
                    distance_output.color = Color.green;
                    distance_output.text = "Great Position!";
                    break;
                case < 0.3f:
                    distance_output.color = Color.yellow;
                    break;
                case > 0.3f:
                    distance_output.color = Color.red;
                    break;
            }
        }

        // angle
        switch (MaxJointAngleDiffName)
        {
            case "ThumbKnuckleAngle":
            case "ThumbDistalAngle":
                angle_text = "Worst Angle: " + "\n"
                                    + "Thumb" + "\n"
                                    + "Mean Error: " + "\n"
                                    + MeanAngleDiff;
                break;

            case "IndexKnuckleAngle":
            case "IndexMiddleAngle":
            case "IndexDistalAngle":
                angle_text = "Worst Angle: " + "\n"
                                        + "Index Finger" + "\n"
                                        + "Mean Error: " + "\n"
                                        + MeanAngleDiff;
                break;

            case "MiddleKnuckleAngle":
            case "MiddleMiddleAngle":
            case "MiddleDistalAngle":
                angle_text = "Worst Angle: " + "\n"
                                    + "Middle Finger" + "\n"
                                    + "Mean Error: " + "\n"
                                    + MeanAngleDiff;
                break;

            case "RingKnuckleAngle":
            case "RingMiddleAngle":
            case "RingDistalAngle":
                angle_text = "Worst Angle: " + "\n"
                                    + "Ring Finger" + "\n"
                                    + "Mean Error: " + "\n"
                                    + MeanAngleDiff;
                break;

            case "PinkyKnuckleAngle":
            case "PinkyMiddleAngle":
            case "PinkyDistalAngle":
                angle_text = "Worst Angle: " + "\n"
                                    + "Pinky Finger" + "\n"
                                    + "Mean Error: " + "\n"
                                    + MeanAngleDiff;
                break;

        }
        
        angle_output.text = angle_text; 

        switch (MeanAngleDiff)
        {
            case < 2: // these can change depending on decided thresholds
                angle_output.color = Color.green;
                angle_output.text = "Perfect Posture!";
                break;
            case < 5:
                angle_output.color = Color.green;
                angle_output.text = angle_text + "\n" + "Great Posture!";
                break;
            case < 15:
                angle_output.color = Color.yellow;
                angle_output.text = angle_text + "\n" + "OK Posture!";
                break;
            case > 15:
                angle_output.color = Color.red;
                angle_output.text = angle_text + "\n" + "Bad Posture!";
                break;
            case float.NaN:
                angle_output.text = "";
                break;
        }

        
    }

}

