using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Article : MonoBehaviour
{
    
    public GameObject closedDoor;
    public GameObject brokenDoor;
    public GameObject player;

    private float distanceToClue;
    private bool touchedClue = false;


    private void Start() 
    {
        
        
    }

    private void OnMouseDown() 
    {
        
    

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        distanceToClue = Vector3.Distance(this.gameObject.transform.position, player.transform.position);


        if (distanceToClue < 2.5f && Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Article")
        {
            closedDoor.SetActive(false);
            brokenDoor.SetActive(true);
            touchedClue = true;


        }
        
    }



    
}
