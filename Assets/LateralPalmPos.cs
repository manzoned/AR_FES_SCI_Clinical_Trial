using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralPalmPos : MonoBehaviour
{
    public Lateral Lateral;
    public Vector3 tempPosition;
    public Quaternion tempRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*        if (Lateral.GraspState == 1)
                {
                    tempPosition = transform.position;
                }*/
        if (Lateral.GraspState == 1 && Lateral.targetParented == 0)
        {
            tempPosition = transform.position;
        }
    }
}
