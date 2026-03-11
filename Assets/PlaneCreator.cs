using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCreator : MonoBehaviour
{
    public PlaneCreator planeCreator;
    public HandTracking1 HandTracking1;
    //[SerializeField] Transform sphereTransform;
    public int crossed;
    //public ForearmPos forearmPos;

    public Plane Plane
    {
        private set; get;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Plane = new Plane(transform.up, transform.position);
        
        if (HandTracking1.HandUsed == 1)
        {
            if(Plane.GetSide(HandTracking1.middleKnucklePos))
            {
                crossed = 1;
            }
            else
            {
                crossed = 0;
            }
        }
        if (HandTracking1.HandUsed == 2)
        {
            if (Plane.GetSide(HandTracking1.middleKnucklePos))
            {
                crossed = 0;
            }
            else
            {
                crossed = 1;
            }
        }

    }
}
