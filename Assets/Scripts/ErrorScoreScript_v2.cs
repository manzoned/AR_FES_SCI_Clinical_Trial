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
using Unity.Collections;
//using System.Drawing;

public class ErrorScoreScript_v2 : MonoBehaviour
{
    // text inputs
    //public TextMeshProUGUI distance_output;
    public TextMeshProUGUI angle_output;
    public TextMeshProUGUI feedback_test;
    public FeedbackTest FeedbackTest;
    public TextMeshPro overallScoreText_output;
    public TextMeshPro overallMatchText_output;
    public ScoreBackPlate ScoreBackPlate;
    public HandTracking1 HandTracking;
    public IndexKnucklePlane IndexKnucklePlane;
    public bool UseThumbAngle;

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
    public PalmPos PalmPos;


    // create target positions
    public Vector3 TargetThumbTipPos;
    public Vector3 TargetThumbDistalPos;
    public Vector3 TargetThumbProximalPos;
    public Vector3 TargetMetaThumbPos;
    public Vector3 TargetIndexTipPos;
    public Vector3 TargetIndexDistalPos;
    public Vector3 TargetIndexMiddlePos;
    public Vector3 TargetIndexKnucklePos;
    public Vector3 TargetMetaIndexPos;
    public Vector3 TargetMiddleTipPos;
    public Vector3 TargetMiddleDistalPos;
    public Vector3 TargetMiddleMiddlePos;
    public Vector3 TargetMiddleKnucklePos;
    public Vector3 TargetMetaMiddlePos;
    public Vector3 TargetRingTipPos;
    public Vector3 TargetRingDistalPos;
    public Vector3 TargetRingMiddlePos;
    public Vector3 TargetRingKnucklePos;
    public Vector3 TargetMetaRingPos;
    public Vector3 TargetPinkyTipPos;
    public Vector3 TargetPinkyDistalPos;
    public Vector3 TargetPinkyMiddlePos;
    public Vector3 TargetPinkyKnucklePos;
    public Vector3 TargetMetaPinkyPos;
    public Vector3 TargetWristPos;
    public Vector3 TargetPalmPos;
    public Quaternion TargetPalmRot;

    // reference different posture positions
    public LateralThumbTipPos LateralThumbTipPos;
    public LateralThumbDistalPos LateralThumbDistalPos;
    public LateralThumbProximalPos LateralThumbProximalPos;
    public LateralMetaThumbPos LateralMetaThumbPos;
    public LateralIndexTipPos LateralIndexTipPos;
    public LateralIndexDistalPos LateralIndexDistalPos;
    public LateralIndexMiddlePos LateralIndexMiddlePos;
    public LateralIndexKnucklePos LateralIndexKnucklePos;
    public LateralMetaIndexPos LateralMetaIndexPos;
    public LateralMiddleTipPos LateralMiddleTipPos;
    public LateralMiddleDistalPos LateralMiddleDistalPos;
    public LateralMiddleMiddlePos LateralMiddleMiddlePos;
    public LateralMiddleKnucklePos LateralMiddleKnucklePos;
    public LateralMetaMiddlePos LateralMetaMiddlePos;
    public LateralRingTipPos LateralRingTipPos;
    public LateralRingDistalPos LateralRingDistalPos;
    public LateralRingMiddlePos LateralRingMiddlePos;
    public LateralRingKnucklePos LateralRingKnucklePos;
    public LateralMetaRingPos LateralMetaRingPos;
    public LateralPinkyTipPos LateralPinkyTipPos;
    public LateralPinkyDistalPos LateralPinkyDistalPos;
    public LateralPinkyMiddlePos LateralPinkyMiddlePos;
    public LateralPinkyKnucklePos LateralPinkyKnucklePos;
    public LateralMetaPinkyPos LateralMetaPinkyPos;
    public LateralWristPos LateralWristPos;
    public LateralPalmPos LateralPalmPos;

    public TipPinchThumbTipPos TipPinchThumbTipPos;
    public TipPinchThumbDistalPos TipPinchThumbDistalPos;
    public TipPinchThumbProximalPos TipPinchThumbProximalPos;
    public TipPinchMetaThumbPos TipPinchMetaThumbPos;
    public TipPinchIndexTipPos TipPinchIndexTipPos;
    public TipPinchIndexDistalPos TipPinchIndexDistalPos;
    public TipPinchIndexMiddlePos TipPinchIndexMiddlePos;
    public TipPinchIndexKnucklePos TipPinchIndexKnucklePos;
    public TipPinchMetaIndexPos TipPinchMetaIndexPos;
    public TipPinchMiddleTipPos TipPinchMiddleTipPos;
    public TipPinchMiddleDistalPos TipPinchMiddleDistalPos;
    public TipPinchMiddleMiddlePos TipPinchMiddleMiddlePos;
    public TipPinchMiddleKnucklePos TipPinchMiddleKnucklePos;
    public TipPinchMetaMiddlePos TipPinchMetaMiddlePos;
    public TipPinchRingTipPos TipPinchRingTipPos;
    public TipPinchRingDistalPos TipPinchRingDistalPos;
    public TipPinchRingMiddlePos TipPinchRingMiddlePos;
    public TipPinchRingKnucklePos TipPinchRingKnucklePos;
    public TipPinchMetaRingPos TipPinchMetaRingPos;
    public TipPinchPinkyTipPos TipPinchPinkyTipPos;
    public TipPinchPinkyDistalPos TipPinchPinkyDistalPos;
    public TipPinchPinkyMiddlePos TipPinchPinkyMiddlePos;
    public TipPinchPinkyKnucklePos TipPinchPinkyKnucklePos;
    public TipPinchMetaPinkyPos TipPinchMetaPinkyPos;
    public TipPinchWristPos TipPinchWristPos;
    public TipPinchPalmPos TipPinchPalmPos;

    public LargeDiameterThumbTipPos LargeDiameterThumbTipPos;
    public LargeDiameterThumbDistalPos LargeDiameterThumbDistalPos;
    public LargeDiameterThumbProximalPos LargeDiameterThumbProximalPos;
    public LargeDiameterMetaThumbPos LargeDiameterMetaThumbPos;
    public LargeDiameterIndexTipPos LargeDiameterIndexTipPos;
    public LargeDiameterIndexDistalPos LargeDiameterIndexDistalPos;
    public LargeDiameterIndexMiddlePos LargeDiameterIndexMiddlePos;
    public LargeDiameterIndexKnucklePos LargeDiameterIndexKnucklePos;
    public LargeDiameterMetaIndexPos LargeDiameterMetaIndexPos;
    public LargeDiameterMiddleTipPos LargeDiameterMiddleTipPos;
    public LargeDiameterMiddleDistalPos LargeDiameterMiddleDistalPos;
    public LargeDiameterMiddleMiddlePos LargeDiameterMiddleMiddlePos;
    public LargeDiameterMiddleKnucklePos LargeDiameterMiddleKnucklePos;
    public LargeDiameterMetaMiddlePos LargeDiameterMetaMiddlePos;
    public LargeDiameterRingTipPos LargeDiameterRingTipPos;
    public LargeDiameterRingDistalPos LargeDiameterRingDistalPos;
    public LargeDiameterRingMiddlePos LargeDiameterRingMiddlePos;
    public LargeDiameterRingKnucklePos LargeDiameterRingKnucklePos;
    public LargeDiameterMetaRingPos LargeDiameterMetaRingPos;
    public LargeDiameterPinkyTipPos LargeDiameterPinkyTipPos;
    public LargeDiameterPinkyDistalPos LargeDiameterPinkyDistalPos;
    public LargeDiameterPinkyMiddlePos LargeDiameterPinkyMiddlePos;
    public LargeDiameterPinkyKnucklePos LargeDiameterPinkyKnucklePos;
    public LargeDiameterMetaPinkyPos LargeDiameterMetaPinkyPos;
    public LargeDiameterWristPos LargeDiameterWristPos;
    public LargeDiameterPalmPos LargeDiameterPalmPos;

    public TherapistThumbTipPos TherapistThumbTipPos;
    public TherapistThumbDistalPos TherapistThumbDistalPos;
    public TherapistThumbProximalPos TherapistThumbProximalPos;
    public TherapistMetaThumbPos TherapistMetaThumbPos;
    public TherapistIndexTipPos TherapistIndexTipPos;
    public TherapistIndexDistalPos TherapistIndexDistalPos;
    public TherapistIndexMiddlePos TherapistIndexMiddlePos;
    public TherapistIndexKnucklePos TherapistIndexKnucklePos;
    public TherapistMetaIndexPos TherapistMetaIndexPos;
    public TherapistMiddleTipPos TherapistMiddleTipPos;
    public TherapistMiddleDistalPos TherapistMiddleDistalPos;
    public TherapistMiddleMiddlePos TherapistMiddleMiddlePos;
    public TherapistMiddleKnucklePos TherapistMiddleKnucklePos;
    public TherapistMetaMiddlePos TherapistMetaMiddlePos;
    public TherapistRingTipPos TherapistRingTipPos;
    public TherapistRingDistalPos TherapistRingDistalPos;
    public TherapistRingMiddlePos TherapistRingMiddlePos;
    public TherapistRingKnucklePos TherapistRingKnucklePos;
    public TherapistMetaRingPos TherapistMetaRingPos;
    public TherapistPinkyTipPos TherapistPinkyTipPos;
    public TherapistPinkyDistalPos TherapistPinkyDistalPos;
    public TherapistPinkyMiddlePos TherapistPinkyMiddlePos;
    public TherapistPinkyKnucklePos TherapistPinkyKnucklePos;
    public TherapistMetaPinkyPos TherapistMetaPinkyPos;
    public TherapistWristPos TherapistWristPos;
    public TherapistPalmPos TherapistPalmPos;

    public Lateral Lateral;
    public TipPinch TipPinch;
    public LargeDiameter LargeDiameter;
    public TherapistJoints TherapistJoints;
    //public ForearmPos forearmPos;

    // public target angles... need to be public to draw mesh hand
    public float targetThumbTriangleAngle;
    public float TargetMetaThumbAngle;
    public float TargetThumbKnuckleAngle;
    public float TargetThumbDistalAngle;
    public float TargetIndexKnuckleAngle;
    public float TargetIndexMiddleAngle;
    public float TargetIndexDistalAngle;
    public float TargetMiddleKnuckleAngle;
    public float TargetMiddleMiddleAngle;
    public float TargetMiddleDistalAngle;
    public float TargetRingKnuckleAngle;
    public float TargetRingMiddleAngle;
    public float TargetRingDistalAngle;
    public float TargetPinkyKnuckleAngle;
    public float TargetPinkyMiddleAngle;
    public float TargetPinkyDistalAngle;

    public float ActualThumbTriangleAngle;
    public float ThumbIndexDistance;
    public float MetaThumbAngle;
    public float ThumbKnuckleAngle;
    public float ThumbDistalAngle;
    public float IndexKnuckleAngle;
    public float IndexMiddleAngle;
    public float IndexDistalAngle;
    public float MiddleKnuckleAngle;
    public float MiddleMiddleAngle;
    public float MiddleDistalAngle;
    public float RingKnuckleAngle;
    public float RingMiddleAngle;
    public float RingDistalAngle;
    public float PinkyKnuckleAngle;
    public float PinkyMiddleAngle;
    public float PinkyDistalAngle;

    public float setWristAngle;
    public float tenodesisThreshold = 209; // based on Dousty & Zariffa, 2020: IEEE
    public int TenodesisDetected;

    // public absolute joint angle differences - used for AR overall score

