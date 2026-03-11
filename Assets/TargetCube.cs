using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TargetCube : MonoBehaviour
{

    public Vector3 TargetCubePos;
    public Quaternion TargetCubeRot;

    // Start is called before the first frame update
    void Start()
    {
        TargetCubePos = transform.position;
        TargetCubeRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
