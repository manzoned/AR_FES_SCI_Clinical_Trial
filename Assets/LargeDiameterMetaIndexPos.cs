using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDiameterMetaIndexPos : MonoBehaviour
{
    public LargeDiameter LargeDiameter;
    public Vector3 tempPosition;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LargeDiameter.GraspState == 1 && LargeDiameter.targetParented == 0)
        {
            tempPosition = transform.position;
        }
        tempPosition = transform.position;
    }
}
