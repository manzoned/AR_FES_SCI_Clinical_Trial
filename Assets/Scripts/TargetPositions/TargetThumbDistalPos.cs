using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetThumbDistalPos : MonoBehaviour
{
    public HandTracking1 HandTracking;
    public Vector3 tempPosition;
    public TargetPalm TargetPalm;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            tempPosition = HandTracking.thumbDistalPos;
            /*transform.position = tempPosition;*/

        }

        if (TargetPalm.testTrigger == 1)
        {
            transform.position = tempPosition;
        }

        /*     if(Input.GetKeyDown(KeyCode.Alpha3))
                {
                    transform.position = tempPosition;
                }*/

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Vector3 destroyPos = new Vector3(-10f, -10f, -10f);
            transform.position = destroyPos;
        }
    }
}
