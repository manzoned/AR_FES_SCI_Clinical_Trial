using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineCode : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Transform origin;
    public Transform destination;
    public PalmPos PalmPos;
    public int test;
    public int test2;
    public TherapistPalmPos TherapistPalmPos;
    public TherapistJoints TherapistJoints;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.005f;
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, destination.position);

    }

    // Update is called once per frame
    void Update()
    {

        if (PalmPos.lineActive == 0)
        {
            test = 0; test2 = 0;
            lineRenderer.SetPosition(0, origin.position);
            lineRenderer.SetPosition(1, destination.position);
        }

        if (PalmPos.lineActive == 1 && test < 4)
        {
            lineRenderer.SetPosition(0, origin.position);
            lineRenderer.SetPosition(1, destination.position);
            test++;

        }


        // need something to draw lines after joints move

        if (PalmPos.StartAlign > 0 && test2 < 4) 
        {
            lineRenderer.SetPosition(0, origin.position);
            lineRenderer.SetPosition(1, destination.position);
            test2++;
        }




        // need to draw lines for therapist position
        if (TherapistPalmPos.therapistTrigger == 1)
        {
            lineRenderer.SetPosition(0, origin.position);
            lineRenderer.SetPosition(1, destination.position);
        }


    }
    
}
