using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegTherapistPinkyDistalPos : MonoBehaviour
{
    public TherapistPinkyDistalPos TherapistPinkyDistalPos;
    public Vector3 tempPositon;

    public void RegTherapist()
    {
        tempPositon = TherapistPinkyDistalPos.tempPosition;
        transform.position = tempPositon;
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
