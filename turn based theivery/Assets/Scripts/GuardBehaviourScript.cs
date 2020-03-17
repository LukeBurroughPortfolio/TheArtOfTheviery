using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehaviourScript : MonoBehaviour
{
    //these are used to handle if it is the players turn or the guards turn
    public int TotalMoves = 30;
    public int CurrentMovesTaken = 0;

    //this will hold the current location of the player
    Vector2 PlayerLocation;
    //this will hold a refrence to the player
    GameObject PlayerRef;
    //list to hold the player refrence when we find it with findwithtag
    GameObject[] playerList;

    //bools for if the player has been found
    bool HasSeenPlayer = false;
    bool CurrentlySeePlayer = false;

    //this will hold a random number between 1 - 4
    int MoveNumber;

    //public refrence to the guards feelers
    public GameObject TopCol;
    public GameObject BotCol;
    public GameObject RightCol;
    public GameObject LeftCol;

    bool TopBool = false;
    bool BotBool = false;
    bool RightBool = false;
    bool LeftBool = false;

    public void ResetGuardTurn()
    {
        Debug.Log("Guard moves taken = " + CurrentMovesTaken);
    }

    void Start()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        PlayerRef = playerList[0];
        InvokeRepeating("Patrol", 0.1f, 0.4f);
    }

    void Update()
    {
        LookForPlayer();
        TopBool = TopCol.GetComponent<GuardFeelerScript>().HitSomething;
        BotBool = BotCol.GetComponent<GuardFeelerScript>().HitSomething;
        RightBool = RightCol.GetComponent<GuardFeelerScript>().HitSomething;
        LeftBool = LeftCol.GetComponent<GuardFeelerScript>().HitSomething;
    }

    void Patrol()
    {
        MoveNumber = Random.Range(1, 5);
        if (MoveNumber == 1)
        {
            // checks to see if there is space for the player to move
            if (RightBool == false)
            {
                //move one square to the right
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0.6f, 0, 0);
            }
            else if (RightBool == true && LeftBool == false)
            {
                //move one square to the left
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(-0.6f, 0, 0);
            }
            else if (RightBool == true && TopBool == false)
            {
                //move one square up
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0, 0.6f, 0);
            }
            else if (RightBool == true && BotBool == false)
            {
                //move one square down
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0, -0.6f, 0);
            }
        }

        else if (MoveNumber == 2)
        {
            // checks to see if there is space for the player to move
            if (BotBool == false)
            {
                //move one square down
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0, -0.6f, 0);
            }
            else if (BotBool == true && TopBool == false)
            {
                //move one square up
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0, 0.6f, 0);
            }
            else if (BotBool == true && LeftBool == false)
            {
                //move one square to the left
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(-0.6f, 0, 0);
            }
            else if (BotBool == true && RightBool == false)
            {
                //move one square to the right
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0.6f, 0, 0);
            }
        }

        else if (MoveNumber == 3)
        {
            // checks to see if there is space for the player to move
            if (LeftBool == false)
            {
                //move one square to the left
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(-0.6f, 0, 0);
            }
            else if (LeftBool == true && RightBool == false)
            {
                //move one square to the right
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0.6f, 0, 0);
            }
            else if (LeftBool == true && TopBool == false)
            {
                //move one square up
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0, 0.6f, 0);
            }
            else if (LeftBool == true && BotBool == false)
            {
                //move one square down
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0, -0.6f, 0);
            }
        }

        else if (MoveNumber == 4)
        {
            // checks to see if there is space for the player to move
            if (TopBool == false)
            {
                //move one square up
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0, 0.6f, 0);
            }
            else if (TopBool == true && BotBool == false)
            {
                //move one square to the right
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0.6f, 0, 0);
            }
            else if (TopBool == true && RightBool == false)
            {
                //move one square to the right
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0.6f, 0, 0);
            }
            else if (TopBool == true && LeftBool == false)
            {
                //move one square to the left
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(-0.6f, 0, 0);
            }
        }
    }

    void LookForPlayer()
    {
        Vector3 playerDirection = (PlayerRef.GetComponent<Transform>().position - transform.position);//.normalized);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDirection);

        if (hit.collider.name == "PLAYER")
        {
            bool HasSeenPlayer = true;
            bool CurrentlySeePlayer = true;
            Debug.DrawRay(transform.position, playerDirection, Color.red);
        }
        else if (HasSeenPlayer == true && hit.collider.name != "PLAYER")
        {
            CurrentlySeePlayer = false;
        }
    }
}
