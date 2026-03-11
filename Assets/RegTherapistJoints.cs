using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RegTherapistJoints : MonoBehaviour
{
    public int GraspState;
    public TherapistJoints TherapistJoints;
    public PalmPos PalmPos;
    public Vector3 localPos;
    public Quaternion localRot;
    public HandTracking1 HandTracking;

    public void Align()
    {
        if (GraspState == 1)
        {
            if (HandTracking.HandUsed == 1)
            {
                localPos.x = -0.18f;
            }
            if (HandTracking.HandUsed == 2)
            {
                localPos.x = -0.21f;
            }
            localPos.y = TherapistJoints.localPos.y;
            localPos.z = TherapistJoints.localPos.z;
            localRot = TherapistJoints.localRotCamera;
            transform.SetLocalPositionAndRotation(localPos, localRot);
            PalmPos.AlignPositions();
            
        }
    }

    public void Disappear()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
/*        localPos.x = -0.15f;
        localPos.y = TherapistJoints.localPos.y;
        localPos.z = TherapistJoints.localPos.z;*/

        localRot = new Quaternion(0f, 0f, 0f, 0f);
        localRot.eulerAngles = new Vector3(-85.6f, -25f, 0f);
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
