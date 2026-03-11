using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegPalmPos : MonoBehaviour
{
    public HandTracking1 HandTracking;
    public Vector3 tempPosition;
    public Quaternion tempRotation;

    private Vector3 offsetPos;
    private Vector3 newPos;
    private Quaternion offsetRot;
    private Quaternion newRot;

  //public TargetPalm TargetPalm;
    public PalmPos PalmPos;
    Vector3 regAngle;

    // Start is called before the first frame update
    void Start()
    {

        /*offsetPos = new Vector3(-0.01f, -0.01f, -0.01f);
        offsetRot = new Quaternion(-0.01f, -0.01f, -0.01f, -0.01f);*/

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            /*tempPosition = HandTracking.palmPos;
            tempRotation = HandTracking.palmRot;*/
            tempPosition = PalmPos.tempPosition;
            tempRotation = PalmPos.tempRotation;
            transform.position = tempPosition;
            transform.rotation = tempRotation;

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Vector3 destroyPos = new Vector3(-10f, -10f, -10f);
            transform.position = destroyPos;
        }

        /*        if (Input.GetKeyDown(KeyCode.Alpha6))
                {


                    offsetPos = TargetPalm.tempPosition - tempPosition;
                    newPos = tempPosition + offsetPos;
                    newPos.y = newPos.y + 0.2f;
        *//*            offsetRot.x = TargetPalm.tempRotation.x - tempRotation.x;
                    offsetRot.y = TargetPalm.tempRotation.y - tempRotation.y;
                    offsetRot.z = TargetPalm.tempRotation.z - tempRotation.z;
                    offsetRot.w = TargetPalm.tempRotation.w - tempRotation.w;
                    newRot.x = tempRotation.x + offsetRot.x;
                    newRot.y = tempRotation.y + offsetRot.y;
                    newRot.z = tempRotation.z + offsetRot.z;
                    newRot.w = tempRotation.w + offsetRot.w;*//*

                    transform.position = newPos;
        *//*            transform.rotation = newRot;
                    regAngle = new Vector3(-60f, -60f, 10f);
                    Quaternion regTarRot = new Quaternion(0f, 0f, 0f, 0);
                    regTarRot.eulerAngles = regAngle;
                    transform.rotation = regTarRot;*//*
                }*/



    }
}
