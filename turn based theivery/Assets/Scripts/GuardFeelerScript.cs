using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardFeelerScript : MonoBehaviour
{
    public bool HitSomething = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        HitSomething = true;
    }

    void OnTrigger2D(Collider2D coll)
    {
        HitSomething = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        HitSomething = false;
    }
}
