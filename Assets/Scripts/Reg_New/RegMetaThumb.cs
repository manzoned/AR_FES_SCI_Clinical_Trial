using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegMetaThumbPos : MonoBehaviour
{
    public HandTracking1 HandTracking;
    public Vector3 tempPosition;
    public MetaThumbPos MetaThumbPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //tempPosition = HandTracking.metaThumbPos;
            tempPosition = MetaThumbPos.tempPosition;
            transform.position = tempPosition;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Vector3 destroyPos = new Vector3(-10f, -10f, -10f);
            transform.position = destroyPos;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            transform.position = tempPosition;
        }
    }
}
