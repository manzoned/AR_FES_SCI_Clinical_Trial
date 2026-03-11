using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedbackScreen : MonoBehaviour
{
    public FeedbackScreen feedbackScreen;
    public HandHolder HandHolder;
    public SkeletonHolder SkeletonHolder;
    public MainCamera MainCamera;
    public FeedbackTest FeedbackTest;
    public HandTracking1 HandTracking;
    public RegTipPinch RegTipPinch;
    public RegTipPinchHolder RegTipPinchHolder;
    public TipPinch TipPinch;
    public RegLateral RegLateral;
    public RegLateralHolder RegLateralHolder;
    public Lateral Lateral;
    public RegLargeDiameter RegLargeDiameter;
    public RegLargeDiameterHolder RegLargeDiameterHolder;
    public LargeDiameter LargeDiameter;
    public NewPositions NewPositions;
    public NewPositionsHolder NewPositionsHolder;
    public ActualRig ActualRig;
    public TipPinchRig TipPinchRig;
    public LateralRig LateralRig;
    public LargeDiameterRig LargeDiameterRig;
    public PalmPos PalmPos;
    public RepetitionPrompt RepetitionPrompt;
    public Vector3 localPosActualRig;
    public Vector3 localPosTargetRig;
    public Vector3 localPosActualSkeleton;
    public Vector3 localPosTargetSkeleton;
    public Vector3 localScaleRig;
    public Vector3 localScaleActualSkeleton;
    public Vector3 localScaleTargetSkeleton;
    public Vector3 skeletonHolderPos;
    public Vector3 handHolderPos;
    public Quaternion skeletonHolderRot;
    public Quaternion localRotActualRig;
    public Quaternion localRotTargetRig;
    public Quaternion localRotActualSkeleton;
    public Quaternion localRotTargetSkeleton;
    public Quaternion handHolderRot;
    public int ScreenIsOn;
    public int screenTime;
    public string TargetName;
    public int FeedbackScreenState;
    public int rotationScale;

    public void ScreenOn()
    {
        // if position is set you can turn this on but not otherwise
        if (PalmPos.NewPositionSet == 1)
        {
            gameObject.SetActive(true);
            ScreenIsOn = 1;
            //AttachtoScreen();
            FeedbackTest.gameObject.SetActive(false);
            FeedbackScreenState = 1;
            RepetitionPrompt.RepetitionPromptOff();
        }

    }

    public void ResetTargetScale()
    {
        // scale was changed when adding skeletons to feedback screen to preserve alignment
        // need to be changed back what they were in world space

        if (HandTracking.HandUsed == 1)
        {

            if (TargetName == "TipPinch")
            {
                RegTipPinch.transform.localScale = new Vector3(TipPinch.calibrateRatioVector.x, TipPinch.calibrateRatioVector.y, TipPinch.calibrateRatioVector.z);
            }
            if (TargetName == "Lateral")
            {
                RegLateral.transform.localScale = new Vector3(Lateral.calibrateRatioVector.x, Lateral.calibrateRatioVector.y, Lateral.calibrateRatioVector.z);
            }
            if (TargetName == "LargeDiameter")
            {
                RegLargeDiameter.transform.localScale = new Vector3(LargeDiameter.calibrateRatioVector.x, LargeDiameter.calibrateRatioVector.y, LargeDiameter.calibrateRatioVector.z);
            }

        }
        if (HandTracking.HandUsed == 2)
        {

            if (TargetName == "TipPinch")
            {
                RegTipPinch.transform.localScale = new Vector3(TipPinch.calibrateRatioVector.x * -1, TipPinch.calibrateRatioVector.y, TipPinch.calibrateRatioVector.z);
            }
            if (TargetName == "Lateral")
            {
                RegLateral.transform.localScale = new Vector3(Lateral.calibrateRatioVector.x * -1, Lateral.calibrateRatioVector.y, Lateral.calibrateRatioVector.z);
            }
            if (TargetName == "LargeDiameter")
            {
                RegLargeDiameter.transform.localScale = new Vector3(LargeDiameter.calibrateRatioVector.x * -1, LargeDiameter.calibrateRatioVector.y, LargeDiameter.calibrateRatioVector.z);
            }

        }
        TargetName = "Null";
    }

    public void AttachtoScreen()
    {
        // attach everything to the screen
        ActualRig.transform.parent = feedbackScreen.transform;
        NewPositions.transform.parent = SkeletonHolder.transform;

        // scales need to be the same prior to being children of the feedback screen
        if (HandTracking.HandUsed == 1)
        {
            localScaleTargetSkeleton = new Vector3(localScaleActualSkeleton.x, localScaleActualSkeleton.y, localScaleActualSkeleton.z);

        }
        if (HandTracking.HandUsed == 2)
        {
            localScaleTargetSkeleton = new Vector3(localScaleActualSkeleton.x * -1, localScaleActualSkeleton.y, localScaleActualSkeleton.z);

        }

        if (TipPinch.GraspState == 1)
        {
            RegTipPinch.transform.localScale = localScaleTargetSkeleton;
            TipPinchRig.transform.parent = feedbackScreen.transform;
            RegTipPinch.transform.parent = SkeletonHolder.transform;
            TipPinch.gameObject.SetActive(false);
            TargetName = "TipPinch";
        }
        if (Lateral.GraspState == 1)
        {
            RegLateral.transform.localScale = localScaleTargetSkeleton;
            LateralRig.transform.parent = feedbackScreen.transform;
            RegLateral.transform.parent = SkeletonHolder.transform;
            Lateral.gameObject.SetActive(false);
            TargetName = "Lateral";
        }
        if (LargeDiameter.GraspState == 1)
        {
            RegLargeDiameter.transform.localScale = localScaleTargetSkeleton;
            LargeDiameterRig.transform.parent = feedbackScreen.transform;
            RegLargeDiameter.transform.parent = SkeletonHolder.transform;
            LargeDiameter.gameObject.SetActive(false);
            TargetName = "LargeDiameter";
        }

        // set positions for everything on the screen space - might be different for every posture - might need to adjust rotations as well or reset them better

        if (HandTracking.HandUsed == 1)
        {
            localScaleRig = new Vector3(0.65f, 0.65f, 0.65f);
            localScaleActualSkeleton = new Vector3(0.8f, 0.8f, 0.8f);
            localPosActualSkeleton = new Vector3(0f, 0f, 0f);
            localPosTargetSkeleton = new Vector3(0f, 0f, 0f);
            localRotTargetSkeleton.eulerAngles = new Vector3(0f, 0f, 0f);
            localRotActualSkeleton.eulerAngles = new Vector3(0f, 0f, 0f);
            NewPositions.transform.localScale = localScaleActualSkeleton;
            NewPositions.transform.SetLocalPositionAndRotation(localPosActualSkeleton, localRotActualSkeleton);

            if (TipPinch.GraspState == 1)
            {
                localPosActualRig = new Vector3(-0.065f, -0.08f, 0.11f);
                localPosTargetRig = new Vector3(0.045f, -0.08f, 0.11f);
                localRotActualRig.eulerAngles = new Vector3(11.2f, 180f, 47.5f);
                localRotTargetRig.eulerAngles = new Vector3(-191.2f, -360f, 47.5f);
                TipPinchRig.transform.SetLocalPositionAndRotation(localPosTargetRig, localRotTargetRig);
                TipPinchRig.transform.localScale = localScaleRig;
                localScaleTargetSkeleton = new Vector3(TipPinch.calibrateRatio * localScaleActualSkeleton.x, TipPinch.calibrateRatio * localScaleActualSkeleton.y, TipPinch.calibrateRatio * localScaleActualSkeleton.z);
                RegTipPinch.transform.localScale = localScaleTargetSkeleton;
                RegTipPinch.transform.SetLocalPositionAndRotation(localPosTargetSkeleton, localRotTargetSkeleton);
                skeletonHolderPos = new Vector3(-0.11f, 0.01f, -0.3f);
                skeletonHolderRot.eulerAngles = new Vector3(0f, 0f, 0f);

            }

            if (Lateral.GraspState == 1)
            {
                localPosActualRig = new Vector3(-0.065f, -0.06f, 0.11f);
                localPosTargetRig = new Vector3(0.035f, -0.06f, 0.11f);
                localRotActualRig.eulerAngles = new Vector3(-93f, 100f, 80);
                localRotTargetRig.eulerAngles = new Vector3(-93f, -430f, 80f);
                LateralRig.transform.SetLocalPositionAndRotation(localPosTargetRig, localRotTargetRig);
                LateralRig.transform.localScale = localScaleRig;
                localScaleTargetSkeleton = new Vector3(Lateral.calibrateRatio * localScaleActualSkeleton.x, Lateral.calibrateRatio * localScaleActualSkeleton.y, Lateral.calibrateRatio * localScaleActualSkeleton.z);
                RegLateral.transform.localScale = localScaleTargetSkeleton;
                RegLateral.transform.SetLocalPositionAndRotation(localPosTargetSkeleton, localRotTargetSkeleton);
                skeletonHolderPos = new Vector3(-0.21f, 0.01f, -0.3f);
                skeletonHolderRot.eulerAngles = new Vector3(0f, 0f, 0f);

            }

            if (LargeDiameter.GraspState == 1)
            {
                localPosActualRig = new Vector3(-0.065f, -0.06f, 0.11f);
                localPosTargetRig = new Vector3(0.055f, -0.06f, 0.11f);
                localRotActualRig.eulerAngles = new Vector3(-60f, -180f, 22f);
                localRotTargetRig.eulerAngles = new Vector3(-132f, -360f, 22f);
                LargeDiameterRig.transform.SetLocalPositionAndRotation(localPosTargetRig, localRotTargetRig);
                LargeDiameterRig.transform.localScale = localScaleRig;
                localScaleTargetSkeleton = new Vector3(LargeDiameter.calibrateRatio * localScaleActualSkeleton.x, LargeDiameter.calibrateRatio * localScaleActualSkeleton.y, LargeDiameter.calibrateRatio * localScaleActualSkeleton.z);
                RegLargeDiameter.transform.localScale = localScaleTargetSkeleton;
                RegLargeDiameter.transform.SetLocalPositionAndRotation(localPosTargetSkeleton, localRotTargetSkeleton);
                skeletonHolderPos = new Vector3(0.005f, 0.01f, -0.3f);
                skeletonHolderRot.eulerAngles = new Vector3(0f, 0f, 0f);

            }

            ActualRig.transform.SetLocalPositionAndRotation(localPosActualRig, localRotActualRig);
            ActualRig.transform.localScale = localScaleRig;
            SkeletonHolder.transform.SetLocalPositionAndRotation(skeletonHolderPos, skeletonHolderRot);

            handHolderPos = new Vector3(0.015f, 0f, 0.03f);
            handHolderRot.eulerAngles = new Vector3(0f, -20f, 0f);
            HandHolder.transform.SetLocalPositionAndRotation(handHolderPos, handHolderRot);
        }

        if (HandTracking.HandUsed == 2)
        {
            localScaleRig = new Vector3(-0.65f, 0.65f, 0.65f);
            localScaleActualSkeleton = new Vector3(0.8f, 0.8f, 0.8f);
            localPosActualSkeleton = new Vector3(0f, 0f, 0f);
            localPosTargetSkeleton = new Vector3(0f, 0f, 0f);
            localRotTargetSkeleton.eulerAngles = new Vector3(0f, 0f, 0f);
            localRotActualSkeleton.eulerAngles = new Vector3(0f, 0f, 0f);


            NewPositions.transform.localScale = localScaleActualSkeleton;
            NewPositions.transform.SetLocalPositionAndRotation(localPosActualSkeleton, localRotActualSkeleton);

            // set the positions 

            if (TipPinch.GraspState == 1)
            {
                localPosActualRig = new Vector3(-0.14f, -0.08f, 0.11f);
                localPosTargetRig = new Vector3(-0.04f, -0.08f, 0.11f);
                localRotActualRig.eulerAngles = new Vector3(11.2f, -180f, -48.9f);
                localRotTargetRig.eulerAngles = new Vector3(-191.2f, -360f, -48.9f);
                TipPinchRig.transform.SetLocalPositionAndRotation(localPosTargetRig, localRotTargetRig);
                TipPinchRig.transform.localScale = localScaleRig;
                localScaleTargetSkeleton = new Vector3(TipPinch.calibrateRatio * localScaleActualSkeleton.x * -1, TipPinch.calibrateRatio * localScaleActualSkeleton.y, TipPinch.calibrateRatio * localScaleActualSkeleton.z);
                RegTipPinch.transform.localScale = localScaleTargetSkeleton;
                RegTipPinch.transform.SetLocalPositionAndRotation(localPosTargetSkeleton, localRotTargetSkeleton);
                skeletonHolderPos = new Vector3(0.04f, 0.03f, -0.3f);
                skeletonHolderRot.eulerAngles = new Vector3(0f, 0f, 0f);

            }
            if (Lateral.GraspState == 1)
            {
                localPosActualRig = new Vector3(-0.14f, -0.06f, 0.11f);
                localPosTargetRig = new Vector3(-0.02f, -0.06f, 0.11f);
                localRotActualRig.eulerAngles = new Vector3(-93f, -460f, -100);
                localRotTargetRig.eulerAngles = new Vector3(-93f, -445f, 80f);
                LateralRig.transform.SetLocalPositionAndRotation(localPosTargetRig, localRotTargetRig);
                LateralRig.transform.localScale = localScaleRig;
                localScaleTargetSkeleton = new Vector3(Lateral.calibrateRatio * localScaleActualSkeleton.x * -1, Lateral.calibrateRatio * localScaleActualSkeleton.y, Lateral.calibrateRatio * localScaleActualSkeleton.z);
                RegLateral.transform.localScale = localScaleTargetSkeleton;
                RegLateral.transform.SetLocalPositionAndRotation(localPosTargetSkeleton, localRotTargetSkeleton);
                skeletonHolderPos = new Vector3(0.12f, 0.01f, -0.3f);
                skeletonHolderRot.eulerAngles = new Vector3(0f, 0f, 0f);

            }
            if (LargeDiameter.GraspState == 1)
            {
                localPosActualRig = new Vector3(-0.14f, -0.08f, 0.11f);
                localPosTargetRig = new Vector3(-0.03f, -0.08f, 0.11f);
                localRotActualRig.eulerAngles = new Vector3(-60f, -510f, -50);
                localRotTargetRig.eulerAngles = new Vector3(-60f, -500f, 125f);
                LargeDiameterRig.transform.SetLocalPositionAndRotation(localPosTargetRig, localRotTargetRig);
                LargeDiameterRig.transform.localScale = localScaleRig;
                localScaleTargetSkeleton = new Vector3(LargeDiameter.calibrateRatio * localScaleActualSkeleton.x * -1, LargeDiameter.calibrateRatio * localScaleActualSkeleton.y, LargeDiameter.calibrateRatio * localScaleActualSkeleton.z);
                RegLargeDiameter.transform.localScale = localScaleTargetSkeleton;
                RegLargeDiameter.transform.SetLocalPositionAndRotation(localPosTargetSkeleton, localRotTargetSkeleton);
                skeletonHolderPos = new Vector3(-0.08f, 0.01f, -0.3f);
                skeletonHolderRot.eulerAngles = new Vector3(0f, 0f, 0f);

            }

            ActualRig.transform.SetLocalPositionAndRotation(localPosActualRig, localRotActualRig);
            ActualRig.transform.localScale = localScaleRig;
            SkeletonHolder.transform.SetLocalPositionAndRotation(skeletonHolderPos, skeletonHolderRot);

            handHolderPos = new Vector3(-0.015f, 0f, 0.03f);
            handHolderRot.eulerAngles = new Vector3(0f, 20f, 0f);
            HandHolder.transform.SetLocalPositionAndRotation(handHolderPos, handHolderRot);
        }


    }

    public void ResetScreen()
    {

        skeletonHolderPos = new Vector3(0f, 0f, 0f);
        skeletonHolderRot.eulerAngles = new Vector3(0f, 0f, 0f);
        SkeletonHolder.transform.SetLocalPositionAndRotation(skeletonHolderPos, skeletonHolderRot);
        gameObject.SetActive(false);
        ScreenIsOn = 0;
        screenTime = 0;

        ResetTargetScale();
        FeedbackScreenState = 0;

        handHolderPos = new Vector3(0f, 0f, 0f);
        handHolderRot.eulerAngles = new Vector3(0f, 0f, 0f);
        HandHolder.transform.SetLocalPositionAndRotation(handHolderPos, handHolderRot);
    }

    public void RotateLeft()
    {
        if(FeedbackScreenState == 1)
        {
            handHolderRot.eulerAngles = new Vector3(handHolderRot.eulerAngles.x, handHolderRot.eulerAngles.y - rotationScale, handHolderRot.eulerAngles.z);
            localRotActualRig.eulerAngles = new Vector3(localRotActualRig.eulerAngles.x, localRotActualRig.eulerAngles.y - rotationScale, localRotActualRig.eulerAngles.z);
            localRotTargetRig.eulerAngles = new Vector3(localRotTargetRig.eulerAngles.x, localRotTargetRig.eulerAngles.y - rotationScale, localRotTargetRig.eulerAngles.z);
            HandHolder.transform.SetLocalPositionAndRotation(handHolderPos, handHolderRot);
            ActualRig.transform.SetLocalPositionAndRotation(localPosActualRig, localRotActualRig);
            
            if(TipPinch.GraspState == 1) 
            {
                TipPinchRig.transform.SetLocalPositionAndRotation(localPosTargetRig, localRotTargetRig);
            }
            if(Lateral.GraspState == 1)
            {
                LateralRig.transform.SetLocalPositionAndRotation(localPosTargetRig, localRotTargetRig);
            }
            if(LargeDiameter.GraspState == 1)
            {
                LargeDiameterRig.transform.SetLocalPositionAndRotation(localPosTargetRig, localRotTargetRig);
            }


            // maybe move x depending on rotation value - because still moves on external axis... but might be dependent on pose as well
        }
    }

    public void RotateRight()
    {
        if (FeedbackScreenState == 1)
        {
            handHolderRot.eulerAngles = new Vector3(handHolderRot.eulerAngles.x, handHolderRot.eulerAngles.y + rotationScale, handHolderRot.eulerAngles.z);
            HandHolder.transform.SetLocalPositionAndRotation(handHolderPos, handHolderRot);
            localRotActualRig.eulerAngles = new Vector3(localRotActualRig.eulerAngles.x, localRotActualRig.eulerAngles.y + rotationScale, localRotActualRig.eulerAngles.z);
            localRotTargetRig.eulerAngles = new Vector3(localRotTargetRig.eulerAngles.x, localRotTargetRig.eulerAngles.y + rotationScale, localRotTargetRig.eulerAngles.z);
            HandHolder.transform.SetLocalPositionAndRotation(handHolderPos, handHolderRot);
            ActualRig.transform.SetLocalPositionAndRotation(localPosActualRig, localRotActualRig);

            if (TipPinch.GraspState == 1)
            {
                TipPinchRig.transform.SetLocalPositionAndRotation(localPosTargetRig, localRotTargetRig);
            }
            if (Lateral.GraspState == 1)
            {
                LateralRig.transform.SetLocalPositionAndRotation(localPosTargetRig, localRotTargetRig);
            }
            if (LargeDiameter.GraspState == 1)
            {
                LargeDiameterRig.transform.SetLocalPositionAndRotation(localPosTargetRig, localRotTargetRig);
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rotationScale = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(ScreenIsOn == 1)
        {
            screenTime++;
        }
        if(screenTime == 5)
        {
            AttachtoScreen();
        }
        if(screenTime == 10)
        {
            //AdjustSkeleton();
        }
        
    }
}
