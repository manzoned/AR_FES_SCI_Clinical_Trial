using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegTipPinchPalmPos : MonoBehaviour
{

    public TipPinch TipPinch;
    public Vector3 tempPosition;
    public Quaternion tempRotation;
    public RegTipPinch RegTipPinch;

    public void TipPinchPalm()
    {

        tempPosition = transform.position;
        tempRotation = transform.rotation;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (RegTipPinch.GraspState == 1)
        {
            tempPosition = transform.position;
            tempRotation = transform.rotation;
            transform.rotation = tempRotation;
            transform.position = tempPosition;
        }
    }
}
