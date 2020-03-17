using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is attached to the feelers on the player to see if they can still move
public class PlayerColliderScript : MonoBehaviour
{
    public bool HitSomething = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        HitSomething = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        HitSomething = false;
    }
}