    public float AbsThumbKnuckleAngleDiff;
    public float AbsThumbDistalAngleDiff;
    public float AbsIndexKnuckleAngleDiff;
    public float AbsIndexDistalAngleDiff;
    public float AbsIndexMiddleAngleDiff;
    public float AbsMiddleKnuckleAngleDiff;
    public float AbsMiddleDistalAngleDiff;
    public float AbsMiddleMiddleAngleDiff;
    public float AbsRingKnuckleAngleDiff;
    public float AbsRingDistalAngleDiff;
    public float AbsRingMiddleAngleDiff;
    public float AbsPinkyKnuckleAngleDiff;
    public float AbsPinkyDistalAngleDiff;
    public float AbsPinkyMiddleAngleDiff;
    //private float WristAngleDiff; // need to figure out this calculation first

    // public directional joint angle differences - used for FES error

    public float MetaThumbAngleDiff;
    public float ThumbKnuckleAngleDiff;
    public float ThumbDistalAngleDiff;
    public float ThumbAlignmentDiff;
    public float IndexKnuckleAngleDiff;
    public float IndexDistalAngleDiff;
    public float IndexMiddleAngleDiff;
    public float MiddleKnuckleAngleDiff;
    public float MiddleDistalAngleDiff;
    public float MiddleMiddleAngleDiff;
    public float RingKnuckleAngleDiff;
    public float RingDistalAngleDiff;
    public float RingMiddleAngleDiff;
    public float PinkyKnuckleAngleDiff;
    public float PinkyDistalAngleDiff;
    public float PinkyMiddleAngleDiff;
    public float FourDigitKnuckleAverage;
    

    // stimulation variables

    public float FingerStimAmp;
    public float ThumbStimAmp;

    // calculated variables

    // angle variables
    public float MeanAngleDiff;
    public float MeanAngleDiffTest;
    public float MaxJointAngleDiff;
    public float AngleDiffUpperBound;
    public float OverallScore100;
    public string MaxJointAngleDiffName;
    public float MedianJointAngleDiff;
    public string MedianJointAngleDiffName;
    public float upperbound_error;
    public float upperbound_error_thumb;
    public float upperbound_error_finger;
    public float lowerbound_error_thumb;
    public float lowerbound_error_finger;
    public float ThumbErrorWeight;
    public float IndexErrorWeight;
    public float MiddleErrorWeight;
    public float RingErrorWeight;
    public float PinkyErrorWeight;
    public float NormalizedThumbError;
    public float NormalizedIndexError;
    public float NormalizedMiddleError;
    public float NormalizedRingError;
    public float NormalizedPinkyError;
    public float NormalizedAverageError;

    // used to iterate the joint distance differences... uncomment if need to include
    /*    class Joint
        {
            public string JointDiffName { get; set; }
            public float JointDiffValue { get; set; }
        }*/

    // used to iterate the joint angle differences
    class JointAngle
    {
        public string JointAngleName { get; set; }
        public float JointAngleValue { get; set; }
    }



    public int positionset;
    public float DiffSum;
    public float DiffSumTotal;
    public float DiffSumThumb;
    public float DiffSumIndex;
    public float DiffSumMiddle;
    public float DiffSumRing;
    public float DiffSumPinky;
    private float JointCount;
    private string angle_text;


    //Dictionary<ActualHandJoints, ActualHandJoints> ActualHandJoints = new Dictionary<ActualHandJoints, ActualHandJoints>();
    // Dictionary<TargetHandJoints, float> TargetHandJoints = new Dictionary<TargetHandJoints, float>();
    //Dictionary<JointDiff, float> JointDiffFloats = new Dictionary<JointDiff, float>();


    ////////////////////////////////////////////////////////////////////////////////////////////

    // functions

    public void Disappear()
    {
        angle_output.text = "";
        positionset = 0;


    }
    public void Set()
    {
        positionset = 1;
        /*        setWristAngle = forearmPos.wristAngleAdjusted;
                setWristAngle = Mathf.Round(setWristAngle);

                if (setWristAngle > tenodesisThreshold)
                {
                    TenodesisDetected = 1;
                }
                else if (setWristAngle < tenodesisThreshold)
                {
                    TenodesisDetected = 0;
                }*/
    }

    // function to label target positions for calculations

    public void TargetLabeling()
    {
        if (Lateral.GraspState == 1)
        {
            TargetThumbTipPos = LateralThumbTipPos.tempPosition;
            TargetThumbDistalPos = LateralThumbDistalPos.tempPosition;
            TargetThumbProximalPos = LateralThumbProximalPos.tempPosition;
            TargetMetaThumbPos = LateralMetaThumbPos.tempPosition;
            TargetIndexTipPos = LateralIndexTipPos.tempPosition;
            TargetIndexDistalPos = LateralIndexDistalPos.tempPosition;
            TargetIndexMiddlePos = LateralIndexMiddlePos.tempPosition;
            TargetIndexKnucklePos = LateralIndexKnucklePos.tempPosition;
            TargetMetaIndexPos = LateralMetaIndexPos.tempPosition;
            TargetMiddleTipPos = LateralMiddleTipPos.tempPosition;
            TargetMiddleDistalPos = LateralMiddleDistalPos.tempPosition;
            TargetMiddleMiddlePos = LateralMiddleMiddlePos.tempPosition;
            TargetMiddleKnucklePos = LateralMiddleKnucklePos.tempPosition;
            TargetMetaMiddlePos = LateralMetaMiddlePos.tempPosition;
            TargetRingTipPos = LateralRingTipPos.tempPosition;
            TargetRingDistalPos = LateralRingDistalPos.tempPosition;
            TargetRingMiddlePos = LateralRingMiddlePos.tempPosition;
            TargetRingKnucklePos = LateralRingKnucklePos.tempPosition;
            TargetMetaRingPos = LateralMetaRingPos.tempPosition;
            TargetPinkyTipPos = LateralPinkyTipPos.tempPosition;
            TargetPinkyDistalPos = LateralPinkyDistalPos.tempPosition;
            TargetPinkyMiddlePos = LateralPinkyMiddlePos.tempPosition;
            TargetPinkyKnucklePos = LateralPinkyKnucklePos.tempPosition;
            TargetMetaPinkyPos = LateralMetaPinkyPos.tempPosition;
            TargetWristPos = LateralWristPos.tempPosition;
            TargetPalmPos = LateralPalmPos.tempPosition;
            TargetPalmRot = LateralPalmPos.tempRotation;

        }

        if (TipPinch.GraspState == 1)
        {
            TargetThumbTipPos = TipPinchThumbTipPos.tempPosition;
            TargetThumbDistalPos = TipPinchThumbDistalPos.tempPosition;
            TargetThumbProximalPos = TipPinchThumbProximalPos.tempPosition;
            TargetMetaThumbPos = TipPinchMetaThumbPos.tempPosition;
            TargetIndexTipPos = TipPinchIndexTipPos.tempPosition;
            TargetIndexDistalPos = TipPinchIndexDistalPos.tempPosition;
            TargetIndexMiddlePos = TipPinchIndexMiddlePos.tempPosition;
            TargetIndexKnucklePos = TipPinchIndexKnucklePos.tempPosition;
            TargetMetaIndexPos = TipPinchMetaIndexPos.tempPosition;
            TargetMiddleTipPos = TipPinchMiddleTipPos.tempPosition;
            TargetMiddleDistalPos = TipPinchMiddleDistalPos.tempPosition;
            TargetMiddleMiddlePos = TipPinchMiddleMiddlePos.tempPosition;
            TargetMiddleKnucklePos = TipPinchMiddleKnucklePos.tempPosition;
            TargetMetaMiddlePos = TipPinchMetaMiddlePos.tempPosition;
            TargetRingTipPos = TipPinchRingTipPos.tempPosition;
            TargetRingDistalPos = TipPinchRingDistalPos.tempPosition;
            TargetRingMiddlePos = TipPinchRingMiddlePos.tempPosition;
            TargetRingKnucklePos = TipPinchRingKnucklePos.tempPosition;
            TargetMetaRingPos = TipPinchMetaRingPos.tempPosition;
            TargetPinkyTipPos = TipPinchPinkyTipPos.tempPosition;
            TargetPinkyDistalPos = TipPinchPinkyDistalPos.tempPosition;
            TargetPinkyMiddlePos = TipPinchPinkyMiddlePos.tempPosition;
            TargetPinkyKnucklePos = TipPinchPinkyKnucklePos.tempPosition;
            TargetMetaPinkyPos = TipPinchMetaPinkyPos.tempPosition;
            TargetWristPos = TipPinchWristPos.tempPosition;
            TargetPalmPos = TipPinchPalmPos.tempPosition;
            TargetPalmRot = TipPinchPalmPos.tempRotation;
        }

        if (LargeDiameter.GraspState == 1)
        {
            TargetThumbTipPos = LargeDiameterThumbTipPos.tempPosition;
            TargetThumbDistalPos = LargeDiameterThumbDistalPos.tempPosition;
            TargetThumbProximalPos = LargeDiameterThumbProximalPos.tempPosition;
            TargetMetaThumbPos = LargeDiameterMetaThumbPos.tempPosition;
            TargetIndexTipPos = LargeDiameterIndexTipPos.tempPosition;
            TargetIndexDistalPos = LargeDiameterIndexDistalPos.tempPosition;
            TargetIndexMiddlePos = LargeDiameterIndexMiddlePos.tempPosition;
            TargetIndexKnucklePos = LargeDiameterIndexKnucklePos.tempPosition;
            TargetMetaIndexPos = LargeDiameterMetaIndexPos.tempPosition;
            TargetMiddleTipPos = LargeDiameterMiddleTipPos.tempPosition;
            TargetMiddleDistalPos = LargeDiameterMiddleDistalPos.tempPosition;
            TargetMiddleMiddlePos = LargeDiameterMiddleMiddlePos.tempPosition;
            TargetMiddleKnucklePos = LargeDiameterMiddleKnucklePos.tempPosition;
            TargetMetaMiddlePos = LargeDiameterMetaMiddlePos.tempPosition;
            TargetRingTipPos = LargeDiameterRingTipPos.tempPosition;
            TargetRingDistalPos = LargeDiameterRingDistalPos.tempPosition;
            TargetRingMiddlePos = LargeDiameterRingMiddlePos.tempPosition;
            TargetRingKnucklePos = LargeDiameterRingKnucklePos.tempPosition;
            TargetMetaRingPos = LargeDiameterMetaRingPos.tempPosition;
            TargetPinkyTipPos = LargeDiameterPinkyTipPos.tempPosition;
            TargetPinkyDistalPos = LargeDiameterPinkyDistalPos.tempPosition;
            TargetPinkyMiddlePos = LargeDiameterPinkyMiddlePos.tempPosition;
            TargetPinkyKnucklePos = LargeDiameterPinkyKnucklePos.tempPosition;
            TargetMetaPinkyPos = LargeDiameterMetaPinkyPos.tempPosition;
            TargetWristPos = LargeDiameterWristPos.tempPosition;
            TargetPalmPos = LargeDiameterPalmPos.tempPositon;
            TargetPalmRot = LargeDiameterPalmPos.tempRotation;
        }

        if (TherapistJoints.GraspState == 1)
        {
            TargetThumbTipPos = TherapistThumbTipPos.tempPosition;
            TargetThumbDistalPos = TherapistThumbDistalPos.tempPosition;
            TargetThumbProximalPos = TherapistThumbProximalPos.tempPosition;
            TargetMetaThumbPos = TherapistMetaThumbPos.tempPosition;
            TargetIndexTipPos = TherapistIndexTipPos.tempPosition;
            TargetIndexDistalPos = TherapistIndexDistalPos.tempPosition;
            TargetIndexMiddlePos = TherapistIndexMiddlePos.tempPosition;
            TargetIndexKnucklePos = TherapistIndexKnucklePos.tempPosition;
            TargetMetaIndexPos = TherapistMetaIndexPos.tempPosition;
            TargetMiddleTipPos = TherapistMiddleTipPos.tempPosition;
            TargetMiddleDistalPos = TherapistMiddleDistalPos.tempPosition;
            TargetMiddleMiddlePos = TherapistMiddleMiddlePos.tempPosition;
            TargetMiddleKnucklePos = TherapistMiddleKnucklePos.tempPosition;
            TargetMetaMiddlePos = TherapistMetaMiddlePos.tempPosition;
            TargetRingTipPos = TherapistRingTipPos.tempPosition;
            TargetRingDistalPos = TherapistRingDistalPos.tempPosition;
            TargetRingMiddlePos = TherapistRingMiddlePos.tempPosition;
            TargetRingKnucklePos = TherapistRingKnucklePos.tempPosition;
            TargetMetaRingPos = TherapistMetaRingPos.tempPosition;
            TargetPinkyTipPos = TherapistPinkyTipPos.tempPosition;
            TargetPinkyDistalPos = TherapistPinkyDistalPos.tempPosition;
            TargetPinkyMiddlePos = TherapistPinkyMiddlePos.tempPosition;
            TargetPinkyKnucklePos = TherapistPinkyKnucklePos.tempPosition;
            TargetMetaPinkyPos = TherapistMetaPinkyPos.tempPosition;
            TargetWristPos = TherapistWristPos.tempPosition;
            TargetPalmPos = TherapistPalmPos.tempPosition;
            TargetPalmRot = TherapistPalmPos.tempRotation;
        }

        // calculate target angles


        TargetMetaThumbAngle = functions.CalculateAngle(TargetWristPos.x, TargetWristPos.y, TargetWristPos.z,
                                                        TargetMetaThumbPos.x, TargetMetaThumbPos.y, TargetMetaThumbPos.z,
                                                        TargetThumbProximalPos.x, TargetThumbProximalPos.y, TargetThumbProximalPos.z);
        TargetThumbKnuckleAngle = functions.CalculateAngle(TargetMetaThumbPos.x, TargetMetaThumbPos.y, TargetMetaThumbPos.z,
                                                         TargetThumbProximalPos.x, TargetThumbProximalPos.y, TargetThumbProximalPos.z,
                                                         TargetThumbDistalPos.x, TargetThumbDistalPos.y, TargetThumbDistalPos.z);
        TargetThumbDistalAngle = functions.CalculateAngle(TargetThumbProximalPos.x, TargetThumbProximalPos.y, TargetThumbProximalPos.z,
                                                                TargetThumbDistalPos.x, TargetThumbDistalPos.y, TargetThumbDistalPos.z,
                                                                TargetThumbTipPos.x, TargetThumbTipPos.y, TargetThumbTipPos.z);
        TargetIndexKnuckleAngle = functions.CalculateAngle(TargetMetaIndexPos.x, TargetMetaIndexPos.y, TargetMetaIndexPos.z,
                                                                 TargetIndexKnucklePos.x, TargetIndexKnucklePos.y, TargetIndexKnucklePos.z,
                                                                 TargetIndexMiddlePos.x, TargetIndexMiddlePos.y, TargetIndexMiddlePos.z);
        TargetIndexMiddleAngle = functions.CalculateAngle(TargetIndexKnucklePos.x, TargetIndexKnucklePos.y, TargetIndexKnucklePos.z,
                                                                TargetIndexMiddlePos.x, TargetIndexMiddlePos.y, TargetIndexMiddlePos.z,
                                                                TargetIndexDistalPos.x, TargetIndexDistalPos.y, TargetIndexDistalPos.z);
        TargetIndexDistalAngle = functions.CalculateAngle(TargetIndexMiddlePos.x, TargetIndexMiddlePos.y, TargetIndexMiddlePos.z,
                                                                TargetIndexDistalPos.x, TargetIndexDistalPos.y, TargetIndexDistalPos.z,
                                                                TargetIndexTipPos.x, TargetIndexTipPos.y, TargetIndexTipPos.z);
        TargetMiddleKnuckleAngle = functions.CalculateAngle(TargetMetaMiddlePos.x, TargetMetaMiddlePos.y, TargetMetaMiddlePos.z,
                                                                  TargetMiddleKnucklePos.x, TargetMiddleKnucklePos.y, TargetMiddleKnucklePos.z,
                                                                  TargetMiddleMiddlePos.x, TargetMiddleMiddlePos.y, TargetMiddleMiddlePos.z);
        TargetMiddleMiddleAngle = functions.CalculateAngle(TargetMiddleKnucklePos.x, TargetMiddleKnucklePos.y, TargetMiddleKnucklePos.z,
                                                                 TargetMiddleMiddlePos.x, TargetMiddleMiddlePos.y, TargetMiddleMiddlePos.z,
                                                                 TargetMiddleDistalPos.x, TargetMiddleDistalPos.y, TargetMiddleDistalPos.z);
        TargetMiddleDistalAngle = functions.CalculateAngle(TargetMiddleMiddlePos.x, TargetMiddleMiddlePos.y, TargetMiddleMiddlePos.z,
                                                                 TargetMiddleDistalPos.x, TargetMiddleDistalPos.y, TargetMiddleDistalPos.z,
                                                                 TargetMiddleTipPos.x, TargetMiddleTipPos.y, TargetMiddleTipPos.z);
        TargetRingKnuckleAngle = functions.CalculateAngle(TargetMetaRingPos.x, TargetMetaRingPos.y, TargetMetaRingPos.z,
                                                                TargetRingKnucklePos.x, TargetRingKnucklePos.y, TargetRingKnucklePos.z,
                                                                TargetRingMiddlePos.x, TargetRingMiddlePos.y, TargetRingMiddlePos.z);
        TargetRingMiddleAngle = functions.CalculateAngle(TargetRingKnucklePos.x, TargetRingKnucklePos.y, TargetRingKnucklePos.z,
                                                               TargetRingMiddlePos.x, TargetRingMiddlePos.y, TargetRingMiddlePos.z,
                                                               TargetRingDistalPos.x, TargetRingDistalPos.y, TargetRingDistalPos.z);
        TargetRingDistalAngle = functions.CalculateAngle(TargetRingMiddlePos.x, TargetRingMiddlePos.y, TargetRingMiddlePos.z,
                                                               TargetRingDistalPos.x, TargetRingDistalPos.y, TargetRingDistalPos.z,
                                                               TargetRingTipPos.x, TargetRingTipPos.y, TargetRingTipPos.z);
        TargetPinkyKnuckleAngle = functions.CalculateAngle(TargetMetaPinkyPos.x, TargetMetaPinkyPos.y, TargetMetaPinkyPos.z,
                                                                 TargetPinkyKnucklePos.x, TargetPinkyKnucklePos.y, TargetPinkyKnucklePos.z,
                                                                 TargetPinkyMiddlePos.x, TargetPinkyMiddlePos.y, TargetPinkyMiddlePos.z);
        TargetPinkyMiddleAngle = functions.CalculateAngle(TargetPinkyKnucklePos.x, TargetPinkyKnucklePos.y, TargetPinkyKnucklePos.z,
                                                                TargetPinkyMiddlePos.x, TargetPinkyMiddlePos.y, TargetPinkyMiddlePos.z,
                                                                TargetPinkyDistalPos.x, TargetPinkyDistalPos.y, TargetPinkyDistalPos.z);
        TargetPinkyDistalAngle = functions.CalculateAngle(TargetPinkyMiddlePos.x, TargetPinkyMiddlePos.y, TargetPinkyMiddlePos.z,
                                                                TargetPinkyDistalPos.x, TargetPinkyDistalPos.y, TargetPinkyDistalPos.z,
                                                                TargetPinkyTipPos.x, TargetPinkyTipPos.y, TargetPinkyTipPos.z);


        // make the target angles more flexed to increase the range of error values

        TargetIndexKnuckleAngle = TargetIndexKnuckleAngle - 10f;
        TargetMiddleKnuckleAngle = TargetMiddleKnuckleAngle - 10f;
        TargetRingKnuckleAngle = TargetRingKnuckleAngle - 10f;
        TargetPinkyKnuckleAngle = TargetPinkyKnuckleAngle - 10f;
    }

