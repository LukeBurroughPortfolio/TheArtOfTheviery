using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public int ArtStolen = 0;

    //these are used to handle if it is the players turn or the guards turn
    public int TotalMoves = 3;
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
        InvokeRepeating("Move", 0.1f, 0.1f);
    }

    public void AddArtToStolen()
    {
        ArtStolen++;
    }

    public void ResetTurnCounter()
    {
        Debug.Log("player");
        if (CurrentMovesTaken == TotalMoves)
        {
            CurrentMovesTaken = 0;
        }
    }
    
    void Move()
    {
        if (CurrentMovesTaken != TotalMoves) {
            //this pings the PlayerColliderScripts every time the player moves to update if there are any walls beside the player
            TopColBool = TopCol.GetComponent<PlayerColliderScript>().HitSomething;
            BotColBool = BotCol.GetComponent<PlayerColliderScript>().HitSomething;
            LeftColBool = LeftCol.GetComponent<PlayerColliderScript>().HitSomething;
            RightColBool = RightCol.GetComponent<PlayerColliderScript>().HitSomething;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                // checks to see if there is space for the player to move
                if (RightColBool == false)
                {
                    //move one square to the right
                    transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0.6f, 0, 0);
                    //Debug.Log("right");
                }
                CurrentMovesTaken++;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                // checks to see if there is space for the player to move
                if (BotColBool == false)
                {
                    //move one square down
                    transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0, -0.6f, 0);
                    //Debug.Log("down");
                }
                CurrentMovesTaken++;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                // checks to see if there is space for the player to move
                if (LeftColBool == false)
                {
                    //move one square to the left
                    transform.position = gameObject.GetComponent<Transform>().position + new Vector3(-0.6f, 0, 0);
                    //Debug.Log("left");
                }
                CurrentMovesTaken++;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                // checks to see if there is space for the player to move
                if (TopColBool == false)
                {
                    //move one square up
                    transform.position = gameObject.GetComponent<Transform>().position + new Vector3(0, 0.6f, 0);
                    //Debug.Log("Up");
                }
                CurrentMovesTaken++;
            }
        }
    }
}

