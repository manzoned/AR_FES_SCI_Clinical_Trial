using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingPlaneTherapist : MonoBehaviour
{
    public PostureController PostureController;

    public void BlockGuidance()
    {
        if (PostureController.guidanceStateTherapist == 0)
        {
            gameObject.SetActive(false);
        }
        if (PostureController.guidanceStateTherapist == 1)
        {
            gameObject.SetActive(true);
        }
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
