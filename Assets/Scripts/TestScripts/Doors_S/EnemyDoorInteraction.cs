// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;

// public class EnemyDoorInteraction : MonoBehaviour
// {
//     public Animator door;
//     public Collider handleCollider;
//     public Collider doorsEnemyTrigger;


//     public AudioSource openSound;
//     public AudioSource closeSound;
//     // public AudioSource lockedSound;
//     // public AudioSource unlockedSound;
//     // public PressDoorHandle pressdoorhandle;




//     private void OnTriggerEnter(Collider other) 
//     {
//         if (other.gameObject.CompareTag("Enemy"))
//         {
//             // pressdoorhandle = GetComponent<PressDoorHandle>();
//             if (PressDoorHandle.doorisClosed && handleCollider.enabled)
//             {
//                 handleCollider.enabled = false;
//                 doorsEnemyTrigger.enabled = false;
//                 StartCoroutine(preventAnotherOpen());
//                 door.SetBool("Open", true);
//                 door.SetBool("Closed", false);
//                 openSound.Play();
//                 // AudioManager.instance.PlaySFX("DoorOpen");

//                 PressDoorHandle.doorisOpen = true;
//                 PressDoorHandle.doorisClosed = false;
//             }
//         }
//     }

//     // private void OnTriggerExit(Collider other) 
//     // {
//     //     if (other.gameObject.CompareTag("Enemy"))
//     //     {
//     //         if (PressDoorHandle.doorisOpen)
//     //         {
//     //             handleCollider.enabled = false;
//     //             // doorsEnemyTrigger.enabled = false;
//     //             StartCoroutine(preventAnotherOpen());
//     //             door.SetBool("Open", false);
//     //             door.SetBool("Closed", true);
//     //             closeSound.Play();
//     //             // AudioManager.instance.PlaySFX("DoorClose");

//     //             PressDoorHandle.doorisClosed = true;
//     //             PressDoorHandle.doorisOpen = false;
//     //         }
//     //     }
//     // }

//     IEnumerator preventAnotherOpen()
//     {
//         yield return new WaitForSeconds(1.05f);
//         {
//             handleCollider.enabled = true;
//             doorsEnemyTrigger.enabled = true;

//             // unlocked = true;
//             // lockOB.SetActive(false);
//         }
//     }
// }