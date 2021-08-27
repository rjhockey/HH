using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller; //in Unity drag the CharacterController script into this slot

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        //Gets player input as -1 or 1 ie a or left arrow is -
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) //Jump = spacebar as spec by Input Manager
        {
            jump = true; // pass this into FixedUpdate controller.Move...below
        }
        //will only work if you animate this action
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true; // pass this into FixedUpdate controller.Move...below
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    //Updates mult. times per frame
    private void FixedUpdate()
    {
        //Moves player...direction, crouching, jumping
        //Time.fix... is amount of time elapsed since last time function was called
        //creates consistent speed on all platforms regardless of #times called
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        //reset to prevent neverending jump
        jump = false;
    }
}
