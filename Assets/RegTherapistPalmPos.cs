using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegTherapistPalmPos : MonoBehaviour
{
    public TherapistPalmPos TherapistPalmPos;
    public RegTherapistPalmPos regTherapistPalmPos;
    public Vector3 tempPosition;
    public Quaternion tempRotation;
    public HandTracking1 HandTracking;

    // maybe a function that just takes the opposite position
    public void RegTherapist()
    {
        tempPosition = TherapistPalmPos.tempPosition;
        tempRotation = TherapistPalmPos.tempRotation;
        transform.position = tempPosition;
        transform.rotation = tempRotation;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TherapistPalmPos.therapistTrigger == 1)
        {
            tempPosition = HandTracking.palmPos;
            tempRotation = HandTracking.palmRot;

            transform.position = tempPosition;
            transform.rotation = tempRotation;
        }
    }
}
