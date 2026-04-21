using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using TMPro;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;

public class UDPSender : MonoBehaviour
{

    private UdpClient udpClient;
    public ErrorScoreScript_v2 ErrorScoreScript;
    public IP_Prompt IP_Prompt;
    //public IPTextBox IPTextBox;
    public TextMeshPro IP_PromptOutput;
    public Finger_off_textbox Finger_off_textbox;
    public Thumb_off_textbox Thumb_off_textbox;
    public Hand_open_off_textbox Hand_open_off_textbox;
    public Finger_off_textbox_target finger_Off_Textbox_Target;
    public Thumb_off_textbox_target thumb_Off_Textbox_Target;
    public Hand_off_textbox_target hand_off_textbox_target;
    public ProfileAmplitudes ProfileAmplitudes;
    public TextMeshPro Profile_AmplitudesOutput;
    public NewAmplitudes NewAmplitudes;
    public TextMeshPro NewAmplitudesOutput;
    public bool NormalBarFullRange;
    public float[] StimAmps;
    public float[] InitialAmps;
    public float fingerTempMax;
    public float thumbTempMax;
    public float normal_finger_min;
    public float normal_thumb_min;
    private float normal_finger_bar;
    private float normal_thumb_bar;
    public float finger_bar;
    public float thumb_bar;
    public float opening_bar;
    public float IndexKnuckleAngle;
    public float LateralIndexThreshold;
    public float manual_stim_offset;
    public float fingerIncrementer;
    public float thumbIncrementer;
    public float avgIncrementer;
    public string ExternalMachineIP;
    public bool SendToExternal;
    public bool StopStimState;
    public TimerTextBox TimerTextBox;
    public Lateral Lateral;
    public ExtensionStimBackPlate ExtensionStimBackPlate;
    public TargetPosturePanel TargetPosturePanel;
    private string TempString;
    private string AmpString;
    public int IPState;
    private bool ProfileAmpState;
    private bool ExtensionStimState;
    private bool NewFingerMinState;
    private bool NewFingerMaxState;
    private bool NewThumbMinState;
    private bool NewThumbMaxState;
    private bool NewOpenState;
    public ConfigManager ConfigManager;
    public StimulationVisualizer StimulationVisualizer;
    public StimulationVisualizerTarget StimulationVisualizerTarget;
    public ProfileManager ProfileManager;
    public DataManager DataManager;
    public StatsPanel StatsPanel;
    public HandUsePrompt HandUsePrompt;





    void Start()
    {
        udpClient = new UdpClient();
        StimAmps = new float[3];
        InitialAmps = new float[5];
        //ExternalMachineIP = "";
        ExternalMachineIP = ConfigManager.targetIPAddress;

        // Stimulation Visualization - start with everything off
        Finger_off_textbox.gameObject.SetActive(true);
        Thumb_off_textbox.gameObject.SetActive(true);
        Hand_open_off_textbox.gameObject.SetActive(true);
        finger_Off_Textbox_Target.gameObject.SetActive(true);
        thumb_Off_Textbox_Target.gameObject.SetActive(true);
        hand_off_textbox_target.gameObject.SetActive(true);
        finger_bar = 0f;
        thumb_bar = 0f;
        opening_bar = 0f;
        //StimulationVisualizer.Instance.UpdateVisuals(finger_bar, thumb_bar, opening_bar);
        StimulationVisualizerTarget.Instance.UpdateVisuals(finger_bar, thumb_bar, opening_bar);

    }

    public void BuildIPAddress()
    {
        // set externalmachineIP here using voice
        // not relevant if storing IP on headset
/*
        if (IPState == 0) // if IP complete isn't called this will be 0
        {
            ExternalMachineIP = ExternalMachineIP + TempString;
            IP_PromptOutput.text = "Input Laptop IP address here:" + "\n" + ExternalMachineIP;
        }
        else { }
        */
    }

    public void Backspace()
    {
/*        ExternalMachineIP = ExternalMachineIP.Replace(TempString, "");
        IP_PromptOutput.text = "Input Laptop IP address here:" + "\n" + ExternalMachineIP;*/
        AmpString = "";
        TempString = "";
        SetNewAmplitudesFingerMinValues();
        SetNewAmplitudesFingerMaxValues();
        SetNewAmplitudesThumbMinValues(); 
        SetNewAmplitudesThumbMaxValues(); 
        SetNewAmplitudeOpenMaxValues();

    }

