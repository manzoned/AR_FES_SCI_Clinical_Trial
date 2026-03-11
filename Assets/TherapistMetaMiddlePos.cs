using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapistMetaMiddlePos : MonoBehaviour
{
    public TherapistPalmPos TherapistPalmPos;
    public HandTracking1 HandTracking;
    public Vector3 tempPosition;
    public RegTherapistMetaMiddlePos RegTherapistMetaMiddlePos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TherapistPalmPos.therapistTrigger == 1)
        {
            tempPosition = HandTracking.metaMiddlePos;
            transform.position = tempPosition;
           // TherapistPalmPos.therapistTrigger = 0;
            RegTherapistMetaMiddlePos.transform.position = tempPosition;
        }

    }
}
