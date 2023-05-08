using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    public bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public bool lerpCrouch;
    public float crouchTimer;
    public bool crouching;
    public bool sprinting;
    public float sprintTimer;
    public Animator animator;
    // Start is called before the first frame update
    public PlayerHealth playerHealth;
    



    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if(lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
            {
             controller.height = Mathf.Lerp(controller.height, 1, p);
                speed = 3f;
            }
            else
            {

                controller.height = Mathf.Lerp(controller.height, 2, p);
                speed = 5f;
            }
            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0;
            }
            
        }
        if (playerHealth.playerDead == true)
        {
            Debug.Log("NYT KUOLTIIN");
            animator.SetBool("isDead", true);
            
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && crouching == false) 
        {
            speed = 8f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && crouching == false)
        {
            speed = 5f;
        }

    }

    // receive the input from the InputManager
    public void ProcessMove(Vector2 input)
    {

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
        
    }

    //public void Jump()
    //{
    //    if (isGrounded)
    //    {
    //        playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    //    }

    //}
    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    //public void Sprint()
    //{

    //    sprinting = !sprinting;

    //    if(sprinting)
    //    {
    //        speed = 8;

    //    }
  
    //    else
    //    {
    //        speed = 5;
    //    }
     
    //}

}

