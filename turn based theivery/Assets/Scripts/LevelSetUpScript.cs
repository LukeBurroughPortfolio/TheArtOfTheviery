using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetUpScript : MonoBehaviour
{
    public int TotalPaintingsInLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MapGeneration>().BuildMap();
    }
}
