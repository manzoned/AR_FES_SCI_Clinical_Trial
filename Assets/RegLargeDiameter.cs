using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RegLargeDiameter : MonoBehaviour
{
    public int GraspState;
    public TipPinch TipPinch;
    public Lateral Lateral;
    public LargeDiameter largeDiameter;
    public RegLargeDiameter regLargeDiameter;
    public RegLateral RegLateral;
    public RegTipPinch RegTipPinch;
    public RegTherapistJoints RegTherapistJoints;
    public MainCamera MainCamera;
    public PalmPos PalmPos;
    public Vector3 localPos;
    public Quaternion localRot;
    public int regParented;
    public HandTracking1 HandTracking;
    public RegLargeDiameterHolder RegLargeDiameterHolder;
    public Vector3 localPosHome;
    public Quaternion localRotHome;

    public void Align()
    {
        if(PalmPos.NewPositionSet == 1)
        {
            if (RegTipPinch.GraspState == 0 && RegLateral.GraspState == 0 && RegTherapistJoints.GraspState == 0)
            {
                RegLargeDiameterHolder.gameObject.SetActive(true);
                GraspState = 1;
                PalmPos.AlignPositions();
            }
        }




    }
    public void Disappear()
    {
        localPosHome = new Vector3(0f, 0f, 0f);
        localRotHome = new Quaternion(0f, 0f, 0f, 0);
        localRotHome.eulerAngles = new Vector3(0f, 0f, 0f);

        regLargeDiameter.transform.parent = RegLargeDiameterHolder.transform;
        transform.SetLocalPositionAndRotation(localPosHome, localRotHome);

        RegLargeDiameterHolder.gameObject.SetActive(false);
        GraspState = 0;
        PalmPos.StartAlign = 0;
    }

    public void HandSwitch()
    {
        if (largeDiameter.Resized == 1)
        {
            if (HandTracking.HandUsed == 1)
            {
                transform.localScale = new Vector3(largeDiameter.calibrateRatioVector.x, largeDiameter.calibrateRatioVector.y, largeDiameter.calibrateRatioVector.z);
                localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, 2f, localRot.eulerAngles.z);

            }
            if (HandTracking.HandUsed == 2)
            {
                transform.localScale = new Vector3(largeDiameter.calibrateRatioVector.x * -1, largeDiameter.calibrateRatioVector.y, largeDiameter.calibrateRatioVector.z);
                localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, -12.5f, localRot.eulerAngles.z);
                localPos = new Vector3(-0.14f, -0.03f, 0.28f);

            }

            transform.SetLocalPositionAndRotation(localPos, localRot);
        }

    }

    public void ParentAlign()
    {
        regLargeDiameter.transform.parent = MainCamera.transform;
        transform.SetLocalPositionAndRotation(localPos, localRot);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (HandTracking.HandUsed == 1)
        {
            localPos = new Vector3(0f, -0.03f, 0.28f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            localRot.eulerAngles = new Vector3(-9.918f, -12.61f, 0.531f);
        }

        if (HandTracking.HandUsed == 2)
        {
            localPos = new Vector3(-0.14f, -0.03f, 0.28f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            localRot.eulerAngles = new Vector3(-9.918f, -12.61f, 0.531f);
        }

    }

    // Update is called once per frame
    void Update()
    {
/*        if (GraspState == 1 && regParented == 0)
        {
            regLargeDiameter.transform.parent = MainCamera.transform;
            transform.SetLocalPositionAndRotation(localPos, localRot);
            transform.localScale = largeDiameter.calibrateRatioVector;
            
            if (HandTracking.HandUsed == 2)
            {
                transform.localScale = new Vector3(largeDiameter.calibrateRatioVector.x * -1, largeDiameter.calibrateRatioVector.y, largeDiameter.calibrateRatioVector.z);
            }
            regParented = 1;
        }*/

    }
}
