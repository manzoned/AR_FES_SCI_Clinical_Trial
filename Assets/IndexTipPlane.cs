using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexTipPlane : MonoBehaviour
{
    public Transform jointTransform; // Reference to the joint transform

    private Plane Plane;

    // Start is called before the first frame update
    void Start()
    {
/*        if (jointTransform == null)
        {
            Debug.LogError("Joint Transform is not assigned!");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the plane normal based on the joint's forward direction
        Vector3 planeNormal = jointTransform.forward;

        // Create the plane using the current transform's position and the calculated normal
        Plane = new Plane(planeNormal, transform.position);
    }
}