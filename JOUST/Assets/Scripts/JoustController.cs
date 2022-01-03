using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoustController : MonoBehaviour
{

    //two enemies collide
    //check direction (facing each other)
    //the higher one wins 
    //same repell each other

    //add joust point for transform
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Enemy")
        {
           if(transform.position.y > other.transform.position.y)
           {
               Debug.Log("win");
           }
           else if(transform.position.y < other.transform.position.y)
           {
                Debug.Log("lose");
           }
           else
             Debug.Log("tie");
        }
    }
}
