using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class TimerTextBox : MonoBehaviour
{
    private float TimeRemaining;
    private bool ContinueTimer;
    public TextMeshPro TimerTextBoxNumber;
    public TextMeshPro timerTextBox;
    public UDPSender UDPSender;
    public TargetPosturePanel TargetPosturePanel;
    public TrialNumberController TrialNumberController;
    public TipPinch TipPinch;
    public LargeDiameter LargeDiameter;
    public Lateral Lateral;
    public bool ParticipantInitiated;
    public Timer Timer;
    public InstructionsBackPlate InstructionsBackPlate;
    public RepetitionsBackPlate RepetitionsBackPlate;
    public RepetitionTextBox RepetitionTextBox;
    public StimDashBackPlate DashboardBackPlate;
    public StimulationVisualizerTarget StimulationVisualizerTarget;
    public StatsPrompt StatsPrompt;
    // trigger timer after person says ready

    public void CountdownStimStart()
    {
        ParticipantInitiated = false;
    }

    public void ParticipantStimStart()
    {
        ParticipantInitiated = true;
    }
    public void StartTimer()
    {
        if (TargetPosturePanel.ScreenIsOn == 1)
        {
            if(ParticipantInitiated)
            {
                TimeRemaining = 3f;
            }
            else { TimeRemaining = 10f; }
            ContinueTimer = true;
        }

    }

    public void StopStim()
    {
        timerTextBox.fontSize = 0.2f;
        timerTextBox.text = "Stim OFF!";
        TimerTextBoxNumber.text = "";
        timerTextBox.transform.localPosition = new Vector3(timerTextBox.transform.localPosition.x, 0.2f, timerTextBox.transform.localPosition.z);

        // Timer.gameObject.SetActive(false);

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ContinueTimer)
        {

            if (TimeRemaining > 0)
            {
                TimeRemaining -= Time.deltaTime;
                //Debug.Log(TimeRemaining);
                timerTextBox.fontSize = 0.11f;
                timerTextBox.text = "Stim starts in:";
                timerTextBox.transform.localPosition = new Vector3(timerTextBox.transform.localPosition.x, 1.2f, timerTextBox.transform.localPosition.z);
                InstructionsBackPlate.gameObject.SetActive(true);
                DashboardBackPlate.gameObject.SetActive(false);
                StimulationVisualizerTarget.gameObject.SetActive(false);
            }
            else
            {
                TimeRemaining = 0;
                ContinueTimer = false;
                //Debug.Log("timer done");
                TimerTextBoxNumber.text = "";
                timerTextBox.fontSize = 0.2f;
                timerTextBox.text = "Stim ON!";
                timerTextBox.transform.localPosition = new Vector3(timerTextBox.transform.localPosition.x, 0.2f, timerTextBox.transform.localPosition.z);
                UDPSender.StartStim();
                DashboardBackPlate.gameObject.SetActive(true);
                StimulationVisualizerTarget.gameObject.SetActive(true);
                Timer.gameObject.SetActive(false);
                InstructionsBackPlate.gameObject.SetActive(false);
                RepetitionsBackPlate.gameObject.SetActive(false);
                RepetitionTextBox.gameObject.SetActive(false);
                //StatsPrompt.gameObject.SetActive(false);
            }

            if (TimeRemaining > 0 && TimeRemaining <= 15)
            {
                TimerTextBoxNumber.text = Math.Ceiling(TimeRemaining).ToString();
            }

        }
    }
}
