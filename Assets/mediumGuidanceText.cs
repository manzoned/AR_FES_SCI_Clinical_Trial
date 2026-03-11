//using Mono.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mediumGuidanceText : MonoBehaviour
{
    public void lowGuidance()
    {
        gameObject.SetActive(false);
    }

    public void mediumGuidance()
    {
        gameObject.SetActive(true);
    }
    public void highGuidance()
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
