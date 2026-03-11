using UnityEngine;

public class FingerPlane2 : MonoBehaviour
{
    public GameObject IndexTipSphere;
    public GameObject IndexKnuckleSphere;
    public HandTracking1 HandTracking;

    private Plane plane;

    void Start()
    {

    }

    void Update()
    {
        // Calculate finger direction
        Vector3 fingerDirection = IndexTipSphere.transform.position - IndexKnuckleSphere.transform.position;

        // Calculate plane normal (perpendicular to finger direction)
        Vector3 planeNormal = Vector3.Cross(fingerDirection, Vector3.up).normalized;

        // Create the plane
        plane = new Plane(planeNormal, IndexKnuckleSphere.transform.position);


        Debug.Log(IndexTipSphere.transform.position);
        Debug.Log(IndexKnuckleSphere.transform.position);
        Debug.Log(plane.GetDistanceToPoint(HandTracking.thumbTipPos));
    }

}