using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TipPinchRig : MonoBehaviour
{

    public HandTracking1 HandTracking;
    public MainCamera MainCamera;
    public TipPinch TipPinch;
    public int GraspState;
    public Quaternion localRot;
    public Vector3 localPos;
    public Vector3 tempPos;
    public Quaternion tempRot;
    public Vector3 tempScale;
    private int waitKey;
    public void Appear()
    {
        if (HandTracking.initialCal == 1)
        {
            if (TipPinch.GraspState == 1)
            {
                if(gameObject.activeInHierarchy)
                {

                }
                else
                {
                    gameObject.SetActive(true);
                    //tempPos = gameObject.transform.localPosition;
                    //tempPos = new Vector3(0.26f, -0.05f, 0.85f);
                    //tempRot.eulerAngles = new Vector3(-191.2f, -344.9f, 48.9f);
                    tempPos = new Vector3(-0.07f, -0.05f, 0.85f);
                    tempRot.eulerAngles = new Vector3(-191.2f, -360f, 48.9f);
                    tempScale = new Vector3(0.97f, 0.97f, 0.97f);
                    //tempRot = gameObject.transform.localRotation;
                    //tempScale = gameObject.transform.localScale;
                    GraspState = 1;

                    if (HandTracking.HandUsed == 1)
                    {
                        transform.localScale = tempScale;
                        transform.localPosition = tempPos;
                        transform.localRotation = tempRot;
                    }

                    if (HandTracking.HandUsed == 2)
                    {
                        LeftHandAdjustement();

                    }
                }


            }
        }

    }

    public void LeftHandAdjustement()
    {

        localRot.eulerAngles = new Vector3(-191.2f, -360f, -48.9f);
        localPos = new Vector3(0.1f, tempPos.y, tempPos.z);
        transform.localScale = new Vector3(-0.97f, tempScale.y, tempScale.z);
        transform.localPosition = localPos;
        transform.localRotation = localRot;
    }
    public void Disappear()
    {
        gameObject.transform.parent = MainCamera.transform; 
        gameObject.SetActive(false);
        GraspState = 0;

    }
    // Start is called before the first frame update
    void Start()
    {
        waitKey = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
