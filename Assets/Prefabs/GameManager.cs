using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float oldTime = 0.0F;
    float theDeltaTime = 0.0F;
    float curTime = 0.0F;
    float timeTaken = 0.0F;
    public int frameRate = 60;
    public float playerHealth;

    public static GameManager manager;
  //  public PlayerHealth health;
    private void Awake()
    {
        //luodaan manageri ja tsekataan onko sit� jo olemassa
        if (manager == null)
        {
            //jos ei ole manegeria kerrotaan,ett� t�m� luokka on manageri.
            //kerrotaan, ett� t�m� manageri ei saa tuhoutua
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        
        theDeltaTime = (1.0F / frameRate);
        oldTime = Time.realtimeSinceStartup;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        curTime = Time.realtimeSinceStartup;
        timeTaken = (curTime - oldTime);
        if (timeTaken < theDeltaTime)
        {
            Thread.Sleep((int)(1000 * (theDeltaTime - timeTaken)));
        }


        oldTime = Time.realtimeSinceStartup;

        //playerHealth = health.health;
      //  Debug.Log(playerHealth);
    }

}

