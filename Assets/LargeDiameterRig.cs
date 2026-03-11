using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDiameterRig : MonoBehaviour
{
    public HandTracking1 HandTracking;
    public LargeDiameter LargeDiameter;
    public int GraspState;
    public Quaternion localRot;
    public Vector3 tempPos;
    public Quaternion tempRot;
    public Vector3 tempScale;
    public MainCamera MainCamera;

    public void Appear()
    {
        if (HandTracking.initialCal == 1)
        {
            if(LargeDiameter.GraspState == 1)
            {
                if(gameObject.activeInHierarchy) // if you already called for the target posture, dont run the same code again
                {

                }
                else
                {
                    gameObject.SetActive(true);
                    GraspState = 1;
                    //tempPos = new Vector3(0.25f, -0.02f, 0.75f);
                    tempPos = new Vector3(-0.07f, -0.03f, 0.75f);

                    tempRot.eulerAngles = new Vector3(-132f, -360f, 27f);
                    tempScale = new Vector3(0.97f, 0.97f, 0.97f);

                    if (HandTracking.HandUsed == 1)
                    {
                        transform.localScale = tempScale;
                        transform.localPosition = tempPos;
                        transform.localRotation = tempRot;
                    }
                    if (HandTracking.HandUsed == 2)
                    {
                        LeftHandAdjustment();
                    }
                }

            }
        }
    }

    public void LeftHandAdjustment()
    {
        transform.localPosition = new Vector3(0.07f, -0.03f, 0.75f);
        transform.localScale = new Vector3(-0.97f, 0.97f, 0.97f);
        localRot.eulerAngles = new Vector3(-132f, -360f, -27f);
        transform.transform.localRotation = localRot;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
