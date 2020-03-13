using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D BoxCollision)
    {
        if (BoxCollision.gameObject.name == "PLAYER")
        {
            BoxCollision.gameObject.GetComponent<PlayerBehaviourScript>().AddArtToStolen();
            Destroy(gameObject);
        }
    }
}
