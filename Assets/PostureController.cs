//using Microsoft.MixedReality.GraphicsTools.Editor;
using Microsoft.MixedReality.Toolkit.Physics;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class PostureController : MonoBehaviour
{
    public TextMeshProUGUI targetTitleOutput_right;
    public TextMeshProUGUI targetTitleOutput_left;
    public TextMeshProUGUI performanceOutput;
    public TextMeshProUGUI calibrationOutput;
    public TextMeshProUGUI guidanceFreqOutput;
    public TextMeshProUGUI handednessOutput;
    public Lateral Lateral;
    public LargeDiameter LargeDiameter;
    public TipPinch TipPinch;
    public TherapistJoints TherapistJoints;
    public RegLateral RegLateral;
    public RegLargeDiameter RegLargeDiameter;
    public RegTipPinch RegTipPinch;
    public PalmPos PalmPos;
    public HandTracking1 HandTracking;
    public InstructionsPart5 Instructions;
    public TrialNumberController TrialNumberController;
    public int guidanceStateLateral;
    public int guidanceStateLargeDiameter;
    public int guidanceStateTipPinch;
    public int guidanceStateTherapist;

    public ForearmPos forearmPos;
    public TextMeshProUGUI wristAngleOutput;
    public TextMeshProUGUI wristAngleOutput2;
    public TextMeshProUGUI indexAngleOutput;

    public PlaneCreator PlaneCreator;
    public ErrorScoreScript_v2 errorScoreScript;
    public FeedbackScreen FeedbackScreen;

    // Start is called before the first frame update
    void Start()
    {
        Instructions.guidanceFreq = 3; // default is high guidance
    }

    // Update is called once per frame
    void Update()
    {

        // Messages related for forearm tracking
        // only include if target posture if called (based on a trigger)
        // if posture called and cant track forearm, display 'forearm not detected'
        // when asking for score, if threshold exceeded (based on a trigger), display 'tenodesis detected'

        if (PalmPos.StartAlign == PalmPos.StartAlignThreshold)
        {
            performanceOutput.text = "Performance:";

            if (forearmPos.forearmTracking == 1)
            {
                if (errorScoreScript.setWristAngle == 0)
                {
                    wristAngleOutput.text = "";
                }

                else if (errorScoreScript.setWristAngle > 0)
                {
                    // write tenodesis detected if it was, code in threshold trigger
                    if (errorScoreScript.TenodesisDetected == 1)
                    {
                        wristAngleOutput.text = "Wrist Angle: " + errorScoreScript.setWristAngle + "\n"
                                                + "Tenodesis Detected!";
                        wristAngleOutput.color = Color.red;
                    }

                    else if (errorScoreScript.TenodesisDetected == 0)
                    {
                        wristAngleOutput.text = "Wrist Angle: " + errorScoreScript.setWristAngle;
                        wristAngleOutput.color = Color.white;
                    }
                }
            }
            else if (forearmPos.forearmTracking == 0)
            {
                wristAngleOutput.text = "";
            }

        }
        else if (PalmPos.StartAlign == 0)
        {
            performanceOutput.text = "";

            if(forearmPos.forearmTracking == 1)
            {
                if (Lateral.GraspState == 1 || LargeDiameter.GraspState == 1 || TipPinch.GraspState == 1 || TherapistJoints.GraspState == 1)
                {
                    if (errorScoreScript.positionset == 0)
                    {
                        // start looking for forearm tracking
                        if (forearmPos.trackTest == 1)
                        {
                            wristAngleOutput.text = "Forearm detected!";
                            wristAngleOutput.color = Color.green;
                        }

                        else if (forearmPos.trackTest == 0)
                        {
                            wristAngleOutput.text = "Forearm not detected!";
                            wristAngleOutput.color = Color.red;
                        }
                    }

                    else if (errorScoreScript.positionset == 1)
                    {
                        wristAngleOutput.text = "";
                    }


                }
                else if (Lateral.GraspState == 0 && LargeDiameter.GraspState == 0 && TipPinch.GraspState == 0 && TherapistJoints.GraspState == 0)
                {
                    wristAngleOutput.text = "";
                }
            }
            else if (forearmPos.forearmTracking == 0)
            {
                wristAngleOutput.text = "";
            }

        }



        // input a title if a target grasp is set
        if (Lateral.GraspState == 1 || LargeDiameter.GraspState == 1 || TipPinch.GraspState == 1 || TherapistJoints.GraspState == 1)
        {
            if(FeedbackScreen.FeedbackScreenState == 0)
            {
                if(HandTracking.HandUsed == 1)
                {
                    targetTitleOutput_left.text = "Target Posture:";
                    targetTitleOutput_right.text = "";
                }
                if (HandTracking.HandUsed == 2)
                {
                    targetTitleOutput_left.text = "";
                    targetTitleOutput_right.text = "Target Posture:";
                }


            }

        }
        if (Lateral.GraspState == 0 && LargeDiameter.GraspState == 0 && TipPinch.GraspState == 0 && TherapistJoints.GraspState == 0)
        { 
                targetTitleOutput_left.text = "";
                targetTitleOutput_right.text = "";

        }
        if (FeedbackScreen.FeedbackScreenState == 1)
        {
            targetTitleOutput_left.text = "";
            targetTitleOutput_right.text = "";
        }

        // input a title if an actual grasp posture is set
/*        if (PalmPos.StartAlign == 10)
        {
            performanceOutput.text = "Performance:";

        }
        else if (PalmPos.StartAlign == 0)
        {
            performanceOutput.text = "";
        }*/

        // input message to confirm the end of calibration
        if (HandTracking.initialCal == 1)
        {
            if (Lateral.calibrateState == 0 || LargeDiameter.calibrateState == 0 || TipPinch.calibrateState == 0 || TherapistJoints.calibrateState == 0)
            {
                calibrationOutput.text = "Calibration Complete!";
                calibrationOutput.color = Color.green;
            }
            
            if (Lateral.calibrateState == 1 || LargeDiameter.calibrateState == 1 || TipPinch.calibrateState == 1 || TherapistJoints.calibrateState == 1)
            {
                calibrationOutput.text = "";
            }
            
        }
        
        if (HandTracking.redoCal == 1) 
        {
            calibrationOutput.text = "Redo Calibration!";
            calibrationOutput.color = Color.red;
        }

/*        if (HandTracking.redoCal == 0 && HandTracking.initialCal == 0)
        {
            calibrationOutput.text = "Please Begin Calibration (say: calibrate)";
        }*/

/*        if (Instructions.guidanceFreq == 0)
        {
            guidanceFreqOutput.text = "Please select a guidance frequency (say: low guidance, medium guidance, or high guidance)";
            guidanceFreqOutput.color = Color.red;
        }

        if (Instructions.guidanceFreq > 0)
        {
            guidanceFreqOutput.text = "";
        }

        if (HandTracking.HandUsed == 0)
        {
            handednessOutput.text = "Please select your hand (say: right hand or left hand)";
            handednessOutput.color = Color.red;
        }

        if (HandTracking.HandUsed > 0)
        {
            handednessOutput.text = "";
        }*/
        
        // code to define different guidance levels specific to each grasp type

        // 100% guidance
        if(Instructions.guidanceFreq == 3)
        {
            guidanceStateLateral = 0;
            guidanceStateLargeDiameter = 0;
            guidanceStateTipPinch = 0;
            guidanceStateTherapist = 0;
        }

        // 50% guidance... need to make use of internal counters
        if(Instructions.guidanceFreq == 2)
        {
            // if task counter is odd or even, then show feedback or don't
            int remainderLateral = TrialNumberController.lateralCounter % 2;
            int remainderLargeDiameter = TrialNumberController.largeDiameterCounter % 2;
            int remainderTipPinch = TrialNumberController.tipPinchCounter % 2;
            int remainderTherapist = TrialNumberController.customPoseCounter % 2;

            if (remainderLateral == 1)
            {
                guidanceStateLateral = 1;
            }
            if(remainderLateral == 0)
            {
                guidanceStateLateral = 0;
            }
            if(remainderLargeDiameter == 1)
            {
                guidanceStateLargeDiameter = 1;
            }
            if(remainderLargeDiameter == 0)
            {
                guidanceStateLargeDiameter = 0;
            }
            if(remainderTipPinch == 1)
            {
                guidanceStateTipPinch = 1;
            }
            if(remainderTipPinch == 0)
            {
                guidanceStateTipPinch = 0;
            }
            if(remainderTherapist == 1)
            {
                guidanceStateTherapist = 1;
            }
            if(remainderTherapist == 0)
            {
                guidanceStateTherapist = 0;
            }

        }

        // 33% guidance... need to make use of internal counters
        if(Instructions.guidanceFreq == 1)
        {
            int remainderLateral = TrialNumberController.lateralCounter%3;
            int remainderLargeDiameter = TrialNumberController.largeDiameterCounter%3;
            int remainderTipPinch = TrialNumberController.tipPinchCounter%3;
            int remainderTherapist = TrialNumberController.customPoseCounter%3;

            if (remainderLateral == 1 || remainderLateral == 2)
            {
                guidanceStateLateral = 1;
            }
            if (remainderLateral == 0)
            {
                guidanceStateLateral = 0;
            }
            if (remainderLargeDiameter == 1 || remainderLargeDiameter == 2)
            {
                guidanceStateLargeDiameter = 1;
            }
            if (remainderLargeDiameter == 0)
            {
                guidanceStateLargeDiameter = 0;
            }
            if (remainderTipPinch == 1 || remainderTipPinch == 2)
            {
                guidanceStateTipPinch = 1;
            }
            if (remainderTipPinch == 0)
            {
                guidanceStateTipPinch = 0;
            }
            if(remainderTherapist == 1 || remainderTherapist==2)
            {
                guidanceStateTherapist = 1;
            }
            if(remainderTherapist == 0)
            {
                guidanceStateTherapist= 0;
            }

        }
    } 
}
