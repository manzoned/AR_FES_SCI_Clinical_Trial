using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapistRig : MonoBehaviour
{
    public HandTracking1 HandTracking;
    public TherapistJoints TherapistJoints;
    public TherapistPalmPos TherapistPalmPos;
    public MeshController MeshController;
    public int GraspState;
    public Vector3 localPos;
    public Quaternion localRot;
    public Vector3 tempRotation;

    public void Appear()
    {
        if (HandTracking.initialCal == 1 && TherapistPalmPos.therapistCreated == 1)
        {
            if (TherapistJoints.GraspState == 1)
            {
                gameObject.SetActive(true);
                MeshController.TherapistMesh();
                MeshController.TherapistMeshSet = 1;
                MeshController.initialThumbRigSet++;
                GraspState = 1;

                if(HandTracking.HandUsed == 1)
                {
                    localPos = new Vector3(0.22f, -0.05f, 0.75f);
                    localRot = new Quaternion(0f, 0f, 0f, 0f);
                    localRot.eulerAngles = new Vector3(-100f, -145f, 0f);
                    transform.localScale = new Vector3(0.97f, 0.97f, 0.97f);
                }
                if(HandTracking.HandUsed == 2)
                {
                    //start here
                    localPos = new Vector3(0.09f, -0.05f, 0.75f);
                    localRot = new Quaternion(0f, 0f, 0f, 0f);
                    localRot.eulerAngles = new Vector3(-100f, 0f, 150f);
                    transform.localScale = new Vector3(-0.97f, 0.97f, 0.97f);
                }




                gameObject.transform.SetLocalPositionAndRotation(localPos, localRot);
            }
        }
    }

    public void Disappear()
    {
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