    // function to get target angles for therapist pose early so can be used to draw rendered hand mesh

    public void TherapistAngles()
    {

        TargetThumbTipPos = TherapistThumbTipPos.tempPosition;
        TargetThumbDistalPos = TherapistThumbDistalPos.tempPosition;
        TargetThumbProximalPos = TherapistThumbProximalPos.tempPosition;
        TargetMetaThumbPos = TherapistMetaThumbPos.tempPosition;
        TargetIndexTipPos = TherapistIndexTipPos.tempPosition;
        TargetIndexDistalPos = TherapistIndexDistalPos.tempPosition;
        TargetIndexMiddlePos = TherapistIndexMiddlePos.tempPosition;
        TargetIndexKnucklePos = TherapistIndexKnucklePos.tempPosition;
        TargetMetaIndexPos = TherapistMetaIndexPos.tempPosition;
        TargetMiddleTipPos = TherapistMiddleTipPos.tempPosition;
        TargetMiddleDistalPos = TherapistMiddleDistalPos.tempPosition;
        TargetMiddleMiddlePos = TherapistMiddleMiddlePos.tempPosition;
        TargetMiddleKnucklePos = TherapistMiddleKnucklePos.tempPosition;
        TargetMetaMiddlePos = TherapistMetaMiddlePos.tempPosition;
        TargetRingTipPos = TherapistRingTipPos.tempPosition;
        TargetRingDistalPos = TherapistRingDistalPos.tempPosition;
        TargetRingMiddlePos = TherapistRingMiddlePos.tempPosition;
        TargetRingKnucklePos = TherapistRingKnucklePos.tempPosition;
        TargetMetaRingPos = TherapistMetaRingPos.tempPosition;
        TargetPinkyTipPos = TherapistPinkyTipPos.tempPosition;
        TargetPinkyDistalPos = TherapistPinkyDistalPos.tempPosition;
        TargetPinkyMiddlePos = TherapistPinkyMiddlePos.tempPosition;
        TargetPinkyKnucklePos = TherapistPinkyKnucklePos.tempPosition;
        TargetMetaPinkyPos = TherapistMetaPinkyPos.tempPosition;
        TargetWristPos = TherapistWristPos.tempPosition;
        TargetPalmPos = TherapistPalmPos.tempPosition;
        TargetPalmRot = TherapistPalmPos.tempRotation;

        targetThumbTriangleAngle = functions.CalculateAngle(TargetThumbProximalPos.x, TargetThumbProximalPos.y, TargetThumbProximalPos.z,
                                                            TargetThumbDistalPos.x, TargetThumbDistalPos.y, TargetThumbDistalPos.z,
                                                            TargetIndexKnucklePos.x, TargetIndexKnucklePos.y, TargetIndexKnucklePos.z);
        TargetMetaThumbAngle = functions.CalculateAngle(TargetWristPos.x, TargetWristPos.y, TargetWristPos.z,
                                                        TargetMetaThumbPos.x, TargetMetaThumbPos.y, TargetMetaThumbPos.z,
                                                        TargetThumbProximalPos.x, TargetThumbProximalPos.y, TargetThumbProximalPos.z);
        TargetThumbKnuckleAngle = functions.CalculateAngle(TargetMetaThumbPos.x, TargetMetaThumbPos.y, TargetMetaThumbPos.z,
                                                            TargetThumbProximalPos.x, TargetThumbProximalPos.y, TargetThumbProximalPos.z,
                                                            TargetThumbDistalPos.x, TargetThumbDistalPos.y, TargetThumbDistalPos.z);
        TargetThumbDistalAngle = functions.CalculateAngle(TargetThumbProximalPos.x, TargetThumbProximalPos.y, TargetThumbProximalPos.z,
                                                                TargetThumbDistalPos.x, TargetThumbDistalPos.y, TargetThumbDistalPos.z,
                                                                TargetThumbTipPos.x, TargetThumbTipPos.y, TargetThumbTipPos.z);
        TargetIndexKnuckleAngle = functions.CalculateAngle(TargetMetaIndexPos.x, TargetMetaIndexPos.y, TargetMetaIndexPos.z,
                                                                    TargetIndexKnucklePos.x, TargetIndexKnucklePos.y, TargetIndexKnucklePos.z,
                                                                    TargetIndexMiddlePos.x, TargetIndexMiddlePos.y, TargetIndexMiddlePos.z);
        TargetIndexMiddleAngle = functions.CalculateAngle(TargetIndexKnucklePos.x, TargetIndexKnucklePos.y, TargetIndexKnucklePos.z,
                                                                TargetIndexMiddlePos.x, TargetIndexMiddlePos.y, TargetIndexMiddlePos.z,
                                                                TargetIndexDistalPos.x, TargetIndexDistalPos.y, TargetIndexDistalPos.z);
        TargetIndexDistalAngle = functions.CalculateAngle(TargetIndexMiddlePos.x, TargetIndexMiddlePos.y, TargetIndexMiddlePos.z,
                                                                TargetIndexDistalPos.x, TargetIndexDistalPos.y, TargetIndexDistalPos.z,
                                                                TargetIndexTipPos.x, TargetIndexTipPos.y, TargetIndexTipPos.z);
        TargetMiddleKnuckleAngle = functions.CalculateAngle(TargetMetaMiddlePos.x, TargetMetaMiddlePos.y, TargetMetaMiddlePos.z,
                                                                    TargetMiddleKnucklePos.x, TargetMiddleKnucklePos.y, TargetMiddleKnucklePos.z,
                                                                    TargetMiddleMiddlePos.x, TargetMiddleMiddlePos.y, TargetMiddleMiddlePos.z);
        TargetMiddleMiddleAngle = functions.CalculateAngle(TargetMiddleKnucklePos.x, TargetMiddleKnucklePos.y, TargetMiddleKnucklePos.z,
                                                                    TargetMiddleMiddlePos.x, TargetMiddleMiddlePos.y, TargetMiddleMiddlePos.z,
                                                                    TargetMiddleDistalPos.x, TargetMiddleDistalPos.y, TargetMiddleDistalPos.z);
        TargetMiddleDistalAngle = functions.CalculateAngle(TargetMiddleMiddlePos.x, TargetMiddleMiddlePos.y, TargetMiddleMiddlePos.z,
                                                                    TargetMiddleDistalPos.x, TargetMiddleDistalPos.y, TargetMiddleDistalPos.z,
                                                                    TargetMiddleTipPos.x, TargetMiddleTipPos.y, TargetMiddleTipPos.z);
        TargetRingKnuckleAngle = functions.CalculateAngle(TargetMetaRingPos.x, TargetMetaRingPos.y, TargetMetaRingPos.z,
                                                                TargetRingKnucklePos.x, TargetRingKnucklePos.y, TargetRingKnucklePos.z,
                                                                TargetRingMiddlePos.x, TargetRingMiddlePos.y, TargetRingMiddlePos.z);
        TargetRingMiddleAngle = functions.CalculateAngle(TargetRingKnucklePos.x, TargetRingKnucklePos.y, TargetRingKnucklePos.z,
                                                                TargetRingMiddlePos.x, TargetRingMiddlePos.y, TargetRingMiddlePos.z,
                                                                TargetRingDistalPos.x, TargetRingDistalPos.y, TargetRingDistalPos.z);
        TargetRingDistalAngle = functions.CalculateAngle(TargetRingMiddlePos.x, TargetRingMiddlePos.y, TargetRingMiddlePos.z,
                                                                TargetRingDistalPos.x, TargetRingDistalPos.y, TargetRingDistalPos.z,
                                                                TargetRingTipPos.x, TargetRingTipPos.y, TargetRingTipPos.z);
        TargetPinkyKnuckleAngle = functions.CalculateAngle(TargetMetaPinkyPos.x, TargetMetaPinkyPos.y, TargetMetaPinkyPos.z,
                                                                    TargetPinkyKnucklePos.x, TargetPinkyKnucklePos.y, TargetPinkyKnucklePos.z,
                                                                    TargetPinkyMiddlePos.x, TargetPinkyMiddlePos.y, TargetPinkyMiddlePos.z);
        TargetPinkyMiddleAngle = functions.CalculateAngle(TargetPinkyKnucklePos.x, TargetPinkyKnucklePos.y, TargetPinkyKnucklePos.z,
                                                                TargetPinkyMiddlePos.x, TargetPinkyMiddlePos.y, TargetPinkyMiddlePos.z,
                                                                TargetPinkyDistalPos.x, TargetPinkyDistalPos.y, TargetPinkyDistalPos.z);
        TargetPinkyDistalAngle = functions.CalculateAngle(TargetPinkyMiddlePos.x, TargetPinkyMiddlePos.y, TargetPinkyMiddlePos.z,
                                                                TargetPinkyDistalPos.x, TargetPinkyDistalPos.y, TargetPinkyDistalPos.z,
                                                                TargetPinkyTipPos.x, TargetPinkyTipPos.y, TargetPinkyTipPos.z);

        //print(targetThumbTriangleAngle);
        //print(TargetMetaThumbAngle);
        //print(TargetThumbKnuckleAngle);
        //print(TargetMiddleMiddleAngle);
        //print(TargetThumbDistalAngle);



    }

