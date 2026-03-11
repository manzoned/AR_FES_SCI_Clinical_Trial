using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapistWristPos : MonoBehaviour
{
    public TherapistPalmPos TherapistPalmPos;
    public HandTracking1 HandTracking;
    public Vector3 tempPosition;
    public Quaternion tempRotation;
    public RegTherapistWristPos RegTherapistWristPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TherapistPalmPos.therapistTrigger == 1)
        {
            tempPosition = HandTracking.wristPos;
            tempRotation = HandTracking.wristRot;
            transform.position = tempPosition;
            transform.rotation = tempRotation;
            //TherapistPalmPos.therapistTrigger = 0;
            RegTherapistWristPos.transform.position = tempPosition;
        }

    }
}
