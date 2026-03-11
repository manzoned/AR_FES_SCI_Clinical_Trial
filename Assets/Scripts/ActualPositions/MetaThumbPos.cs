using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaThumbPos : MonoBehaviour
{
    public HandTracking1 HandTracking;
    public Vector3 tempPosition;
    public PalmPos PalmPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PalmPos.testTrigger == 1)
        {
            tempPosition = HandTracking.metaThumbPos;
            transform.position = tempPosition;
            /*PalmPos.testTrigger = 0;*/
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Vector3 destroyPos = new Vector3(-10f, -10f, -10f);
            transform.position = destroyPos;
        }
    }
}
