using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManagementScript : MonoBehaviour
{

    //refrences to the guards and player
    public GameObject playerRef;
    public GameObject GuardRef;

    // Update is called once per frame
    void Update()
    {
        GuardRef.GetComponent<GuardBehaviourScript>().ResetGuardTurn();
        
        playerRef.GetComponent<PlayerBehaviourScript>().ResetTurnCounter();
    }
}
