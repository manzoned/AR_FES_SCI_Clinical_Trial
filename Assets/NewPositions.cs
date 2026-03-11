using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPositions : MonoBehaviour
{
    public NewPositions newPositions;
    public MainCamera MainCamera;
    public NewPositionsHolder NewPositionsHolder;
    public int newParented;
    public Vector3 localPos;
    public Quaternion localRot;
    public Vector3 localPosHome;
    public Quaternion localRotHome;
    public HandTracking1 HandTracking;
    public RegTipPinch RegTipPinch;
    public RegLateral RegLateral;
    public RegLargeDiameter RegLargeDiameter;
    public FeedbackScreen FeedbackScreen;
    public ScorePrompt ScorePrompt;
/*    public void Disappear()
    {
        gameObject.SetActive(false);
        
    }

    public void Set()
    {
        gameObject.SetActive(true);
    }*/

    public void Align()
    {
        //newPositions.transform.parent = MainCamera.transform; // this was uncommented for testing!
        //newParented = 1; //this was uncommented for testing!

    }

    public void ParentAlign()
    {
/*        if (HandTracking.HandUsed == 1)
        {
            localPos = new Vector3(-0.03f, -0.01f, 0.46f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            localRot.eulerAngles = new Vector3(-7.215f, -34.1f, 4.463f);
        }

        if (HandTracking.HandUsed == 2)
        {
            localPos = new Vector3(-0.03f, 0.015f, 0.46f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            localRot.eulerAngles = new Vector3(-7.215f, -16.44f, 4.463f);
        }*/

        //newPositions.transform.parent = MainCamera.transform;
        if(RegTipPinch.GraspState == 1)
        {
            transform.SetLocalPositionAndRotation(RegTipPinch.localPos, RegTipPinch.localRot);
        }
        if(RegLateral.GraspState == 1)
        {
            transform.SetLocalPositionAndRotation(RegLateral.localPos, RegLateral.localRot);
        }
        if(RegLargeDiameter.GraspState == 1)
        {
            transform.SetLocalPositionAndRotation(RegLargeDiameter.localPos, RegLargeDiameter.localRot);
        }

        FeedbackScreen.ScreenOn();
        ScorePrompt.ScorePromptOff();
        
        //transform.localScale = TipPinch.calibrateRatioVector;
    }

    public void Disappear()
    {
        newPositions.transform.parent = NewPositionsHolder.transform;
        transform.SetLocalPositionAndRotation(localPosHome, localRotHome);
        transform.localScale = new Vector3(1, 1, 1);
        newParented = 0;
        

    }
    // Start is called before the first frame update
    void Start()
    {
        localPosHome = new Vector3(0f, 0f, 0f);
        localRotHome = new Quaternion(0f, 0f, 0f, 0);
        localRotHome.eulerAngles = new Vector3(0f, 0f, 0f);

        if (HandTracking.HandUsed == 1)
        {
            localPos = new Vector3(-0.03f, -0.01f, 0.46f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            localRot.eulerAngles = new Vector3(-7.215f, -34.1f, 4.463f);
        }

        if (HandTracking.HandUsed == 2)
        {
            localPos = new Vector3(-0.03f, 0.015f, 0.46f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            localRot.eulerAngles = new Vector3(-7.215f, -16.44f, 4.463f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
