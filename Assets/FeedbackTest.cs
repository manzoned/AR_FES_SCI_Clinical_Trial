using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedbackTest : MonoBehaviour
{
    public TipPinch TipPinch;
    public Lateral Lateral;
    public LargeDiameter LargeDiameter;
    public TherapistGrasp TherapistGrasp;
    public TextMeshProUGUI guidanceOutput;
    public SolverHandler SolverHandler;
    public HandTracking1 HandTracking;

    public void GuidanceInstructions()
    {
        if(TipPinch.GraspState == 1 || Lateral.GraspState == 1 || LargeDiameter.GraspState == 1)
        {
            //gameObject.SetActive(true);
        }
        if(TherapistGrasp.GraspState == 1)
        {
            gameObject.SetActive(false);
        }
        if(TipPinch.GraspState == 1)
        {
            guidanceOutput.text = "Grasp the object between the tips of you index finger and thumb";

        }
        if(Lateral.GraspState == 1)
        {
            guidanceOutput.text = "Grasp the object between your thumb and the side of your index finger";
        }
        if(LargeDiameter.GraspState == 1)
        {
            guidanceOutput.text = "Grasp the object between all of your fingers";
        }

        if (HandTracking.HandUsed == 1)
        {
            SolverHandler.AdditionalOffset = new Vector3(-0.2f, -0.2f, 0.4f);

        }
        if (HandTracking.HandUsed == 2)
        {
            SolverHandler.AdditionalOffset = new Vector3(0.2f, -0.2f, 0.4f);

        }
    }

    public void GuidanceInstructionsOff()
    {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
