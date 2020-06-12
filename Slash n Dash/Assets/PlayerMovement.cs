using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    
    public float RUN_SPEED = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Use Input to allow control 
        // horizontalMove = Input.GetAxisRaw("Horizontal")*RUN_SPEED;
        
        // set horizontal move to a constant for continuous running
        horizontalMove = RUN_SPEED; 
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("isJumping", true);
        }

        // Crouching mechanics not needed
        
        // if(Input.GetButtonDown("Crouch")){
        //     crouch = true;
        // } else if(Input.GetButtonUp("Crouch")){
        //     crouch = false;
        // }
    }

    public void onLanding(){
        animator.SetBool("isJumping", false);
    }

    // Called a fixed amount of time
    void FixedUpdate(){
        // Fixed Delta ensures the player moved the same speed regardless of how often called
        controller.Move(horizontalMove*Time.fixedDeltaTime, crouch ,jump);
        jump = false;
        
    }


}
