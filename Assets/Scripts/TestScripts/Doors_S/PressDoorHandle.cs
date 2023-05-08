using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;

public class PressDoorHandle : MonoBehaviour
{

    public Animator door;
    // public GameObject lockOB;
    // public GameObject keyOB;

    // public GameObject lockedText;
    public Collider handleCollider;


    public AudioSource openSound;
    public AudioSource closeSound;
    public AudioSource lockedSound;
    public AudioSource unlockedSound;

    public bool doorisOpen;
    public bool doorisClosed;

    private void Start() 
    {
        doorisClosed = true;
        doorisOpen = false;
        
        door.SetBool("Open", false);
        door.SetBool("Closed", true);
        
    }



    public void DoorHandleMethod()
    {
        if (doorisClosed)
        {
            handleCollider.enabled = false;
            StartCoroutine(preventAnotherOpen());
            door.SetBool("Open", true);
            door.SetBool("Closed", false);

            doorisOpen = true;
            doorisClosed = false;
        }
        else if (doorisOpen)
        {
            handleCollider.enabled = false;
            StartCoroutine(preventAnotherOpen());
            door.SetBool("Open", false);
            door.SetBool("Closed", true);

            doorisClosed = true;
            doorisOpen = false;
        }

    }

    IEnumerator preventAnotherOpen()
    {
        yield return new WaitForSeconds(1.05f);
        {
            handleCollider.enabled = true;

            // unlocked = true;
            // lockOB.SetActive(false);
        }
    }
}
