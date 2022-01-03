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
    public float JumpCoolDown = 0.3f;

    //ground checks

    Vector2 vel;
    bool canJump = true;
    float currentJumpCoolDown;


    void FixedUpdate()
    {
        canJump = checkJump();

        if(input.jumpPressed && canJump)
        {
            vel.y = JumpForce;
            currentJumpCoolDown = JumpCoolDown;
        }
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
   

    bool checkJump()
    {
        if(currentJumpCoolDown < 0)
            return true;
        
        currentJumpCoolDown -= Time.fixedDeltaTime;
        return false;
    }

    IEnumerable CoolDown(float time) {
        yield return new WaitForSeconds(time);
    }
}
