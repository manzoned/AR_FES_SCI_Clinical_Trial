using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapistGrasp : MonoBehaviour
{
    public int GraspState;
    public TipPinch TipPinch;
    public Lateral Lateral;
    public LargeDiameter LargeDiameter;
    public TherapistGrasp therapistGrasp;
    //public RegLargeDiameter RegLargeDiameter;
    public MainCamera MainCamera;
    public PalmPos PalmPos;
    private Vector3 localPos;
    private Quaternion localRot;
    public HandTracking1 HandTracking;
    public float TargetDiff;
    public float calibrateRatio;
    public Vector3 calibrateRatioVector;
    public int calibrateState;
    public int postureState;
    public int waitKey;
    public int targetParented;
    public TherapistWristPos TherapistWristPos;
    public TherapistIndexKnucklePos TherapistIndexKnucklePos;
    public TrialNumberController TrialNumberController;
    public TherapistPalmPos TherapistPalmPos;
   // public BlockingPlaneLargeDiameter BlockingPlaneLargeDiameter;
    public void Appear()
    {
        if(TherapistPalmPos.therapistCreated == 1)
        {
            gameObject.SetActive(true);
        }

    }
    public void Disappear()
    { gameObject.SetActive(false); }    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
