using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegLargeDiameterPalmPos : MonoBehaviour
{
    public LargeDiameter LargeDiameter;
    public Vector3 tempPositon;
    public Quaternion tempRotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LargeDiameter.GraspState == 1)
        {
            tempPositon = transform.position;
            tempRotation = transform.rotation;
        }

    }
}
