using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public Vector3 CubePos;
    public Quaternion CubeRot;
    private Vector3 DiffPos;
    private Quaternion DiffRot;
    private Quaternion NewRot;

    public TargetCube TargetCube;
    // Start is called before the first frame update
    void Start()
    {
        CubePos = transform.position;
        CubeRot = transform.rotation;

        DiffPos = TargetCube.TargetCubePos - CubePos;
        DiffRot.x = TargetCube.TargetCubeRot.x - CubeRot.x;
        DiffRot.y = TargetCube.TargetCubeRot.y - CubeRot.y;
        DiffRot.z = TargetCube.TargetCubeRot.z - CubeRot.z;
        DiffRot.w = TargetCube.TargetCubeRot.w - CubeRot.w;
        NewRot.x = CubeRot.x + DiffRot.x;
        NewRot.y = CubeRot.y + DiffRot.y;
        NewRot.z = CubeRot.z + DiffRot.z;
        NewRot.w = CubeRot.w + DiffRot.w;


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            transform.position = CubePos + DiffPos;
            transform.rotation = NewRot;


        }
    }
}