    // function to calculate and display angle differences

    public void AngleDifferences()
    {

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // calculate angles of target and actual postures, calculate differences, try showing them in registered space...

        TargetMetaThumbAngle = functions.CalculateAngle(TargetWristPos.x, TargetWristPos.y, TargetWristPos.z,
                                                TargetMetaThumbPos.x, TargetMetaThumbPos.y, TargetMetaThumbPos.z,
                                                TargetThumbProximalPos.x, TargetThumbProximalPos.y, TargetThumbProximalPos.z);
        TargetThumbKnuckleAngle = functions.CalculateAngle(TargetMetaThumbPos.x, TargetMetaThumbPos.y, TargetMetaThumbPos.z,
                                                                 TargetThumbProximalPos.x, TargetThumbProximalPos.y, TargetThumbProximalPos.z,
                                                                 TargetThumbDistalPos.x, TargetThumbDistalPos.y, TargetThumbDistalPos.z);
        TargetThumbDistalAngle = functions.CalculateAngle(TargetThumbProximalPos.x, TargetThumbProximalPos.y, TargetThumbProximalPos.z,
                                                                TargetThumbDistalPos.x, TargetThumbDistalPos.y, TargetThumbDistalPos.z,
                                                                TargetThumbTipPos.x, TargetThumbTipPos.y, TargetThumbTipPos.z);
        TargetIndexKnuckleAngle = functions.CalculateAngle(TargetMetaIndexPos.x, TargetMetaIndexPos.y, TargetMetaIndexPos.z,
                                                                 TargetIndexKnucklePos.x, TargetIndexKnucklePos.y, TargetIndexKnucklePos.z,
                                                                 TargetIndexMiddlePos.x, TargetIndexMiddlePos.y, TargetIndexMiddlePos.z);
        TargetIndexMiddleAngle = functions.CalculateAngle(TargetIndexKnucklePos.x, TargetIndexKnucklePos.y, TargetIndexKnucklePos.z,
                                                                TargetIndexMiddlePos.x, TargetIndexMiddlePos.y, TargetIndexMiddlePos.z,
                                                                TargetIndexDistalPos.x, TargetIndexDistalPos.y, TargetIndexDistalPos.z);
        TargetIndexDistalAngle = functions.CalculateAngle(TargetIndexMiddlePos.x, TargetIndexMiddlePos.y, TargetIndexMiddlePos.z,
                                                                TargetIndexDistalPos.x, TargetIndexDistalPos.y, TargetIndexDistalPos.z,
                                                                TargetIndexTipPos.x, TargetIndexTipPos.y, TargetIndexTipPos.z);
        TargetMiddleKnuckleAngle = functions.CalculateAngle(TargetMetaMiddlePos.x, TargetMetaMiddlePos.y, TargetMetaMiddlePos.z,
                                                                  TargetMiddleKnucklePos.x, TargetMiddleKnucklePos.y, TargetMiddleKnucklePos.z,
                                                                  TargetMiddleMiddlePos.x, TargetMiddleMiddlePos.y, TargetMiddleMiddlePos.z);
        TargetMiddleMiddleAngle = functions.CalculateAngle(TargetMiddleKnucklePos.x, TargetMiddleKnucklePos.y, TargetMiddleKnucklePos.z,
                                                                 TargetMiddleMiddlePos.x, TargetMiddleMiddlePos.y, TargetMiddleMiddlePos.z,
                                                                 TargetMiddleDistalPos.x, TargetMiddleDistalPos.y, TargetMiddleDistalPos.z);
        TargetMiddleDistalAngle = functions.CalculateAngle(TargetMiddleMiddlePos.x, TargetMiddleMiddlePos.y, TargetMiddleMiddlePos.z,
                                                                 TargetMiddleDistalPos.x, TargetMiddleDistalPos.y, TargetMiddleDistalPos.z,
                                                                 TargetMiddleTipPos.x, TargetMiddleTipPos.y, TargetMiddleTipPos.z);
        TargetRingKnuckleAngle = functions.CalculateAngle(TargetMetaRingPos.x, TargetMetaRingPos.y, TargetMetaRingPos.z,
                                                                TargetRingKnucklePos.x, TargetRingKnucklePos.y, TargetRingKnucklePos.z,
                                                                TargetRingMiddlePos.x, TargetRingMiddlePos.y, TargetRingMiddlePos.z);
        TargetRingMiddleAngle = functions.CalculateAngle(TargetRingKnucklePos.x, TargetRingKnucklePos.y, TargetRingKnucklePos.z,
                                                               TargetRingMiddlePos.x, TargetRingMiddlePos.y, TargetRingMiddlePos.z,
                                                               TargetRingDistalPos.x, TargetRingDistalPos.y, TargetRingDistalPos.z);
        TargetRingDistalAngle = functions.CalculateAngle(TargetRingMiddlePos.x, TargetRingMiddlePos.y, TargetRingMiddlePos.z,
                                                               TargetRingDistalPos.x, TargetRingDistalPos.y, TargetRingDistalPos.z,
                                                               TargetRingTipPos.x, TargetRingTipPos.y, TargetRingTipPos.z);
        TargetPinkyKnuckleAngle = functions.CalculateAngle(TargetMetaPinkyPos.x, TargetMetaPinkyPos.y, TargetMetaPinkyPos.z,
                                                                 TargetPinkyKnucklePos.x, TargetPinkyKnucklePos.y, TargetPinkyKnucklePos.z,
                                                                 TargetPinkyMiddlePos.x, TargetPinkyMiddlePos.y, TargetPinkyMiddlePos.z);
        TargetPinkyMiddleAngle = functions.CalculateAngle(TargetPinkyKnucklePos.x, TargetPinkyKnucklePos.y, TargetPinkyKnucklePos.z,
                                                                TargetPinkyMiddlePos.x, TargetPinkyMiddlePos.y, TargetPinkyMiddlePos.z,
                                                                TargetPinkyDistalPos.x, TargetPinkyDistalPos.y, TargetPinkyDistalPos.z);
        TargetPinkyDistalAngle = functions.CalculateAngle(TargetPinkyMiddlePos.x, TargetPinkyMiddlePos.y, TargetPinkyMiddlePos.z,
                                                                TargetPinkyDistalPos.x, TargetPinkyDistalPos.y, TargetPinkyDistalPos.z,
                                                                TargetPinkyTipPos.x, TargetPinkyTipPos.y, TargetPinkyTipPos.z);

        // wrist is tricky because don't have forearm position
        /*        float TargetWristAngle = functions.CalculateAngle(TargetWristPos.x, TargetWristPos.y, TargetWristPos.z,
                                                                  TargetMetaMiddlePos.x, TargetMetaMiddlePos.y, TargetMetaMiddlePos.z,
                                                                  TargetMiddleKnucklePos.x, TargetMiddleKnucklePos.y, TargetMiddleKnucklePos.z);*/

        // actual angles
        ThumbIndexDistance = Mathf.Sqrt((Mathf.Pow(ThumbDistalPos.tempPosition.x - IndexKnucklePos.tempPosition.x, 2)) +
                                        (Mathf.Pow(ThumbDistalPos.tempPosition.y - IndexKnucklePos.tempPosition.y, 2) +
                                        (Mathf.Pow(ThumbDistalPos.tempPosition.z - IndexKnucklePos.tempPosition.z, 2))));

        MetaThumbAngle = functions.CalculateAngle(WristPos.tempPosition.x, WristPos.tempPosition.y, WristPos.tempPosition.z,
                                                  MetaThumbPos.tempPosition.x, MetaThumbPos.tempPosition.y, MetaThumbPos.tempPosition.z,
                                                  ThumbProximalPos.tempPosition.x, ThumbProximalPos.tempPosition.y, ThumbProximalPos.tempPosition.z);
        ActualThumbTriangleAngle = functions.CalculateAngle(ThumbProximalPos.tempPosition.x, ThumbProximalPos.tempPosition.y, ThumbProximalPos.tempPosition.z,
                                                            ThumbDistalPos.tempPosition.x, ThumbDistalPos.tempPosition.y, ThumbDistalPos.tempPosition.z,
                                                            IndexKnucklePos.tempPosition.x, IndexKnucklePos.tempPosition.y, IndexKnucklePos.tempPosition.z);
        ThumbKnuckleAngle = functions.CalculateAngle(MetaThumbPos.tempPosition.x, MetaThumbPos.tempPosition.y, MetaThumbPos.tempPosition.z,
                                                                 ThumbProximalPos.tempPosition.x, ThumbProximalPos.tempPosition.y, ThumbProximalPos.tempPosition.z,
                                                                 ThumbDistalPos.tempPosition.x, ThumbDistalPos.tempPosition.y, ThumbDistalPos.tempPosition.z);
        ThumbDistalAngle = functions.CalculateAngle(ThumbProximalPos.tempPosition.x, ThumbProximalPos.tempPosition.y, ThumbProximalPos.tempPosition.z,
                                                                ThumbDistalPos.tempPosition.x, ThumbDistalPos.tempPosition.y, ThumbDistalPos.tempPosition.z,
                                                                ThumbTipPos.tempPosition.x, ThumbTipPos.tempPosition.y, ThumbTipPos.tempPosition.z);
        IndexKnuckleAngle = functions.CalculateAngle(MetaIndexPos.tempPosition.x, MetaIndexPos.tempPosition.y, MetaIndexPos.tempPosition.z,
                                                           IndexKnucklePos.tempPosition.x, IndexKnucklePos.tempPosition.y, IndexKnucklePos.tempPosition.z,
                                                           IndexMiddlePos.tempPosition.x, IndexMiddlePos.tempPosition.y, IndexMiddlePos.tempPosition.z);
        IndexMiddleAngle = functions.CalculateAngle(IndexKnucklePos.tempPosition.x, IndexKnucklePos.tempPosition.y, IndexKnucklePos.tempPosition.z,
                                                          IndexMiddlePos.tempPosition.x, IndexMiddlePos.tempPosition.y, IndexMiddlePos.tempPosition.z,
                                                          IndexDistalPos.tempPosition.x, IndexDistalPos.tempPosition.y, IndexDistalPos.tempPosition.z);
        IndexDistalAngle = functions.CalculateAngle(IndexMiddlePos.tempPosition.x, IndexMiddlePos.tempPosition.y, IndexMiddlePos.tempPosition.z,
                                                          IndexDistalPos.tempPosition.x, IndexDistalPos.tempPosition.y, IndexDistalPos.tempPosition.z,
                                                          IndexTipPos.tempPosition.x, IndexTipPos.tempPosition.y, IndexTipPos.tempPosition.z);
        MiddleKnuckleAngle = functions.CalculateAngle(MetaMiddlePos.tempPosition.x, MetaMiddlePos.tempPosition.y, MetaMiddlePos.tempPosition.z,
                                                            MiddleKnucklePos.tempPosition.x, MiddleKnucklePos.tempPosition.y, MiddleKnucklePos.tempPosition.z,
                                                            MiddleMiddlePos.tempPosition.x, MiddleMiddlePos.tempPosition.y, MiddleMiddlePos.tempPosition.z);
        MiddleMiddleAngle = functions.CalculateAngle(MiddleKnucklePos.tempPosition.x, MiddleKnucklePos.tempPosition.y, MiddleKnucklePos.tempPosition.z,
                                                           MiddleMiddlePos.tempPosition.x, MiddleMiddlePos.tempPosition.y, MiddleMiddlePos.tempPosition.z,
                                                           MiddleDistalPos.tempPosition.x, MiddleDistalPos.tempPosition.y, MiddleDistalPos.tempPosition.z);
        MiddleDistalAngle = functions.CalculateAngle(MiddleMiddlePos.tempPosition.x, MiddleMiddlePos.tempPosition.y, MiddleMiddlePos.tempPosition.z,
                                                           MiddleDistalPos.tempPosition.x, MiddleDistalPos.tempPosition.y, MiddleDistalPos.tempPosition.z,
                                                           MiddleTipPos.tempPosition.x, MiddleTipPos.tempPosition.y, MiddleTipPos.tempPosition.z);
        RingKnuckleAngle = functions.CalculateAngle(MetaRingPos.tempPosition.x, MetaRingPos.tempPosition.y, MetaRingPos.tempPosition.z,
                                                          RingKnucklePos.tempPosition.x, RingKnucklePos.tempPosition.y, RingKnucklePos.tempPosition.z,
                                                          RingMiddlePos.tempPosition.x, RingMiddlePos.tempPosition.y, RingMiddlePos.tempPosition.z);
        RingMiddleAngle = functions.CalculateAngle(RingKnucklePos.tempPosition.x, RingKnucklePos.tempPosition.y, RingKnucklePos.tempPosition.z,
                                                         RingMiddlePos.tempPosition.x, RingMiddlePos.tempPosition.y, RingMiddlePos.tempPosition.z,
                                                         RingDistalPos.tempPosition.x, RingDistalPos.tempPosition.y, RingDistalPos.tempPosition.z);
        RingDistalAngle = functions.CalculateAngle(RingMiddlePos.tempPosition.x, RingMiddlePos.tempPosition.y, RingMiddlePos.tempPosition.z,
                                                         RingDistalPos.tempPosition.x, RingDistalPos.tempPosition.y, RingDistalPos.tempPosition.z,
                                                         RingTipPos.tempPosition.x, RingTipPos.tempPosition.y, RingTipPos.tempPosition.z);
        PinkyKnuckleAngle = functions.CalculateAngle(MetaPinkyPos.tempPosition.x, MetaPinkyPos.tempPosition.y, MetaPinkyPos.tempPosition.z,
                                                           PinkyKnucklePos.tempPosition.x, PinkyKnucklePos.tempPosition.y, PinkyKnucklePos.tempPosition.z,
                                                           PinkyMiddlePos.tempPosition.x, PinkyMiddlePos.tempPosition.y, PinkyMiddlePos.tempPosition.z);
        PinkyMiddleAngle = functions.CalculateAngle(PinkyKnucklePos.tempPosition.x, PinkyKnucklePos.tempPosition.y, PinkyKnucklePos.tempPosition.z,
                                                          PinkyMiddlePos.tempPosition.x, PinkyMiddlePos.tempPosition.y, PinkyMiddlePos.tempPosition.z,
                                                          PinkyDistalPos.tempPosition.x, PinkyDistalPos.tempPosition.y, PinkyDistalPos.tempPosition.z);
        PinkyDistalAngle = functions.CalculateAngle(PinkyMiddlePos.tempPosition.x, PinkyMiddlePos.tempPosition.y, PinkyMiddlePos.tempPosition.z,
                                                                PinkyDistalPos.tempPosition.x, PinkyDistalPos.tempPosition.y, PinkyDistalPos.tempPosition.z,
                                                                PinkyTipPos.tempPosition.x, PinkyTipPos.tempPosition.y, PinkyTipPos.tempPosition.z);


        // calculate angle differences

        AbsThumbKnuckleAngleDiff = MathF.Abs(TargetThumbKnuckleAngle - ThumbKnuckleAngle);
        AbsThumbDistalAngleDiff = MathF.Abs(TargetThumbDistalAngle - ThumbDistalAngle);
        AbsIndexKnuckleAngleDiff = MathF.Abs(TargetIndexKnuckleAngle - IndexKnuckleAngle);
        AbsIndexMiddleAngleDiff = MathF.Abs(TargetIndexMiddleAngle - IndexMiddleAngle);
        AbsIndexDistalAngleDiff = MathF.Abs(TargetIndexDistalAngle - IndexDistalAngle);
        AbsMiddleKnuckleAngleDiff = MathF.Abs(TargetMiddleKnuckleAngle - MiddleKnuckleAngle);
        AbsMiddleMiddleAngleDiff = MathF.Abs(TargetMiddleMiddleAngle - MiddleMiddleAngle);
        AbsMiddleDistalAngleDiff = MathF.Abs(TargetMiddleDistalAngle - MiddleDistalAngle);
        AbsRingKnuckleAngleDiff = MathF.Abs(TargetRingKnuckleAngle - RingKnuckleAngle);
        AbsRingMiddleAngleDiff = MathF.Abs(TargetRingMiddleAngle - RingMiddleAngle);
        AbsRingDistalAngleDiff = MathF.Abs(TargetRingDistalAngle - RingDistalAngle);
        AbsPinkyKnuckleAngleDiff = MathF.Abs(TargetPinkyKnuckleAngle - PinkyKnuckleAngle);
        AbsPinkyMiddleAngleDiff = MathF.Abs(TargetPinkyMiddleAngle - PinkyMiddleAngle);
        AbsPinkyDistalAngleDiff = MathF.Abs(TargetPinkyDistalAngle - PinkyDistalAngle);

        // change what angles are included depending on the grasp type
        if (TipPinch.GraspState == 1)
        {
            JointAngle[] jointAngles = {new JointAngle {JointAngleName = "ThumbKnuckleAngle", JointAngleValue = AbsThumbKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "ThumbDistalAngle", JointAngleValue = AbsThumbDistalAngleDiff},
                                        new JointAngle {JointAngleName = "IndexKnuckleAngle", JointAngleValue = AbsIndexKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "IndexMiddleAngle", JointAngleValue = AbsIndexMiddleAngleDiff},
                                        new JointAngle {JointAngleName = "IndexDistalAngle", JointAngleValue = AbsIndexDistalAngleDiff} };

            IEnumerable<JointAngle> query2 = jointAngles.OrderBy(jointAngle => jointAngle.JointAngleValue);
            foreach (JointAngle jointAngle in query2)
            {
                // iterate to see largest angle difference, mean, and median
                MaxJointAngleDiffName = jointAngle.JointAngleName;
                MaxJointAngleDiff = jointAngle.JointAngleValue;
                DiffSum += jointAngle.JointAngleValue; // zero this out at end of outer loop
                JointCount += 1; // zero this out at end of outer loop
                /*                if (JointCount == 13) // middle value of total number of joints
                                {
                                    MedianJointAngleDiff = jointAngle.JointAngleValue;
                                    MedianJointAngleDiffName = jointAngle.JointAngleName;
                                }*/


            }
        }

        if (Lateral.GraspState == 1 || LargeDiameter.GraspState == 1 || TherapistJoints.GraspState == 1)
        {
            JointAngle[] jointAngles = {new JointAngle {JointAngleName = "ThumbKnuckleAngle", JointAngleValue = AbsThumbKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "ThumbDistalAngle", JointAngleValue = AbsThumbDistalAngleDiff},
                                        new JointAngle {JointAngleName = "IndexKnuckleAngle", JointAngleValue = AbsIndexKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "IndexMiddleAngle", JointAngleValue = AbsIndexMiddleAngleDiff},
                                        new JointAngle {JointAngleName = "IndexDistalAngle", JointAngleValue = AbsIndexDistalAngleDiff},
                                        new JointAngle {JointAngleName = "MiddleKnuckleAngle", JointAngleValue = AbsMiddleKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "MiddleMiddleAngle", JointAngleValue = AbsMiddleMiddleAngleDiff},
                                        new JointAngle {JointAngleName = "MiddleDistalAngle", JointAngleValue = AbsMiddleDistalAngleDiff},
                                        new JointAngle {JointAngleName = "RingKnuckleAngle", JointAngleValue = AbsRingKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "RingMiddleAngle", JointAngleValue = AbsRingMiddleAngleDiff},
                                        new JointAngle {JointAngleName = "RingDistalAngle", JointAngleValue = AbsRingDistalAngleDiff},
                                        new JointAngle {JointAngleName = "PinkyKnuckleAngle", JointAngleValue = AbsPinkyKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "PinkyMiddleAngle", JointAngleValue = AbsPinkyMiddleAngleDiff},
                                        new JointAngle {JointAngleName = "PinkyDistalAngle", JointAngleValue = AbsPinkyDistalAngleDiff} };

            IEnumerable<JointAngle> query2 = jointAngles.OrderBy(jointAngle => jointAngle.JointAngleValue);
            foreach (JointAngle jointAngle in query2)
            {
                // iterate to see largest angle difference, mean, and median
                MaxJointAngleDiffName = jointAngle.JointAngleName;
                MaxJointAngleDiff = jointAngle.JointAngleValue;
                DiffSum += jointAngle.JointAngleValue; // zero this out at end of outer loop
                JointCount += 1; // zero this out at end of outer loop
                /*                if (JointCount == 13) // middle value of total number of joints
                                {
                                    MedianJointAngleDiff = jointAngle.JointAngleValue;
                                    MedianJointAngleDiffName = jointAngle.JointAngleName;
                                }*/

            }
        }


        MeanAngleDiff = DiffSum / JointCount;
        MeanAngleDiff = Mathf.Round(MeanAngleDiff);

        // original unnormalized 

        DiffSumThumb = (AbsThumbKnuckleAngleDiff) + (AbsThumbDistalAngleDiff);
        DiffSumIndex = (AbsIndexKnuckleAngleDiff) + (AbsIndexMiddleAngleDiff) + (AbsIndexDistalAngleDiff);
        DiffSumMiddle = (AbsMiddleKnuckleAngleDiff) + (AbsMiddleMiddleAngleDiff) + (AbsMiddleDistalAngleDiff);
        DiffSumRing = (AbsRingKnuckleAngleDiff) + (AbsRingMiddleAngleDiff) + (AbsRingDistalAngleDiff);
        DiffSumPinky = (AbsPinkyKnuckleAngleDiff) + (AbsPinkyMiddleAngleDiff) + (AbsPinkyDistalAngleDiff);

        // normalized to reduce the weight of the finger tips/distal joints because they are less meaningful

        if (TipPinch.GraspState == 1)
        {
            DiffSumTotal = DiffSumThumb + DiffSumIndex;
        }
        if (Lateral.GraspState == 1 || LargeDiameter.GraspState == 1 || TherapistJoints.GraspState == 1)
        {
            DiffSumTotal = DiffSumThumb + DiffSumIndex + DiffSumMiddle + DiffSumRing + DiffSumPinky;
        }

        MeanAngleDiffTest = DiffSumTotal / JointCount;
        MeanAngleDiffTest = Mathf.Round(MeanAngleDiffTest);

        // different error score depending on weights for each grip 

        if (TipPinch.GraspState == 1)
        {
            ThumbErrorWeight = 0.5f;
            IndexErrorWeight = 0.5f;
            MiddleErrorWeight = 0f;
            RingErrorWeight = 0f;
            PinkyErrorWeight = 0f;
        }
        if (LargeDiameter.GraspState == 1)
        {
            ThumbErrorWeight = 0.2f;
            IndexErrorWeight = 0.2f;
            MiddleErrorWeight = 0.2f;
            RingErrorWeight = 0.2f;
            PinkyErrorWeight = 0.2f;
        }
        if (Lateral.GraspState == 1)
        {
            ThumbErrorWeight = 0.35f;
            IndexErrorWeight = 0.35f;
            MiddleErrorWeight = 0.1f;
            RingErrorWeight = 0.1f;
            PinkyErrorWeight = 0.1f;
        }

        // Weighted average

        // original... use with unnormalized sums
        NormalizedThumbError = DiffSumThumb / 2 * ThumbErrorWeight;
        NormalizedIndexError = DiffSumIndex / 3 * IndexErrorWeight;
        NormalizedMiddleError = DiffSumMiddle / 3 * MiddleErrorWeight;
        NormalizedRingError = DiffSumRing / 3 * RingErrorWeight;
        NormalizedPinkyError = DiffSumPinky / 3 * PinkyErrorWeight;

        // use with normalized sums 
        /*        NormalizedThumbError = DiffSumThumb * ThumbErrorWeight;
                NormalizedIndexError = DiffSumIndex * IndexErrorWeight;
                NormalizedMiddleError = DiffSumMiddle * MiddleErrorWeight;
                NormalizedRingError = DiffSumRing * RingErrorWeight;
                NormalizedPinkyError = DiffSumPinky * PinkyErrorWeight;*/

        NormalizedAverageError = NormalizedThumbError + NormalizedIndexError + NormalizedMiddleError + NormalizedRingError + NormalizedPinkyError;

        NormalizedAverageError = NormalizedAverageError - 5f; // 5 degrees error is the new zero, 5 degree error tolerance


        DiffSum = 0; // reset value 
        JointCount = 0; // reset value


        // create new overall score based on the MeanAngleDiff 
        // this should be out of 100 and displayed in a more intuitive and user friendly way

        if (positionset == 1)
        {

            // new overall score
            upperbound_error = 35f; // maximum error on our percentage scale... based on some estimates when trying the system... tinker with this if need too

            // upperbound error might need to change depending on target grasp (e.g., tippinch only incorporates two fingers into error)

            /*            if (TipPinch.GraspState == 1)
                        {
                            upperbound_error = 30f;
                        }
                        if (Lateral.GraspState == 1 || LargeDiameter.GraspState == 1)
                        {
                            upperbound_error = 40f;
                        }*/

            //OverallScore100 = 100 - ((MeanAngleDiff / upperbound_error) * 100);
            OverallScore100 = 100 - ((NormalizedAverageError / upperbound_error) * 100);
            OverallScore100 = Mathf.Round(OverallScore100);

            /*            if (MeanAngleDiff > upperbound_error)
                        {
                            OverallScore100 = 0;
                        }*/
            if (NormalizedAverageError > upperbound_error)
            {
                OverallScore100 = 0;
            }
            if (NormalizedAverageError <= 0)
            {
                OverallScore100 = 99;
            }

            overallScoreText_output.text = "" + OverallScore100 + "";

            if (OverallScore100 < 50)
            {
                overallMatchText_output.text = "Bad Match!";
                //overallMatchText_output.text = "" + MeanAngleDiff + "";
            }
            if (OverallScore100 > 49 && OverallScore100 < 75)
            {
                overallMatchText_output.text = "OK Match!";
                //overallMatchText_output.text = "" + MeanAngleDiff + "";
            }
            if (OverallScore100 > 74)
            {
                overallMatchText_output.text = "Great Match!";
                //overallMatchText_output.text = "" + MeanAngleDiff + "";
            }
            //Debug.Log(OverallScore100);

            float upperbound_color = 100f; // maximum greenness - flipped from old method... higher score is more green
            float color_multiplier = (1 / upperbound_color * 2);
            if (OverallScore100 < upperbound_color / 2)
            {
                float overall_score_temp = OverallScore100;
                if (overall_score_temp < upperbound_color * 0.1) // below 10% on task
                {
                    overall_score_temp = upperbound_color * 0.1f;
                }
                float r_color = 1f;
                float g_color = overall_score_temp * color_multiplier;
                float b_color = 0f;

                ScoreBackPlate.GetComponent<Renderer>().material.color = new Color(r_color, g_color, b_color, 1f);
                overallMatchText_output.color = new Color(r_color, g_color, b_color, 1f);

            }

            if (OverallScore100 == upperbound_color / 2)
            {
                float r_color = 1f;
                float g_color = 1f;
                float b_color = 0f;
                ScoreBackPlate.GetComponent<Renderer>().material.color = new Color(r_color, g_color, b_color, 1f);
                overallMatchText_output.color = new Color(r_color, g_color, b_color, 1f);

            }

            if (OverallScore100 > upperbound_color / 2)
            {
                float overall_score_temp = OverallScore100;
                if (overall_score_temp > upperbound_color * 0.9) // above 90% on task
                {
                    overall_score_temp = upperbound_color;
                }

                float r_color = 2f - (overall_score_temp * color_multiplier);
                float g_color = 1f;
                float b_color = 0f;
                ScoreBackPlate.GetComponent<Renderer>().material.color = new Color(r_color, g_color, b_color, 1f);
                overallMatchText_output.color = new Color(r_color, g_color, b_color, 1f);

            }

            //ScoreBackPlate.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        }

    }

    public void ContinuousErrorSignal()
    {
        MetaThumbAngle = functions.CalculateAngle(HandTracking.wristPos.x, HandTracking.wristPos.y, HandTracking.wristPos.z,
                                                 HandTracking.metaThumbPos.x, HandTracking.metaThumbPos.y, HandTracking.metaThumbPos.z,
                                                 HandTracking.thumbProximalPos.x, HandTracking.thumbProximalPos.y, HandTracking.thumbProximalPos.z);
        ThumbKnuckleAngle = functions.CalculateAngle(HandTracking.metaThumbPos.x, HandTracking.metaThumbPos.y, HandTracking.metaThumbPos.z,
                                                    HandTracking.thumbProximalPos.x, HandTracking.thumbProximalPos.y, HandTracking.thumbProximalPos.z,
                                                    HandTracking.thumbDistalPos.x, HandTracking.thumbDistalPos.y, HandTracking.thumbDistalPos.z);
        ThumbDistalAngle = functions.CalculateAngle(HandTracking.thumbProximalPos.x, HandTracking.thumbProximalPos.y, HandTracking.thumbProximalPos.z,
                                                    HandTracking.thumbDistalPos.x, HandTracking.thumbDistalPos.y, HandTracking.thumbDistalPos.z,
                                                    HandTracking.thumbTipPos.x, HandTracking.thumbTipPos.y, HandTracking.thumbTipPos.z);
        IndexKnuckleAngle = functions.CalculateAngle(HandTracking.metaIndexPos.x, HandTracking.metaIndexPos.y, HandTracking.metaIndexPos.z,
                                                    HandTracking.indexKnucklePos.x, HandTracking.indexKnucklePos.y, HandTracking.indexKnucklePos.z,
                                                    HandTracking.indexMiddlePos.x, HandTracking.indexMiddlePos.y, HandTracking.indexMiddlePos.z);
        IndexMiddleAngle = functions.CalculateAngle(HandTracking.indexKnucklePos.x, HandTracking.indexKnucklePos.y, HandTracking.indexKnucklePos.z,
                                                    HandTracking.indexMiddlePos.x, HandTracking.indexMiddlePos.y, HandTracking.indexMiddlePos.z,
                                                    HandTracking.indexDistalPos.x, HandTracking.indexDistalPos.y, HandTracking.indexDistalPos.z);
        IndexDistalAngle= functions.CalculateAngle(HandTracking.indexMiddlePos.x, HandTracking.indexMiddlePos.y, HandTracking.indexMiddlePos.z,
                                                    HandTracking.indexDistalPos.x, HandTracking.indexDistalPos.y, HandTracking.indexDistalPos.z,
                                                    HandTracking.indexTipPos.x, HandTracking.indexTipPos.y, HandTracking.indexTipPos.z);
        MiddleKnuckleAngle = functions.CalculateAngle(HandTracking.metaMiddlePos.x, HandTracking.metaMiddlePos.y, HandTracking.metaMiddlePos.z,
                                                    HandTracking.middleKnucklePos.x, HandTracking.middleKnucklePos.y, HandTracking.middleKnucklePos.z,
                                                    HandTracking.middleMiddlePos.x, HandTracking.middleMiddlePos.y, HandTracking.middleMiddlePos.z);
        MiddleMiddleAngle = functions.CalculateAngle(HandTracking.middleKnucklePos.x, HandTracking.middleKnucklePos.y, HandTracking.middleKnucklePos.z,
                                                    HandTracking.middleMiddlePos.x, HandTracking.middleMiddlePos.y, HandTracking.middleMiddlePos.z,
                                                    HandTracking.middleDistalPos.x, HandTracking.middleDistalPos.y, HandTracking.middleDistalPos.z);
        MiddleDistalAngle = functions.CalculateAngle(HandTracking.middleMiddlePos.x, HandTracking.middleMiddlePos.y, HandTracking.middleMiddlePos.z,
                                                    HandTracking.middleDistalPos.x, HandTracking.middleDistalPos.y, HandTracking.middleDistalPos.z,
                                                    HandTracking.middleTipPos.x, HandTracking.middleTipPos.y, HandTracking.middleTipPos.z);
        RingKnuckleAngle = functions.CalculateAngle(HandTracking.metaRingPos.x, HandTracking.metaRingPos.y, HandTracking.metaRingPos.z,
                                                    HandTracking.ringKnucklePos.x, HandTracking.ringKnucklePos.y, HandTracking.ringKnucklePos.z,
                                                    HandTracking.ringMiddlePos.x, HandTracking.ringMiddlePos.y, HandTracking.ringMiddlePos.z);
        RingMiddleAngle = functions.CalculateAngle(HandTracking.ringKnucklePos.x, HandTracking.ringKnucklePos.y, HandTracking.ringKnucklePos.z,
                                                            HandTracking.ringMiddlePos.x, HandTracking.ringMiddlePos.y, HandTracking.ringMiddlePos.z,
                                                            HandTracking.ringDistalPos.x, HandTracking.ringDistalPos.y, HandTracking.ringDistalPos.z);
        RingDistalAngle = functions.CalculateAngle(HandTracking.ringMiddlePos.x, HandTracking.ringMiddlePos.y, HandTracking.ringMiddlePos.z,
                                                    HandTracking.ringDistalPos.x, HandTracking.ringDistalPos.y, HandTracking.ringDistalPos.z,
                                                    HandTracking.ringTipPos.x, HandTracking.ringTipPos.y, HandTracking.ringTipPos.z);
        PinkyKnuckleAngle = functions.CalculateAngle(HandTracking.metaPinkyPos.x, HandTracking.metaPinkyPos.y, HandTracking.metaPinkyPos.z,
                                                    HandTracking.pinkyKnucklePos.x, HandTracking.pinkyKnucklePos.y, HandTracking.pinkyKnucklePos.z,
                                                    HandTracking.pinkyMiddlePos.x, HandTracking.pinkyMiddlePos.y, HandTracking.pinkyMiddlePos.z);
        PinkyKnuckleAngle = functions.CalculateAngle(HandTracking.pinkyKnucklePos.x, HandTracking.pinkyKnucklePos.y, HandTracking.pinkyKnucklePos.z,
                                                    HandTracking.pinkyMiddlePos.x, HandTracking.pinkyMiddlePos.y, HandTracking.pinkyMiddlePos.z,
                                                    HandTracking.pinkyDistalPos.x, HandTracking.pinkyDistalPos.y, HandTracking.pinkyDistalPos.z);
        PinkyDistalAngle = functions.CalculateAngle(HandTracking.pinkyMiddlePos.x, HandTracking.pinkyMiddlePos.y, HandTracking.pinkyMiddlePos.z,
                                                    HandTracking.pinkyDistalPos.x, HandTracking.pinkyDistalPos.y, HandTracking.pinkyDistalPos.z,
                                                    HandTracking.pinkyTipPos.x, HandTracking.pinkyTipPos.y, HandTracking.pinkyTipPos.z);


        // calculate absolute angle differences

        AbsThumbKnuckleAngleDiff = MathF.Abs(TargetThumbKnuckleAngle - ThumbKnuckleAngle);
        AbsThumbDistalAngleDiff = MathF.Abs(TargetThumbDistalAngle - ThumbDistalAngle);
        AbsIndexKnuckleAngleDiff = MathF.Abs(TargetIndexKnuckleAngle - IndexKnuckleAngle);
        AbsIndexMiddleAngleDiff = MathF.Abs(TargetIndexMiddleAngle - IndexMiddleAngle);
        AbsIndexDistalAngleDiff = MathF.Abs(TargetIndexDistalAngle - IndexDistalAngle);
        AbsMiddleKnuckleAngleDiff = MathF.Abs(TargetMiddleKnuckleAngle - MiddleKnuckleAngle);
        AbsMiddleMiddleAngleDiff = MathF.Abs(TargetMiddleMiddleAngle - MiddleMiddleAngle);
        AbsMiddleDistalAngleDiff = MathF.Abs(TargetMiddleDistalAngle - MiddleDistalAngle);
        AbsRingKnuckleAngleDiff = MathF.Abs(TargetRingKnuckleAngle - RingKnuckleAngle);
        AbsRingMiddleAngleDiff = MathF.Abs(TargetRingMiddleAngle - RingMiddleAngle);
        AbsRingDistalAngleDiff = MathF.Abs(TargetRingDistalAngle - RingDistalAngle);
        AbsPinkyKnuckleAngleDiff = MathF.Abs(TargetPinkyKnuckleAngle - PinkyKnuckleAngle);
        AbsPinkyMiddleAngleDiff = MathF.Abs(TargetPinkyMiddleAngle - PinkyMiddleAngle);
        AbsPinkyDistalAngleDiff = MathF.Abs(TargetPinkyDistalAngle - PinkyDistalAngle);

        // change what angles are included depending on the grasp type
        if (TipPinch.GraspState == 1)
        {
            JointAngle[] jointAngles = {new JointAngle {JointAngleName = "ThumbKnuckleAngle", JointAngleValue = AbsThumbKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "ThumbDistalAngle", JointAngleValue = AbsThumbDistalAngleDiff},
                                        new JointAngle {JointAngleName = "IndexKnuckleAngle", JointAngleValue = AbsIndexKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "IndexMiddleAngle", JointAngleValue = AbsIndexMiddleAngleDiff},
                                        new JointAngle {JointAngleName = "IndexDistalAngle", JointAngleValue = AbsIndexDistalAngleDiff} };

            IEnumerable<JointAngle> query2 = jointAngles.OrderBy(jointAngle => jointAngle.JointAngleValue);
            foreach (JointAngle jointAngle in query2)
            {
                // iterate to see largest angle difference, mean, and median
                MaxJointAngleDiffName = jointAngle.JointAngleName;
                MaxJointAngleDiff = jointAngle.JointAngleValue;
                DiffSum += jointAngle.JointAngleValue; // zero this out at end of outer loop
                JointCount += 1; // zero this out at end of outer loop
                /*                if (JointCount == 13) // middle value of total number of joints
                                {
                                    MedianJointAngleDiff = jointAngle.JointAngleValue;
                                    MedianJointAngleDiffName = jointAngle.JointAngleName;
                                }*/


            }
        }

        if (Lateral.GraspState == 1 || LargeDiameter.GraspState == 1 || TherapistJoints.GraspState == 1)
        {
            JointAngle[] jointAngles = {new JointAngle {JointAngleName = "ThumbKnuckleAngle", JointAngleValue = AbsThumbKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "ThumbDistalAngle", JointAngleValue = AbsThumbDistalAngleDiff},
                                        new JointAngle {JointAngleName = "IndexKnuckleAngle", JointAngleValue = AbsIndexKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "IndexMiddleAngle", JointAngleValue = AbsIndexMiddleAngleDiff},
                                        new JointAngle {JointAngleName = "IndexDistalAngle", JointAngleValue = AbsIndexDistalAngleDiff},
                                        new JointAngle {JointAngleName = "MiddleKnuckleAngle", JointAngleValue = AbsMiddleKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "MiddleMiddleAngle", JointAngleValue = AbsMiddleMiddleAngleDiff},
                                        new JointAngle {JointAngleName = "MiddleDistalAngle", JointAngleValue = AbsMiddleDistalAngleDiff},
                                        new JointAngle {JointAngleName = "RingKnuckleAngle", JointAngleValue = AbsRingKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "RingMiddleAngle", JointAngleValue = AbsRingMiddleAngleDiff},
                                        new JointAngle {JointAngleName = "RingDistalAngle", JointAngleValue = AbsRingDistalAngleDiff},
                                        new JointAngle {JointAngleName = "PinkyKnuckleAngle", JointAngleValue = AbsPinkyKnuckleAngleDiff},
                                        new JointAngle {JointAngleName = "PinkyMiddleAngle", JointAngleValue = AbsPinkyMiddleAngleDiff},
                                        new JointAngle {JointAngleName = "PinkyDistalAngle", JointAngleValue = AbsPinkyDistalAngleDiff} };

            IEnumerable<JointAngle> query2 = jointAngles.OrderBy(jointAngle => jointAngle.JointAngleValue);
            foreach (JointAngle jointAngle in query2)
            {
                // iterate to see largest angle difference, mean, and median
                MaxJointAngleDiffName = jointAngle.JointAngleName;
                MaxJointAngleDiff = jointAngle.JointAngleValue;
                DiffSum += jointAngle.JointAngleValue; // zero this out at end of outer loop
                JointCount += 1; // zero this out at end of outer loop
                /*                if (JointCount == 13) // middle value of total number of joints
                                {
                                    MedianJointAngleDiff = jointAngle.JointAngleValue;
                                    MedianJointAngleDiffName = jointAngle.JointAngleName;
                                }*/

            }
        }

                
        MeanAngleDiff = DiffSum / JointCount;
        MeanAngleDiff = Mathf.Round(MeanAngleDiff);

        // original unnormalized 

        DiffSumThumb = (AbsThumbKnuckleAngleDiff) + (AbsThumbDistalAngleDiff);
        DiffSumIndex = (AbsIndexKnuckleAngleDiff) + (AbsIndexMiddleAngleDiff) + (AbsIndexDistalAngleDiff);
        DiffSumMiddle = (AbsMiddleKnuckleAngleDiff) + (AbsMiddleMiddleAngleDiff) + (AbsMiddleDistalAngleDiff);
        DiffSumRing = (AbsRingKnuckleAngleDiff) + (AbsRingMiddleAngleDiff) + (AbsRingDistalAngleDiff);
        DiffSumPinky = (AbsPinkyKnuckleAngleDiff) + (AbsPinkyMiddleAngleDiff) + (AbsPinkyDistalAngleDiff);

        // normalized to reduce the weight of the finger tips/distal joints because they are less meaningful

        if (TipPinch.GraspState == 1)
        {
            DiffSumTotal = DiffSumThumb + DiffSumIndex;
        }
        if (Lateral.GraspState == 1 || LargeDiameter.GraspState == 1 || TherapistJoints.GraspState == 1)
        {
            DiffSumTotal = DiffSumThumb + DiffSumIndex + DiffSumMiddle + DiffSumRing + DiffSumPinky;
        }

        MeanAngleDiffTest = DiffSumTotal / JointCount;
        MeanAngleDiffTest = Mathf.Round(MeanAngleDiffTest);

        // different error score depending on weights for each grip 

        if (TipPinch.GraspState == 1)
        {
            ThumbErrorWeight = 0.5f;
            IndexErrorWeight = 0.5f;
            MiddleErrorWeight = 0f;
            RingErrorWeight = 0f;
            PinkyErrorWeight = 0f;
        }
        if (LargeDiameter.GraspState == 1)
        {
            ThumbErrorWeight = 0.2f;
            IndexErrorWeight = 0.2f;
            MiddleErrorWeight = 0.2f;
            RingErrorWeight = 0.2f;
            PinkyErrorWeight = 0.2f;
        }
        if (Lateral.GraspState == 1)
        {
            ThumbErrorWeight = 0.35f;
            IndexErrorWeight = 0.35f;
            MiddleErrorWeight = 0.1f;
            RingErrorWeight = 0.1f;
            PinkyErrorWeight = 0.1f;
        }

        // Weighted average

        // original... use with unnormalized sums
        NormalizedThumbError = DiffSumThumb / 2 * ThumbErrorWeight;
        NormalizedIndexError = DiffSumIndex / 3 * IndexErrorWeight;
        NormalizedMiddleError = DiffSumMiddle / 3 * MiddleErrorWeight;
        NormalizedRingError = DiffSumRing / 3 * RingErrorWeight;
        NormalizedPinkyError = DiffSumPinky / 3 * PinkyErrorWeight;

        // use with normalized sums 
        /*        NormalizedThumbError = DiffSumThumb * ThumbErrorWeight;
                NormalizedIndexError = DiffSumIndex * IndexErrorWeight;
                NormalizedMiddleError = DiffSumMiddle * MiddleErrorWeight;
                NormalizedRingError = DiffSumRing * RingErrorWeight;
                NormalizedPinkyError = DiffSumPinky * PinkyErrorWeight;*/

        NormalizedAverageError = NormalizedThumbError + NormalizedIndexError + NormalizedMiddleError + NormalizedRingError + NormalizedPinkyError;

        NormalizedAverageError = NormalizedAverageError - 5f; // 5 degrees error is the new zero, 5 degree error tolerance


        DiffSum = 0; // reset value 
        JointCount = 0; // reset value
        
        // new overall score
        upperbound_error = 35f; // maximum error on our percentage scale... based on some estimates when trying the system... tinker with this if need too

        // upperbound error might need to change depending on target grasp (e.g., tippinch only incorporates two fingers into error)

        /*            if (TipPinch.GraspState == 1)
                    {
                        upperbound_error = 30f;
                    }
                    if (Lateral.GraspState == 1 || LargeDiameter.GraspState == 1)
                    {
                        upperbound_error = 40f;
                    }*/

        //OverallScore100 = 100 - ((MeanAngleDiff / upperbound_error) * 100);
        OverallScore100 = 100 - ((NormalizedAverageError / upperbound_error) * 100);
        OverallScore100 = Mathf.Round(OverallScore100);

        /*            if (MeanAngleDiff > upperbound_error)
                    {
                        OverallScore100 = 0;
                    }*/
        if (NormalizedAverageError > upperbound_error)
        {
            OverallScore100 = 0;
        }
        if (NormalizedAverageError <= 0)
        {
            OverallScore100 = 99;
        }

        // calculate directional angle differences

        MetaThumbAngleDiff = TargetMetaThumbAngle - MetaThumbAngle;
        ThumbKnuckleAngleDiff = TargetThumbKnuckleAngle - ThumbKnuckleAngle;
        ThumbDistalAngleDiff = TargetThumbDistalAngle - ThumbDistalAngle;
        IndexKnuckleAngleDiff = TargetIndexKnuckleAngle - IndexKnuckleAngle;
        IndexMiddleAngleDiff = TargetIndexMiddleAngle - IndexMiddleAngle;
        IndexDistalAngleDiff = TargetIndexDistalAngle - IndexDistalAngle;
        MiddleKnuckleAngleDiff = TargetMiddleKnuckleAngle - MiddleKnuckleAngle;
        MiddleMiddleAngleDiff = TargetMiddleMiddleAngle - MiddleMiddleAngle;
        MiddleDistalAngleDiff = TargetMiddleDistalAngle - MiddleDistalAngle;
        RingKnuckleAngleDiff = TargetRingKnuckleAngle - RingKnuckleAngle;
        RingMiddleAngleDiff = TargetRingMiddleAngle - RingMiddleAngle;
        RingDistalAngleDiff = TargetRingDistalAngle - RingDistalAngle;
        PinkyKnuckleAngleDiff = TargetPinkyKnuckleAngle - PinkyKnuckleAngle;
        PinkyMiddleAngleDiff = TargetPinkyMiddleAngle - PinkyMiddleAngle;
        PinkyDistalAngleDiff = TargetPinkyDistalAngle - PinkyDistalAngle;
        if(HandTracking.HandUsed == 1)
        {
            ThumbAlignmentDiff = IndexKnucklePlane.ThumbDistancePlane;
        }
        else { ThumbAlignmentDiff = IndexKnucklePlane.ThumbDistancePlane * -1; }

        // calculate stimulation amplitude based on each grasp and error
        // try with knuckle angle first



        if (UseThumbAngle == true)
        {
           
            if (TipPinch.GraspState == 1)
            {
                upperbound_error_finger = 35f;
                upperbound_error_thumb = 10f;

                if (ThumbKnuckleAngleDiff > 0f)
                {
                    ThumbStimAmp = 0;
                }

                if (ThumbKnuckleAngleDiff < 0f)
                {
                    ThumbStimAmp = (ThumbKnuckleAngleDiff / (upperbound_error_thumb * -1));
                }
                if (IndexKnuckleAngleDiff > -5f)
                {
                    FingerStimAmp = 0;
                }
                if (IndexKnuckleAngleDiff < -5f)
                {
                    FingerStimAmp = (IndexKnuckleAngleDiff / (upperbound_error_finger * -1));
                }
            }

            if (Lateral.GraspState == 1)
            {
                upperbound_error_finger = 35f;
                upperbound_error_thumb = 25f;
                if (ThumbKnuckleAngleDiff > -5f)
                {
                    ThumbStimAmp = 0;
                }

                if (ThumbKnuckleAngleDiff < -5f)
                {
                    ThumbStimAmp = (ThumbKnuckleAngleDiff / (upperbound_error_thumb * -1));
                }
                if (IndexKnuckleAngleDiff > -5f)
                {
                    FingerStimAmp = 0;
                }
                if (IndexKnuckleAngleDiff < -5f)
                {
                    FingerStimAmp = (IndexKnuckleAngleDiff / (upperbound_error_finger * -1));
                }
            }

            if (LargeDiameter.GraspState == 1)
            {
                upperbound_error_finger = 20f;
                upperbound_error_thumb = 10f;
                if (ThumbKnuckleAngleDiff > 0f)
                {
                    ThumbStimAmp = 0;
                }

                if (ThumbKnuckleAngleDiff < 0f)
                {
                    ThumbStimAmp = (ThumbKnuckleAngleDiff / (upperbound_error_thumb * -1));
                }

                if (IndexKnuckleAngleDiff > 0) { IndexKnuckleAngleDiff = 0; }
                if (MiddleKnuckleAngleDiff > 0) { MiddleKnuckleAngleDiff = 0; }
                if (RingKnuckleAngleDiff > 0) { RingKnuckleAngleDiff = 0; }
                if (PinkyKnuckleAngleDiff > 0) { PinkyKnuckleAngleDiff = 0; }

                FourDigitKnuckleAverage = (IndexKnuckleAngleDiff + MiddleKnuckleAngleDiff + RingKnuckleAngleDiff + PinkyKnuckleAngleDiff) / 4;

                if (FourDigitKnuckleAverage > -5f)
                {
                    FingerStimAmp = 0;
                }
                if (FourDigitKnuckleAverage < -5f)
                {
                    FingerStimAmp = (FourDigitKnuckleAverage / (upperbound_error_finger * -1));
                }

            }
        }

        if(UseThumbAngle == false)
        {
            upperbound_error_thumb = 0.06f;
            //lowerbound_error_thumb = 0f;
            lowerbound_error_thumb = -0.01f; 
            if (TipPinch.GraspState == 1)
            {
                upperbound_error_finger = 40f;

                if (ThumbAlignmentDiff < lowerbound_error_thumb) // more flexed than plane... double check planes normal direction
                {
                    ThumbStimAmp = 0;
                }

                if (ThumbAlignmentDiff > lowerbound_error_thumb)
                {
                    ThumbStimAmp = (ThumbAlignmentDiff - lowerbound_error_thumb) / upperbound_error_thumb;
                    //ThumbStimAmp = ThumbAlignmentDiff / upperbound_error_thumb;
                    //ThumbStimAmp = (ThumbKnuckleAngleDiff / (upperbound_error_thumb * -1));
                }
                if (IndexKnuckleAngleDiff > 0f) // try with this at 0... everywhere
                {
                    FingerStimAmp = 0;
                }
                if (IndexKnuckleAngleDiff < 0f)
                {
                    FingerStimAmp = (IndexKnuckleAngleDiff / (upperbound_error_finger * -1));
                }
            }

            if (Lateral.GraspState == 1)
            {
                upperbound_error_finger = 40f;
                //lowerbound_error_thumb = 0.02f;
                lowerbound_error_thumb = 0.01f;
                if (ThumbAlignmentDiff < lowerbound_error_thumb) // thumb tip will never be aligned with plane because thumb is resting on finger
                {
                    ThumbStimAmp = 0;
                }

                if (ThumbAlignmentDiff > lowerbound_error_thumb)
                {
                    //ThumbStimAmp = ThumbAlignmentDiff / upperbound_error_thumb;
                    ThumbStimAmp = (ThumbAlignmentDiff - lowerbound_error_thumb) / upperbound_error_thumb;
                    //ThumbStimAmp = (ThumbKnuckleAngleDiff / (upperbound_error_thumb * -1));
                }
                if (IndexKnuckleAngleDiff > 0f)
                {
                    FingerStimAmp = 0;
                }
                if (IndexKnuckleAngleDiff < 0f)
                {
                    FingerStimAmp = (IndexKnuckleAngleDiff / (upperbound_error_finger * -1));
                }
            }

            if (LargeDiameter.GraspState == 1)
            {
                upperbound_error_finger = 25f;
                if (ThumbAlignmentDiff < lowerbound_error_thumb)
                {
                    ThumbStimAmp = 0;
                }

                if (ThumbAlignmentDiff > lowerbound_error_thumb)
                {
                    ThumbStimAmp = (ThumbAlignmentDiff - lowerbound_error_thumb) / upperbound_error_thumb;
                    //ThumbStimAmp = (ThumbKnuckleAngleDiff / (upperbound_error_thumb * -1));
                }

                if (IndexKnuckleAngleDiff > 0) { IndexKnuckleAngleDiff = 0; }
                if (MiddleKnuckleAngleDiff > 0) { MiddleKnuckleAngleDiff = 0; }
                if (RingKnuckleAngleDiff > 0) { RingKnuckleAngleDiff = 0; }
                if (PinkyKnuckleAngleDiff > 0) { PinkyKnuckleAngleDiff = 0; }

                FourDigitKnuckleAverage = (IndexKnuckleAngleDiff + MiddleKnuckleAngleDiff + RingKnuckleAngleDiff + PinkyKnuckleAngleDiff) / 4;

                if (FourDigitKnuckleAverage > 0f)
                {
                    FingerStimAmp = 0;
                }
                if (FourDigitKnuckleAverage < 0f)
                {
                    FingerStimAmp = (FourDigitKnuckleAverage / (upperbound_error_finger * -1));
                }

            }
        }



        if (ThumbStimAmp > 1)
        {
            ThumbStimAmp = 1;
        }
        if (FingerStimAmp > 1)
        {
            FingerStimAmp = 1;
        }
        
        //Debug.Log(ThumbStimAmp);

    }

    // Start is called before the first frame update
    void Start()
    {
        positionset = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            FeedbackTest.gameObject.SetActive(true);
            feedback_test.text = "Feedback Test";
        }

        if(TipPinch.GraspState == 1 || Lateral.GraspState == 1 || LargeDiameter.GraspState == 1)
        {
            ContinuousErrorSignal();
        }

        TargetLabeling();

    }

}

