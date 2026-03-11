using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionStimBackPlate : MonoBehaviour
{
    public HandTracking1 HandTracking;
    public TargetPosturePanel TargetPosturePanel;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if(TargetPosturePanel.SolverHandler.AdditionalOffset.x > 0)
        {
            transform.localPosition = new Vector3(-0.1823f, 0.1023f, 0.195f);
        }
        else { transform.localPosition = new Vector3(0.1823f, 0.1023f, 0.195f); }
/*        if (HandTracking.HandUsed == 1)
        {
            transform.localPosition = new Vector3(0.1823f, 0.1023f, 0.195f);
        }
        else { transform.localPosition = new Vector3(-0.1823f, 0.1023f, 0.195f); }*/
    }
}
