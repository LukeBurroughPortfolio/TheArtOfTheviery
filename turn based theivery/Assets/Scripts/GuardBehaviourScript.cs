using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GuardBehaviourScript : MonoBehaviour
{
    public Vector2 PlayerLocation;
    GameObject PlayerRef;
    GameObject[] playerList;

    void Update()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        PlayerRef = playerList[0];
        PlayerLocation = PlayerRef.GetComponent<Transform>().position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, PlayerLocation);

        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, PlayerLocation, Color.red);
            
        }
    }
}
