using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseJoint : MonoBehaviour
{
    public HandTracking1 HandTracking;
    public Vector3 tempPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tempPosition = HandTracking.wristPos;
            transform.position = tempPosition;
        }


    }
}
