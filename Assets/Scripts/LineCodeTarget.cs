using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCodeTarget : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Transform origin;
    public Transform destination;
    public TipPinch TipPinch;

/*    public void Redraw()
    {
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, destination.position);
    }*/
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

        
    }
}
