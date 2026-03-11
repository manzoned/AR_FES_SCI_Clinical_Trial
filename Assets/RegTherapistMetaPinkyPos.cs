using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegTherapistMetaPinkyPos : MonoBehaviour
{
    public TherapistMetaPinkyPos TherapistMetaPinkyPos;
    public RegTherapistMetaPinkyPos regTherapistMetaPinkyPos;
    public Vector3 tempPosition;

    public void RegTherapist()
    {
        tempPosition = TherapistMetaPinkyPos.tempPosition;
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
