using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegLateral : MonoBehaviour
{
    public int GraspState;
    public LargeDiameter LargeDiameter;
    public TipPinch TipPinch;
    public Lateral Lateral;
    public RegLateral regLateral;
    public RegLargeDiameter RegLargeDiameter;
    public RegTipPinch RegTipPinch;
    public RegTherapistJoints RegTherapistJoints;
    public MainCamera MainCamera;
    public PalmPos PalmPos;
    public Vector3 localPos;
    public Quaternion localRot;
    public int regParented;
    public HandTracking1 HandTracking;
    public RegLateralHolder RegLateralHolder;
    public Vector3 localPosHome;
    public Quaternion localRotHome;

    public void Align()
    {
        if(PalmPos.NewPositionSet == 1)
        {
            if (RegLargeDiameter.GraspState == 0 && RegTipPinch.GraspState == 0 && RegTherapistJoints.GraspState == 0)
            {
                RegLateralHolder.gameObject.SetActive(true);
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

        regLateral.transform.parent = RegLateralHolder.transform;
        transform.SetLocalPositionAndRotation(localPosHome, localRotHome);
        RegLateralHolder.gameObject.SetActive(false);
        GraspState = 0;
        PalmPos.StartAlign = 0;
    }

    public void HandSwitch()
    {
        if (Lateral.Resized == 1)
        {
            if (HandTracking.HandUsed == 1)
            {
                transform.localScale = new Vector3(Lateral.calibrateRatioVector.x, Lateral.calibrateRatioVector.y, Lateral.calibrateRatioVector.z);
                localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, -18f, localRot.eulerAngles.z);
                localPos = new Vector3(-0.25f, -0.055f, 0.3f);
            }
            if (HandTracking.HandUsed == 2)
            {
                transform.localScale = new Vector3(Lateral.calibrateRatioVector.x * -1, Lateral.calibrateRatioVector.y, Lateral.calibrateRatioVector.z);
                localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, -25.4f, localRot.eulerAngles.z);
                localPos = new Vector3(0.17f, -0.05f, 0.4f);


            }

            transform.SetLocalPositionAndRotation(localPos, localRot);
        }

    }

    public void ParentAlign()
    {
        regLateral.transform.parent = MainCamera.transform;
        transform.SetLocalPositionAndRotation(localPos, localRot);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (HandTracking.HandUsed == 1)
        {
            localPos = new Vector3(-0.25f, -0.04f, 0.4f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            localRot.eulerAngles = new Vector3(-12.68f, -22.5f, 1.82f);
        }

        if (HandTracking.HandUsed == 2)
        {
            localPos = new Vector3(0.17f, -0.05f, 0.4f);
            localRot = new Quaternion(0f, 0f, 0f, 0);
            localRot.eulerAngles = new Vector3(-12.68f, -25.4f, 1.82f);
        }


    }

    // Update is called once per frame
    void Update()
    {
/*        if (GraspState == 1 && regParented == 0)
        {
            regLateral.transform.parent = MainCamera.transform;
            transform.SetLocalPositionAndRotation(localPos, localRot);
            transform.localScale = Lateral.calibrateRatioVector;

            if(HandTracking.HandUsed == 2)
            {
                transform.localScale = new Vector3(Lateral.calibrateRatioVector.x * -1, Lateral.calibrateRatioVector.y, Lateral.calibrateRatioVector.z);
            }
            regParented = 1;
        }*/

    }
}
