using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingPlaneLargeDiameter : MonoBehaviour
{
    public PostureController PostureController;

    public void BlockGuidance()
    {
        if (PostureController.guidanceStateLargeDiameter == 0)
        {
            gameObject.SetActive(false);
        }
        if (PostureController.guidanceStateLargeDiameter == 1)
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
