using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingPlaneLateral : MonoBehaviour
{
    public PostureController PostureController;
    // write some code so that this appears if it is a no guidance trial
    // call a function everytime but whether is active or not will depend on the feedback state
    // if guidance state == 0 then setactive(true), if guidance state == 1 then setactive(false)

    // this works but need to program how to toggle the guidance state!
    public void BlockGuidance()
    {
        if(PostureController.guidanceStateLateral == 0)
        {
            gameObject.SetActive(false);
        }
        if(PostureController.guidanceStateLateral == 1)
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
