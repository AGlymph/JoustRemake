using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputHandler input;
    public Rigidbody2D rb;
    public float moveSpeed = 10;
    public float acceleration = 5;
    public float JumpForce = 10;
    //ground checks

    Vector2 vel;


    void FixedUpdate()
    {
        if(input.jumpedThisFrame)
            vel.y = JumpForce;
        else
           vel.y = rb.velocity.y;
        
        switch(input.moveValue)
        {
            case 1:
                if(vel.x < moveSpeed)
                    vel.x+=acceleration*Time.fixedDeltaTime;
                break;
            case -1:
                if(vel.x > -moveSpeed)
                    vel.x-=acceleration*Time.fixedDeltaTime;
                break;
            default:
                if(vel.x >= 0.01f)
                    vel.x-=acceleration*Time.fixedDeltaTime;
                else if (vel.x <= -0.01f)
                    vel.x+=acceleration*Time.fixedDeltaTime;
                else
                    vel.x = 0.0f;
                break;
        }
        rb.velocity = vel;
    }
   

}
