using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public int ArtStolen = 0;

    public GameObject GuardRef;

    bool MyTurn = true;

    Vector3 playerloc;
    //these are used to handle if it is the players turn or the guards turn
    public int TotalMoves;
    public int CurrentMovesTaken = 0;

    //refrences to all the feelers on the player to check if there is a wall in that direction
    public GameObject TopCol;
    public GameObject BotCol;
    public GameObject LeftCol;
    public GameObject RightCol;

    //this tells us if anyof the feelers are colliding with anything FASLE = not colliding
    public bool TopColBool = false;
    public bool BotColBool = false;
    public bool LeftColBool = false;
    public bool RightColBool = false;

    //this starts the repeting method that allows movement
    void Start()
    {
        playerloc = gameObject.GetComponent<Transform>().position;
        TotalMoves = 3;
        CurrentMovesTaken = 0;
    }

    void FixedUpdate()
    {
        Debug.Log(CurrentMovesTaken);
        // once the player has made all there moves it then resets the guards turn
        if (CurrentMovesTaken == TotalMoves)
        {
            MyTurn = false;
            Debug.Log("Guards turn");
            GuardRef.GetComponent<GuardBehaviourScript>().ResetTurn();
        }
        if (playerloc != gameObject.GetComponent<Transform>().position)
        {
            CurrentMovesTaken++;
            playerloc = gameObject.GetComponent<Transform>().position;
        }
        if (MyTurn == true)
        {
            //this pings the PlayerColliderScripts every time the player moves to update if there are any walls beside the player
            TopColBool = TopCol.GetComponent<PlayerColliderScript>().HitSomething;
            BotColBool = BotCol.GetComponent<PlayerColliderScript>().HitSomething;
            LeftColBool = LeftCol.GetComponent<PlayerColliderScript>().HitSomething;
            RightColBool = RightCol.GetComponent<PlayerColliderScript>().HitSomething;

            if (Input.GetKey(KeyCode.RightArrow) && RightColBool == false)
            {
                //move one square to the right
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0.6f, 0, 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow) && BotColBool == false)
            {
                //move one square down
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0, -0.6f, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && LeftColBool == false)
            {
                //move one square to the left
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(-0.6f, 0, 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow) && TopColBool == false)
            {
                //move one square up
                transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0, 0.6f, 0);
            }
        }
    }

    public void AddArtToStolen()
    {
        ArtStolen++;
    }
    
    public void ResetTurn()
    {
        CurrentMovesTaken = 0;
    }

    void Move()
    {
        
    }
}

