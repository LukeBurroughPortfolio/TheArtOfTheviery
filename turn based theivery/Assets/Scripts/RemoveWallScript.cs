using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWallScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        //makes sure that the object colling with the wall is not the player or any of there feelers and only destroys on contact with other walls
        if(coll.name != "PLAYER" && coll.name != "TopCollider" && coll.name != "BottomCollider" && coll.name != "LeftCollider" && coll.name != "RightCollider" && coll.name != "Guard01(Clone)")
        {
            Destroy(gameObject);
        } 
    }
}
