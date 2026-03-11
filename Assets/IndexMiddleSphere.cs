using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexMiddleSphere : MonoBehaviour
{
    public HandTracking1 HandTracking;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = HandTracking.indexMiddlePos;
        transform.rotation = HandTracking.indexMiddleRot;

    }
}
