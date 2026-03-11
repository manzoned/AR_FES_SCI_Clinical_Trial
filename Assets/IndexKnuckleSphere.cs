using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexKnuckleSphere : MonoBehaviour
{
    public HandTracking1 HandTracking;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = HandTracking.indexKnucklePos;
        transform.rotation = HandTracking.indexKnuckleRot;
    }
}
