using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapistMiddleKnucklePos : MonoBehaviour
{
    public TherapistPalmPos TherapistPalmPos;
    public HandTracking1 HandTracking;
    public Vector3 tempPosition;
    public RegTherapistMiddleKnucklePos RegTherapistMiddleKnucklePos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TherapistPalmPos.therapistTrigger == 1)
        {
            tempPosition = HandTracking.middleKnucklePos;
            transform.position = tempPosition;
          // TherapistPalmPos.therapistTrigger = 0;
            RegTherapistMiddleKnucklePos.transform.position = tempPosition;
        }

    }
}
