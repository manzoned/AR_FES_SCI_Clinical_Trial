using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipPinchMetaIndexPos : MonoBehaviour
{
    public TipPinch TipPinch;
    public Vector3 tempPosition;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TipPinch.GraspState == 1 && TipPinch.targetParented == 0)
        {
            tempPosition = transform.position;
            transform.position = tempPosition;
        }
        tempPosition = transform.position;
    }
}