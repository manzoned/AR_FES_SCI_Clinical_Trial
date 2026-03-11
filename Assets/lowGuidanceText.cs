using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lowGuidanceText : MonoBehaviour
{
    public void lowGuidance()
    {
        gameObject.SetActive(true);
    }

    public void mediumGuidance()
    {
        gameObject.SetActive(false);
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
