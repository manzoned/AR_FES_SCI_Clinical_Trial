using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSphere : MonoBehaviour
{
    public PlaneCreator PlaneCreator;
    public HandTracking1 HandTracking1;
    public ForearmPos ForearmPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        transform.position = PlaneCreator.Plane.ClosestPointOnPlane(HandTracking1.wristPos);
        

    }
}
