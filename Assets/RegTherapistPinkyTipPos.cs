using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegTherapistPinkyTipPos : MonoBehaviour
{
    public TherapistPinkyTipPos TherapistPinkyTipPos;
    public Vector3 tempPosition;
    public TherapistJoints TherapistJoints;

    public void RegTherapist()
    {
        transform.position = TherapistPinkyTipPos.tempPosition;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(TherapistJoints.GraspState == 1 && TherapistJoints.regTrigger > 5)
        {

        }
    }
}
