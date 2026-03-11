using UnityEngine;

public class IndexKnucklePlane : MonoBehaviour
{
    public IndexKnucklePlane indexKnucklePlane;
    public HandTracking1 HandTracking;
    public float ThumbDistancePlane;

    public Plane Plane
    {
        private set; get;
    }

    void Start()
    {

    }

    void Update()
    {
        Plane = new Plane(transform.up, transform.position);
        ThumbDistancePlane = Plane.GetDistanceToPoint(HandTracking.thumbTipPos);
        //Debug.Log(ThumbDistancePlane);
        
    }

    
}