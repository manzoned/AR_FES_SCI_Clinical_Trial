using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegTherapistPinkyMiddlePos : MonoBehaviour
{
    public TherapistPinkyMiddlePos TherapistPinkyMiddlePos;
    public Vector3 tempPosition;

    public void RegTherapist()
    {
        tempPosition = TherapistPinkyMiddlePos.tempPosition;
        transform.position = tempPosition;
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
