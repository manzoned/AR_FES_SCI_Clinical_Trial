using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegTherapistPinkyKnucklePos : MonoBehaviour
{
    public TherapistPinkyKnucklePos TherapistPinkyKnucklePos;
    public Vector3 tempPosition;
      
    public void RegTherapist()
    {
        transform.position = TherapistPinkyKnucklePos.tempPosition;
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