    public void ResetIP()
    {


        IPState = 0;
        ExternalMachineIP = "";
        IP_PromptOutput.text = "Input Laptop IP address here:" + "\n" + ExternalMachineIP;
        IP_PromptOutput.color = new Color(255, 255, 255, 1f);
        IP_Prompt.gameObject.SetActive(true);
        SendToExternal = false;
    }

    public void IPComplete()
    {
        // finish/ set the external IP address here
        // stop listening 
        IPState = 1;
        SendToExternal = true;
        IP_Prompt.gameObject.SetActive(false);
    }

    public void StartStim()
    {
        StopStimState = false;
        ExtensionStimState = false;
        ExtensionStimBackPlate.gameObject.SetActive(false);
        fingerTempMax = 0;
        thumbTempMax = 0;
        manual_stim_offset = 0;
        normal_finger_min = normal_finger_bar;
        normal_thumb_min = normal_thumb_bar;
        StartCoroutine(SendVectorEverySecond());


    }

    public void StopStim()
    {
        if (StopStimState == false)
        {
            StopStimState = true;
            ExtensionStimState = false;
            ExtensionStimBackPlate.gameObject.SetActive(false);
            DataManager.RecordCurrentRepData();
            StatsPanel.UpdateCurrentSessionStats();
        }

        manual_stim_offset = 0;
        normal_finger_min = normal_finger_bar;
        normal_thumb_min = normal_thumb_bar;

        //StopAllCoroutines();
    }

    public void StartExtensionStim()
    {
        if (TargetPosturePanel.ScreenIsOn == 1)
        {
            //ExtensionStimBackPlate.gameObject.SetActive(true);
            //TimerTextBox.StopStim();
            ExtensionStimState = true;
            StartCoroutine(SendVectorEverySecond());
        }

    }

    public void StongerStim()
    {
        //manual_stim_offset = manual_stim_offset + avgIncrementer;
        if (normal_finger_min < StimAmps[0]) { }
        else
        {
            normal_finger_min = normal_finger_min + fingerIncrementer;
            if (normal_finger_min > 1) { normal_finger_min = 1; }
        }

        if (normal_thumb_min < StimAmps[1]) { }
        else
        {
            normal_thumb_min = normal_thumb_min + thumbIncrementer;
            if (normal_thumb_min > 1) { normal_thumb_min = 1; }
        }

    }

    public void WeakerStim()
    {
        //manual_stim_offset = manual_stim_offset - avgIncrementer;
        normal_finger_min = normal_finger_min - fingerIncrementer;
        normal_thumb_min = normal_thumb_min - thumbIncrementer;
        if (normal_finger_min < normal_finger_bar) { normal_finger_min = normal_finger_bar; }
        if (normal_thumb_min < normal_thumb_bar) { normal_thumb_min = normal_thumb_bar; }
    }

