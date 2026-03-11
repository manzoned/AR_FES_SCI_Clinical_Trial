using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StimVisualPanel : MonoBehaviour
{
    public StimVisualPanel stimVisualPanel;
    public HandTracking1 HandTracking;
    public SolverHandler SolverHandler;
    public TargetPosturePanel TargetPosturePanel;
    //public MainCamera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ScreenOn()
    {
        //gameObject.SetActive(true);
        if(TargetPosturePanel.ScreenIsOn == 1)
        {
            if(HandTracking.HandUsed == 1)
            {
                SolverHandler.AdditionalOffset = new Vector3(0.3f, -0.05f, 0f);

            }
            else
            {
                SolverHandler.AdditionalOffset = new Vector3(-0.3f, -0.05f, 0f);
            }
        }

    }

    public void ScreenOff()
    { gameObject.SetActive(false); }

    // Update is called once per frame
    void Update()
    {
        
    }
}
