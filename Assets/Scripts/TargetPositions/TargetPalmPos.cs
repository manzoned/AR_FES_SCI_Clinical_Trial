using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPalm : MonoBehaviour
{
    public HandTracking1 HandTracking;
    public Vector3 tempPosition;
    public Quaternion tempRotation;

    Vector3 regAngle;
    public int testTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            tempPosition = HandTracking.palmPos;
            tempRotation = HandTracking.palmRot;
            /*            transform.position = tempPosition;
            */
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.position = tempPosition;
            transform.rotation = tempRotation;

            testTrigger = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Vector3 destroyPos = new Vector3(-10f, -10f, -10f);
            transform.position = destroyPos;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
           
            Vector3 regTarPos = new Vector3(tempPosition.x, tempPosition.y + 0.2f, tempPosition.z);
            transform.position = regTarPos;
            regAngle = new Vector3(-60f, -60f, 10f);
            Quaternion regTarRot = new Quaternion(0f, 0f, 0f, 0);
            regTarRot.eulerAngles = regAngle;
            transform.rotation = regTarRot;

            /*Quaternion regTarRot = new Quaternion(tempRotation.x, )*/
        }
    }
}
