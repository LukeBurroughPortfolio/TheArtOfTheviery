using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSpawnScript : MonoBehaviour
{
    public GameObject Guard;
    Vector3 GuardLocation;
    int GuardSpawnChance;
    GameObject[] ManagerList;
    GameObject ManagerRef;

    void Start()
    {
        SpawnGuard();
    }

    void SpawnGuard()
    {
        GuardSpawnChance = Random.Range(1, 100);
        GuardLocation = transform.position;
        if (GuardSpawnChance <= 30)
        {
            Instantiate(Guard, GuardLocation, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
