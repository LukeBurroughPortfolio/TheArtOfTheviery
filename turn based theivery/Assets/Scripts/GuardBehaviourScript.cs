using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehaviourScript : MonoBehaviour
{
    //these are used to handle if it is the players turn or the guards turn
    public int TotalMoves;
    public int CurrentMovesTaken;

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

    void Start()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        PlayerRef = playerList[0];
        TotalMoves = 2;
        CurrentMovesTaken = TotalMoves;
        InvokeRepeating("Patrol", 0.1f, 0.4f);
    }

    void Update()
    {
        LookForPlayer();
    }

    public void ResetTurn()
    {
        CurrentMovesTaken = 0;
    }

    void Patrol()
    {
        if (CurrentMovesTaken != TotalMoves)
        {
            CurrentMovesTaken++;
            TopBool = TopCol.GetComponent<GuardFeelerScript>().HitSomething;
            BotBool = BotCol.GetComponent<GuardFeelerScript>().HitSomething;
            RightBool = RightCol.GetComponent<GuardFeelerScript>().HitSomething;
            LeftBool = LeftCol.GetComponent<GuardFeelerScript>().HitSomething;
            MoveNumber = Random.Range(1, 5);
            if (MoveNumber == 1 && RightBool == false)
            {
                //move one square to the right
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0.6f, 0, 0);
            }

            else if (MoveNumber == 2 && BotBool == false)
            {
                //move one square down
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0, -0.6f, 0);
            }

            else if (MoveNumber == 3 && LeftBool == false)
            {
                //move one square to the left
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(-0.6f, 0, 0);
            }

            else if (MoveNumber == 4 && TopBool == false)
            {
                 //move one square up
                 transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0, 0.6f, 0);
            }
        }

        else
        {
            PlayerRef.GetComponent<PlayerBehaviourScript>().ResetTurn();
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
            TotalMoves = 5;
            Debug.DrawRay(transform.position, playerDirection, Color.red);
        }
        else if (HasSeenPlayer == true && hit.collider.name != "PLAYER")
        {
            CurrentlySeePlayer = false;
        }
    }
}