    IEnumerator SendVectorEverySecond() // change name
    {
        while (true)
        {
            if (ExtensionStimState == true)
            {

                StimAmps[0] = -1f;
                StimAmps[1] = -1f;
                StimAmps[2] = 1f; // full stimulation for extension (open loop for now)
                Finger_off_textbox.gameObject.SetActive(true);
                Thumb_off_textbox.gameObject.SetActive(true);
                Hand_open_off_textbox.gameObject.SetActive(false);
                finger_Off_Textbox_Target.gameObject.SetActive(true);
                thumb_Off_Textbox_Target.gameObject.SetActive(true);
                hand_off_textbox_target.gameObject.SetActive(false);
                opening_bar = 1f;
            }
            if (ExtensionStimState == false)
            {
                // Update the StimAmps array with values from ErrorScoreScript
                StimAmps[0] = ErrorScoreScript.FingerStimAmp;
                StimAmps[1] = ErrorScoreScript.ThumbStimAmp;
                StimAmps[2] = -1f; // extension amplitude should be zero

                //if (StimAmps[0] < normal_finger_min)
                //{ StimAmps[0] = normal_finger_min + manual_stim_offset; }
                //else
                //{ StimAmps[0] = StimAmps[0]  + manual_stim_offset; }

                //if (StimAmps[1] < normal_thumb_min)
                //{ StimAmps[1] = normal_thumb_min + manual_stim_offset; }
                //else
                //{ StimAmps[1] = StimAmps[1] + manual_stim_offset; }

                if (StimAmps[0] < normal_finger_min) { StimAmps[0] = normal_finger_min; }
                if (StimAmps[1] < normal_thumb_min) { StimAmps[1] = normal_thumb_min; }

                if (StimAmps[0] > 1) { StimAmps[0] = 1f; }
                if (StimAmps[1] > 1) { StimAmps[1] = 1f; }

                Hand_open_off_textbox.gameObject.SetActive(true);
                Finger_off_textbox.gameObject.SetActive(false);
                Thumb_off_textbox.gameObject.SetActive(false);
                hand_off_textbox_target.gameObject.SetActive(true);
                finger_Off_Textbox_Target.gameObject.SetActive(false);
                thumb_Off_Textbox_Target.gameObject.SetActive(false);
                opening_bar = 0f;

                if (StimAmps[0] > fingerTempMax) { fingerTempMax = StimAmps[0]; }
                if (StimAmps[1] > thumbTempMax) { thumbTempMax = StimAmps[1]; }

                if (Lateral.GraspState == 1) // for lateral grasp, only turn on thumb stim if fingers sufficiently flexed
                {
                    IndexKnuckleAngle = ErrorScoreScript.IndexKnuckleAngle;
                    LateralIndexThreshold = (ErrorScoreScript.TargetIndexKnuckleAngle + (ErrorScoreScript.upperbound_error_finger + ErrorScoreScript.TargetIndexKnuckleAngle)) / 2f;
                    if (IndexKnuckleAngle > LateralIndexThreshold)
                    {
                        StimAmps[1] = -1f;
                    }
                    else { StimAmps[1] = ErrorScoreScript.ThumbStimAmp; }
                    /*                    if (ErrorScoreScript.FingerStimAmp > 0.5)
                                        {
                                            StimAmps[1] = -1f;
                                        }
                                        else { StimAmps[1] = ErrorScoreScript.ThumbStimAmp; }*/
                }

                if (StopStimState == true)
                {
                    StimAmps[0] = -1f;
                    StimAmps[1] = -1f;
                    StimAmps[2] = -1f;
                    Finger_off_textbox.gameObject.SetActive(true);
                    Thumb_off_textbox.gameObject.SetActive(true);
                    Hand_open_off_textbox.gameObject.SetActive(true);
                    finger_Off_Textbox_Target.gameObject.SetActive(true);
                    thumb_Off_Textbox_Target.gameObject.SetActive(true);
                    hand_off_textbox_target.gameObject.SetActive(true);
                    StopAllCoroutines();
                }

            }


            // SEND TO UI 
            if (StimulationVisualizerTarget.Instance != null)
            {
                if (NormalBarFullRange == true)
                {
                    // normalize values based on initial amps

                    finger_bar = StimAmps[0];
                    thumb_bar = StimAmps[1];

                    if (StimAmps[0] < normal_finger_min)
                    {
                        finger_bar = normal_finger_min;
                    }

                    if (StimAmps[1] < normal_thumb_min)
                    {
                        thumb_bar = normal_thumb_min;
                    }



                }
                else
                {
                    finger_bar = Mathf.InverseLerp(normal_finger_bar, 1, StimAmps[0]);
                    thumb_bar = Mathf.InverseLerp(normal_thumb_bar, 1, StimAmps[1]);
                    //finger_bar = StimAmps[0];
                    //thumb_bar = StimAmps[1];
                    if (finger_bar < 0.1)
                    {
                        finger_bar = 0.1f;
                    }

                    if (thumb_bar < 0.1)
                    {
                        thumb_bar = 0.1f;
                    }
                }

                if (StimAmps[0] < 0) { finger_bar = 0f; Finger_off_textbox.gameObject.SetActive(true); finger_Off_Textbox_Target.gameObject.SetActive(true); }
                if (StimAmps[1] < 0) { thumb_bar = 0f; Thumb_off_textbox.gameObject.SetActive(true); thumb_Off_Textbox_Target.gameObject.SetActive(true); }

                //StimulationVisualizer.Instance.UpdateVisuals(finger_bar, thumb_bar, opening_bar);
                StimulationVisualizerTarget.Instance.UpdateVisuals(finger_bar, thumb_bar, opening_bar);




            }

            // Send the array data
            SendArray(StimAmps);

            yield return new WaitForSeconds(0.1f); // Wait to send array

        }
    }

