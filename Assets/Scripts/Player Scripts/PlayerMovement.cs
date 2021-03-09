using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController character_controller;

    private Vector3 move_direction;

    public float speed = 5f;
    private float gravity = 20f;

    public float jump_force = 10f;
    private float vertical_veloctiy;


    private void Awake()
    {
        character_controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
    }


    //Enable player movement function
    void MoveThePlayer()
    {
        //This makes the player move along the axis, used with the AWSD keys or the arrows
        //Axis.HORIZONTAL and Axis.VERTICAL are custom creations that can be found in the TagHolder Script
        move_direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));

        /* Learning Note
         * Local space is relative to the postion of the player 
         * World space is relative to everything Unity is displaying that is not the player
         * This function transforms between the two
         */
        move_direction = transform.TransformDirection(move_direction);
        // Time.deltaTime is the difference between two frames. Helps to smooth out the movement and differences between computers
        move_direction *= speed * Time.deltaTime;

        ApplyGravity();

        //This is the built in Move function that the Unity team developed. Takes a Vector 3 variable to determine how the object will travel through space
        character_controller.Move(move_direction);

    }//Move player

    //Apply gravity to the player 
    void ApplyGravity()
    {
     
        vertical_veloctiy -= gravity * Time.deltaTime;

        //jump 
        PlayerJump();

        move_direction.y = vertical_veloctiy * Time.deltaTime;
        
    }//Apply gravity 

    void PlayerJump()
    {
        //Jump when pressing space bar 
        //GetKeyDown detects a keystroke down. The up version detects when the key comes back up
        //Down is typically better to use
        if (character_controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            vertical_veloctiy = jump_force;
        }
    }//Player Jump

} //Class 
