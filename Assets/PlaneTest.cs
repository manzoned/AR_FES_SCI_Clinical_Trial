using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTest : MonoBehaviour
{
    public HandTracking1 HandTracking1;
    public ForearmPos ForearmPos;
    public Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newPos.x = (HandTracking1.wristPos.x + ForearmPos.forearmPos.x) / 2;
        newPos.y = (HandTracking1.wristPos.y + ForearmPos.forearmPos.z) / 2;
        newPos.z = (HandTracking1.wristPos.z + ForearmPos.forearmPos.z) / 2;

        gameObject.transform.position = newPos;
        gameObject.transform.rotation = ForearmPos.transform.rotation;

    }
}
