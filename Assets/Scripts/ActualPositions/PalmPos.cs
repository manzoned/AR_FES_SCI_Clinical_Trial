using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.VFX;

public class PalmPos : MonoBehaviour
{
    
    public HandTracking1 HandTracking;
    public ErrorScoreScript_v2 errorScoreScript;
    public Lateral Lateral;
    public TipPinch TipPinch;
    public LargeDiameter LargeDiameter;
    public RegLateral RegLateral;
    public RegTipPinch RegTipPinch;
    public RegLargeDiameter RegLargeDiameter;
    public RegTherapistJoints RegTherapistJoints;
    public RegLateralPalmPos RegLateralPalmPos;
    public RegTipPinchPalmPos RegTipPinchPalmPos;
    public RegLargeDiameterPalmPos RegLargeDiameterPalmPos;
    public RegTherapistPalmPos RegTherapistPalmPos;
    public NewPositions NewPositions;
    public ScorePrompt ScorePrompt;
    public SetPosturePrompt SetPosturePrompt;
    public TargetPosturePanel TargetPosturePanel;
    public Vector3 tempPosition;
    public Quaternion tempRotation;
    public Vector3 RegPos;
    public Quaternion RegRot;

    private Vector3 offsetPos;
    private Vector3 newPos;
    private Quaternion offsetRot;
    private Quaternion newRot;

    //public TargetPalm TargetPalm;
    Vector3 regAngle;
    public int testTrigger;
    private int setActive;
    public int StartAlign;
    public int lineActive;
    public int FinishAlign;
    public int lineCodeTimer;
    public int StartAlignThreshold;
    public int NewPositionSet;

    public void Disappear()
    {

        Vector3 destroyPos = new Vector3(-10f, -10f, -10f);
        transform.position = destroyPos;
        StartAlign = 0;
        lineActive = 0;
        NewPositionSet = 0;

    }

    // create function that can be called to align target and position
    public void AlignPositions()
    {
        StartAlign++;
        //if(NewPositions.newParented == 1)
        //{

            if (RegTipPinch.GraspState == 1)
            {

                RegPos = RegTipPinchPalmPos.tempPosition;
                RegRot = RegTipPinchPalmPos.tempRotation;
            }
            if (RegLateral.GraspState == 1)
            {
                RegPos = RegLateralPalmPos.tempPosition;
                RegRot = RegLateralPalmPos.tempRotation;
            }
            if (RegLargeDiameter.GraspState == 1)
            {
                RegPos = RegLargeDiameterPalmPos.tempPositon;
                RegRot = RegLargeDiameterPalmPos.tempRotation;
            }
            if (RegTherapistJoints.GraspState == 1)
            {
                RegPos = RegTherapistPalmPos.transform.position;
                RegRot = RegTherapistPalmPos.transform.rotation;
            }

            transform.position = RegPos;
            transform.rotation = RegRot;
        //}

        //new 
        //StartAlign = 0;
        //Debug.Log(StartAlign);  
        TargetPosturePanel.ScreenOff();
    }

    public void Set()
    {
        
        tempPosition = HandTracking.palmPos;
        tempRotation = HandTracking.palmRot;

        transform.position = tempPosition;
        transform.rotation = tempRotation;

        setActive = 1;
        StartAlign = 0;
        lineActive = 1;
        lineCodeTimer = 0;
        NewPositionSet = 1;
        //SetPosturePrompt.SetPosturePromptOff();
        //ScorePrompt.ScorePromptOn();
        TargetPosturePanel.ScorePromptOn();

    }

    // Start is called before the first frame update
    void Start()
    {
        StartAlignThreshold = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(StartAlign);

        if (setActive == 1)
        {
            testTrigger = 1;
            setActive = 0;
        }
        if (RegTipPinch.GraspState == 1 || RegLateral.GraspState == 1 || RegLargeDiameter.GraspState == 1 || RegTherapistJoints.GraspState == 1)
        {
            if (StartAlign > 0 && StartAlign < StartAlignThreshold)
            {

                AlignPositions();



            }
            if (StartAlign == StartAlignThreshold)
            {
                if(HandTracking.HandUsed == 2)
                {
                    //gameObject.transform.
                }    

                NewPositions.ParentAlign(); 
                if(RegTipPinch.GraspState == 1)
                {
                    RegTipPinch.ParentAlign();
                }
                if(RegLateral.GraspState == 1)
                {
                    RegLateral.ParentAlign();
                }
                if(RegLargeDiameter.GraspState == 1)
                {
                    RegLargeDiameter.ParentAlign();
                }

                StartAlign++;
                
            }
            
        }

    }

}
