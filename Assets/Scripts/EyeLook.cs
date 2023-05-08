using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLook : MonoBehaviour
{

    public Transform eyeLookAt = null;
    public float eyeRotateSPeed = 20f;

    public Renderer eyeBlinck;
    public float blinkEyeTime;

     void Start()
    {
        eyeBlinck = GetComponent<Renderer>();
    }


    // Update is called once per frame
    void Update()
    {
        BlinkEye();

        Quaternion rotTarget = Quaternion.LookRotation(eyeLookAt.position - this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, eyeRotateSPeed * Time.deltaTime);
    }

    void BlinkEye()
    {
       
        blinkEyeTime += Time.deltaTime;

        
        if(blinkEyeTime >= 3)
        {
        eyeBlinck.material.SetColor("_Color", Color.black);
        }
        else
        {
            eyeBlinck.material.SetColor("_Color", Color.white);
        }
        if(blinkEyeTime > 3.05)
        {
            blinkEyeTime = 0;
        }
    }
}
