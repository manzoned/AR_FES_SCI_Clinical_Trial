using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipPinchPalmPos : MonoBehaviour
{

    public TipPinch TipPinch;
    public Vector3 tempPosition;
    public Quaternion tempRotation;
    public Quaternion tempRotationLeft;
    //public HandTracking1 HandTracking;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(TipPinch.GraspState == 1 && TipPinch.targetParented == 0)
        {
            tempPosition = transform.position;
            tempRotation = transform.rotation;

         

        }

    }
}
