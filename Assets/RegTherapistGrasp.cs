using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegTherapistGrasp : MonoBehaviour
{
    public TherapistPalmPos TherapistPalmPos;

    public void Appear()
    {
        if(TherapistPalmPos.therapistCreated == 1)
        {
            gameObject.SetActive(true);
        }
        
    }
    public void Disappear() 
    { gameObject.SetActive(false); }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
