using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LateralRig : MonoBehaviour
{
    public HandTracking1 HandTracking;
    public Lateral Lateral;
    public int GraspState;
    public Quaternion localRot;
    public Vector3 tempPos;
    public Quaternion tempRot;
    public Vector3 tempScale;
    public MainCamera MainCamera;

    public void Appear()
    {
        if(HandTracking.initialCal == 1)
        {
            if(Lateral.GraspState == 1 ) 
            {
                if(gameObject.activeInHierarchy)
                {

                }
                else
                {
                    gameObject.SetActive(true);
                    GraspState = 1;
                    //tempPos = new Vector3(0.215f, -0.04f, 0.75f);
                    tempPos = new Vector3(-0.07f, -0.04f, 0.85f);

                    tempRot.eulerAngles = new Vector3(-93f, -475f, 127f);
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
        transform.localPosition = new Vector3(0.105f, -0.04f, 0.85f);
        transform.localScale = new Vector3(-0.97f, 0.97f, 0.97f);
        localRot.eulerAngles = new Vector3(-93f, -445f, 80f);
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