    void SendArray(float[] array)
    {
        byte[] data = new byte[array.Length * 4];
        for (int i = 0; i < array.Length; i++)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(array[i]), 0, data, i * 4, 4);
        }
        if (SendToExternal == true)
        {
            udpClient.Send(data, data.Length, ExternalMachineIP, 55001); // sending to an external computer
        }
        else
        {
            udpClient.Send(data, data.Length, "127.0.0.1", 55001); // sending to the same computer
        }

        Debug.Log("Array sent: " + string.Join(", ", array));
    }

    public void ResendAmps()
    {
        // resend amps incase they don't initially get sent to python from headset
        // SendInitialStimAmps not working reliably when deploy app
        byte[] data = new byte[InitialAmps.Length * 4];
        for (int i = 0; i < InitialAmps.Length; i++)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(InitialAmps[i]), 0, data, i * 4, 4);
        }

        if (SendToExternal == true)
        {
            udpClient.Send(data, data.Length, ExternalMachineIP, 55001); // sending to an external computer

        }

        else
        {
            udpClient.Send(data, data.Length, "127.0.0.1", 55001); // sending to the same computer
        }
    }
    public void SendInitialStimAmps()
    {
        NewAmplitudes.gameObject.SetActive(false);
        //Debug.Log(ProfileManager.activeProfile.finger_min);

        // retrieve amplitude information from profile (initially added by experimenter manually)
        InitialAmps[0] = ProfileManager.activeProfile.finger_min;
        InitialAmps[1] = ProfileManager.activeProfile.finger_max;
        InitialAmps[2] = ProfileManager.activeProfile.thumb_min;
        InitialAmps[3] = ProfileManager.activeProfile.thumb_max;
        InitialAmps[4] = ProfileManager.activeProfile.open_max;

        string ProfileString = ProfileManager.activeProfile.userName.ToString();
        string FingerMinString = ProfileManager.activeProfile.finger_min.ToString();
        string FingerMaxString = ProfileManager.activeProfile.finger_max.ToString();
        string ThumbMinString = ProfileManager.activeProfile.thumb_min.ToString();
        string ThumbMaxString = ProfileManager.activeProfile.thumb_max.ToString();
        string OpenMaxString = ProfileManager.activeProfile.open_max.ToString();

        normal_finger_min = InitialAmps[0] / InitialAmps[1];
        normal_thumb_min = InitialAmps[2] / InitialAmps[3];
        fingerIncrementer = (1 - normal_finger_min) * 0.2f;// 20% of stim range
        thumbIncrementer = (1 - normal_thumb_min) * 0.2f;
        avgIncrementer = (fingerIncrementer + thumbIncrementer) / 2;
        normal_finger_bar = normal_finger_min;
        normal_thumb_bar = normal_thumb_min;

        // display ampltiude information to participant so they can set it on myndsearch
        Profile_AmplitudesOutput.text = "<u>" + ProfileString + "</u>\n\n" +
                                       "Finger Amp Min = " + FingerMinString + "\n" +
                                       "Finger Amp Max = " + FingerMaxString + "\n" +
                                       "Thumb Amp Min = " + ThumbMinString + "\n" +
                                       "Thumb Amp Max = " + ThumbMaxString + "\n" +
                                       "Open Amp Max = " + OpenMaxString + "\n" +
                                       "If ampltiude changed say \"New Amplitudes\"" + "\n" +
                                       "Otherwise, say \"Begin\" to start";
        Profile_AmplitudesOutput.color = new Color(255, 255, 255, 1f);
        ProfileAmplitudes.gameObject.SetActive(true);
        ProfileAmpState = true;
        // Profile_PromptOutput.text = "What is your participant ID?";
        //Profile_PromptOutput.color = new Color(255, 255, 255, 1f);



        byte[] data = new byte[InitialAmps.Length * 4];
        for (int i = 0; i < InitialAmps.Length; i++)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(InitialAmps[i]), 0, data, i * 4, 4);
        }

        if (SendToExternal == true)
        {
            udpClient.Send(data, data.Length, ExternalMachineIP, 55001); // sending to an external computer

        }
        else
        {
            udpClient.Send(data, data.Length, "127.0.0.1", 55001); // sending to the same computer
        }
    }

    void OnApplicationQuit()
    {
        // Directly send the -1f values to ensure the analog output is zeroed out
        float[] zeroValues = { -1f, -1f, -1f };
        SendArray(zeroValues);
        Debug.Log("Sent zero command on application quit.");
    }

    public void NumberZero() { TempString = "0"; BuildIPAddress(); SetNewAmplitudesFingerMinValues(); SetNewAmplitudesFingerMaxValues(); SetNewAmplitudesThumbMinValues(); SetNewAmplitudesThumbMaxValues(); SetNewAmplitudeOpenMaxValues(); }
    public void NumberOne() { TempString = "1"; BuildIPAddress(); SetNewAmplitudesFingerMinValues(); SetNewAmplitudesFingerMaxValues(); SetNewAmplitudesThumbMinValues(); SetNewAmplitudesThumbMaxValues(); SetNewAmplitudeOpenMaxValues();}
    public void NumberTwo() { TempString = "2"; BuildIPAddress(); SetNewAmplitudesFingerMinValues(); SetNewAmplitudesFingerMaxValues(); SetNewAmplitudesThumbMinValues(); SetNewAmplitudesThumbMaxValues(); SetNewAmplitudeOpenMaxValues();}
    public void NumberThree() { TempString = "3"; BuildIPAddress(); SetNewAmplitudesFingerMinValues(); SetNewAmplitudesFingerMaxValues(); SetNewAmplitudesThumbMinValues(); SetNewAmplitudesThumbMaxValues(); SetNewAmplitudeOpenMaxValues();}
    public void NumberFour() { TempString = "4"; BuildIPAddress(); SetNewAmplitudesFingerMinValues(); SetNewAmplitudesFingerMaxValues(); SetNewAmplitudesThumbMinValues(); SetNewAmplitudesThumbMaxValues(); SetNewAmplitudeOpenMaxValues();}
    public void NumberFive() { TempString = "5"; BuildIPAddress(); SetNewAmplitudesFingerMinValues(); SetNewAmplitudesFingerMaxValues(); SetNewAmplitudesThumbMinValues(); SetNewAmplitudesThumbMaxValues(); SetNewAmplitudeOpenMaxValues();}
    public void NumberSix() { TempString = "6"; BuildIPAddress(); SetNewAmplitudesFingerMinValues(); SetNewAmplitudesFingerMaxValues(); SetNewAmplitudesThumbMinValues(); SetNewAmplitudesThumbMaxValues(); SetNewAmplitudeOpenMaxValues();}
    public void NumberSeven() { TempString = "7"; BuildIPAddress(); SetNewAmplitudesFingerMinValues(); SetNewAmplitudesFingerMaxValues(); SetNewAmplitudesThumbMinValues(); SetNewAmplitudesThumbMaxValues(); SetNewAmplitudeOpenMaxValues();}
    public void NumberEight() { TempString = "8"; BuildIPAddress(); SetNewAmplitudesFingerMinValues(); SetNewAmplitudesFingerMaxValues(); SetNewAmplitudesThumbMinValues(); SetNewAmplitudesThumbMaxValues(); SetNewAmplitudeOpenMaxValues();}
    public void NumberNine() { TempString = "9"; BuildIPAddress(); SetNewAmplitudesFingerMinValues(); SetNewAmplitudesFingerMaxValues(); SetNewAmplitudesThumbMinValues(); SetNewAmplitudesThumbMaxValues(); SetNewAmplitudeOpenMaxValues();}
    public void NumberTen() { TempString = "10"; BuildIPAddress(); SetNewAmplitudesFingerMinValues(); SetNewAmplitudesFingerMaxValues(); SetNewAmplitudesThumbMinValues(); SetNewAmplitudesThumbMaxValues(); SetNewAmplitudeOpenMaxValues();}
    public void Dot() { TempString = "."; BuildIPAddress(); SetNewAmplitudesFingerMinValues(); SetNewAmplitudesFingerMaxValues(); SetNewAmplitudesThumbMinValues(); SetNewAmplitudesThumbMaxValues(); SetNewAmplitudeOpenMaxValues();}

    /// <summary>
    /// This section of the code is only used if the participant needs to change the stimulation amplitudes
    /// </summary>
    public void SetNewAmpltiudesFingerMinPrompt()
    {
        if (ProfileAmpState == true)
        {
            NewFingerMinState = false;
            NewFingerMaxState = false;
            NewThumbMinState = false;
            NewThumbMaxState = false;
            NewOpenState = false;

            // first screen when setting new amplitudes
            NewAmplitudesOutput.text = "What is the new Finger Min Amplitude? (e.g., 1.5)";
            NewAmplitudesOutput.color = new Color(255, 255, 255, 1f);
            NewAmplitudes.gameObject.SetActive(true);

            ProfileAmplitudes.gameObject.SetActive(false);
            AmpString = "";
            TempString = "";
        }


    }

    public void SetNewAmplitudesFingerMinValues()
    {
        if (NewFingerMinState == false)
        {
            AmpString = AmpString + TempString;
            NewAmplitudesOutput.text = "What is the new Finger MIN Amplitude? (e.g., 1.5)" + "\n" + "\n" +
                                        AmpString + "\n" + "\n" +
                                        "Say \"confirm\" to move on";
        }


    }

    public void Confirm_FingerMin()
    {
        // send to profile
        if (NewFingerMinState == false && AmpString != "")
        {
            ProfileManager.activeProfile.finger_min = float.Parse(AmpString);
            ProfileManager.Instance.SaveCurrentProfile();
            NewFingerMinState = true;
            ResetStrings();
            SetNewAmplitudesFingerMaxValues();
        }



    }

    public void ResetStrings()
    {
        AmpString = "";
        TempString = "";
    }

    public void SetNewAmplitudesFingerMaxValues()
    {

        if (NewFingerMaxState == false && NewFingerMinState == true)
        {
            //Debug.Log("here");
            AmpString = AmpString + TempString;
            NewAmplitudesOutput.text = "What is the new Finger MAX Amplitude? (e.g., 1.5)" + "\n" + "\n" +
                                        AmpString + "\n" + "\n" +
                                        "Say \"confirm\" to move on";
        }

    }

    public void Confirm_FingerMax()
    {
        // send to profile
        if (NewFingerMaxState == false && NewFingerMinState == true && AmpString != "")
        {
            //Debug.Log("here");
            ProfileManager.activeProfile.finger_max = float.Parse(AmpString);
            ProfileManager.Instance.SaveCurrentProfile();
            NewFingerMaxState = true;
            ResetStrings();
            SetNewAmplitudesThumbMinValues();

            // call new thumb screen etc etc.
        }

    }

    public void SetNewAmplitudesThumbMinValues()
    {
        if (NewFingerMaxState == true && NewThumbMinState == false)
        {
            AmpString = AmpString + TempString;
            NewAmplitudesOutput.text = "What is the new Thumb MIN Amplitude? (e.g., 1.5)" + "\n" + "\n" +
                            AmpString + "\n" + "\n" +
                            "Say \"confirm\" to move on";

        }
    }

    public void Confirm_ThumbMin()
    {
        if (NewThumbMinState == false && AmpString != "")
        {
            ProfileManager.activeProfile.thumb_min = float.Parse(AmpString);
            ProfileManager.Instance.SaveCurrentProfile();
            NewThumbMinState = true;
            ResetStrings();
            SetNewAmplitudesThumbMaxValues();
            
        }
    }

    public void SetNewAmplitudesThumbMaxValues()
    {
        if (NewThumbMinState == true && NewThumbMaxState == false)
        {
            AmpString = AmpString + TempString;
            NewAmplitudesOutput.text = "What is the new Thumb MAX Amplitude? (e.g., 1.5)" + "\n" + "\n" +
                            AmpString + "\n" + "\n" +
                            "Say \"confirm\" to move on";
        }
    }

    public void Confirm_ThumbMax()
    {
        if(NewThumbMinState == true && NewThumbMaxState == false && AmpString != "")
        {
            ProfileManager.activeProfile.thumb_max = float.Parse(AmpString);
            ProfileManager.Instance.SaveCurrentProfile();
            NewThumbMaxState = true;
            ResetStrings();
            SetNewAmplitudeOpenMaxValues();

        }
    }

    public void SetNewAmplitudeOpenMaxValues()
    {
        if(NewThumbMaxState == true && NewOpenState == false)
        {
            AmpString = AmpString + TempString;
            NewAmplitudesOutput.text = "What is the new Hand Opening MAX Amplitude? (e.g., 1.5)" + "\n" + "\n" +
                            AmpString + "\n" + "\n" +
                            "Say \"confirm\" to move on";
        }
    }

    public void Confirm_OpenMax()
    {
        if(NewThumbMaxState == true && NewOpenState == false &&  AmpString != "")
        {
            ProfileManager.activeProfile.open_max = float.Parse(AmpString);
            ProfileManager.Instance.SaveCurrentProfile();
            NewOpenState = true;
            ResetStrings();
            SendInitialStimAmps();
            //HandUsePrompt.HandUsePromptOn();
            NewAmplitudes.gameObject.SetActive(false);
        }
    }
}