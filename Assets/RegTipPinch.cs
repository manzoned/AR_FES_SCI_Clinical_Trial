using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using UnityEngine;

public class RegTipPinch : MonoBehaviour
{
    public int GraspState;
    public LargeDiameter LargeDiameter;
    public Lateral Lateral;
    public TipPinch TipPinch;
    public RegTipPinch regTipPinch;
    public RegLateral RegLateral;
    public RegLargeDiameter RegLargeDiameter;
    public RegTherapistJoints RegTherapistJoints;
    public MainCamera MainCamera;
    public Vector3 localPos;
    public Quaternion localRot;
    public PalmPos PalmPos;
    public RegTipPinchPalmPos RegTipPinchPalmPos;
    public int regParented;
    public HandTracking1 HandTracking;
    public RegTipPinchHolder RegTipPinchHolder;
    public Vector3 localPosHome;
    public Quaternion localRotHome;
    public Vector3 localScale;


    public void Align()
    {
        if(PalmPos.NewPositionSet == 1)
        {
            if (RegLargeDiameter.GraspState == 0 && RegLateral.GraspState == 0 && RegTherapistJoints.GraspState == 0)
            {

                RegTipPinchHolder.gameObject.SetActive(true);
                GraspState = 1;
                PalmPos.AlignPositions(); 

            
            

            }
        }


    }

    public void RegGrasp()
    {
        localPos = new Vector3(-0.07f, -0.02f, 0.46f);
    }
    public void Disappear()
    {
        localPosHome = new Vector3(0f, 0f, 0f);
        localRotHome = new Quaternion(0f, 0f, 0f, 0);
        localRotHome.eulerAngles = new Vector3(0f, 0f, 0f);

        regTipPinch.transform.parent = RegTipPinchHolder.transform;
        transform.SetLocalPositionAndRotation(localPosHome, localRotHome);
        RegTipPinchHolder.gameObject.SetActive(false);
        GraspState = 0;
        PalmPos.StartAlign = 0;

    }

    public void HandSwitch()
    {
        if (TipPinch.Resized == 1)
        {
            if (HandTracking.HandUsed == 1)
            {
                transform.localScale = new Vector3(TipPinch.calibrateRatioVector.x, TipPinch.calibrateRatioVector.y, TipPinch.calibrateRatioVector.z);
                localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, -33f, localRot.eulerAngles.z);

            }
            if (HandTracking.HandUsed == 2)
            {
                transform.localScale = new Vector3(TipPinch.calibrateRatioVector.x * -1, TipPinch.calibrateRatioVector.y, TipPinch.calibrateRatioVector.z);
                localRot.eulerAngles = new Vector3(localRot.eulerAngles.x, -17.5f, localRot.eulerAngles.z);
                localPos = new Vector3(-0.03f, 0.01f, 0.46f);

            }

            transform.SetLocalPositionAndRotation(localPos, localRot);
        }

    }

    public void ParentAlign()
    {
      
        //regTipPinch.transform.parent = MainCamera.transform;
        transform.SetLocalPositionAndRotation(localPos, localRot);

    }

    // Start is called before the first frame update
    void Start()
    {
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

        //localRot.SetEulerRotation(-7.215f, -4.233f, 4.463f);

    }

    // Update is called once per frame
    void Update()
    {
        // all of this is uncommented for testing
/*        if (GraspState == 1 && regParented == 0)
        {
            regTipPinch.transform.parent = MainCamera.transform;
            transform.SetLocalPositionAndRotation(localPos, localRot);
            transform.localScale = TipPinch.calibrateRatioVector;
            
            if (HandTracking.HandUsed == 2)
            {
                transform.localScale = new Vector3(TipPinch.calibrateRatioVector.x * -1, TipPinch.calibrateRatioVector.y, TipPinch.calibrateRatioVector.z) ;
            }

            //test = 1;
            regParented = 1;

        }*/

    }
}
