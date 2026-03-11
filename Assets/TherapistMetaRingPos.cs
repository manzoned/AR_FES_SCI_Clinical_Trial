using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapistMetaRingPos : MonoBehaviour
{
    public TherapistPalmPos TherapistPalmPos;
    public HandTracking1 HandTracking;
    public Vector3 tempPosition;
    public RegTherapistMetaRingPos RegTherapistMetaRingPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TherapistPalmPos.therapistTrigger == 1)
        {
            tempPosition = HandTracking.metaRingPos;
            transform.position = tempPosition;
         //   TherapistPalmPos.therapistTrigger = 0;
            RegTherapistMetaRingPos.transform.position = tempPosition;
        }

    }
}
