using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject light;
    public bool toggle;
    public Animator switchAnim;


    public void LightOn()
    {
        AudioManager.instance.PlaySFX("LightSwitch");

        switchAnim.ResetTrigger("press");
        switchAnim.SetTrigger("press");

        light.SetActive(true);
        if(toggle == false)
        {
            Invoke("ToggleTime", 0.5f);
        }
    }
    public void ToggleTime()
    {
        toggle = true;
    }

    public void LightOff()
    {
       
        if (toggle == true)
        {
            light.SetActive(false);
            toggle = false;
        }
    }
    
}
