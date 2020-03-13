using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingSpawnScript : MonoBehaviour
{
    //refrence to LevelSetupScript
    public GameObject SetUpScript;
    //generates a random number to decide if some art spawns
    int ArtSpawnChance;
    int SpawnNumber;
    GameObject ArtToSpawn;
    Vector3 ArtLocation;

    //list of paintings
    List<GameObject> ArtGallery = new List<GameObject>();

    public GameObject Painting01;
    public GameObject Painting02;
    public GameObject Painting03;
    public GameObject Painting04;
    public GameObject Painting05;
    public GameObject Painting06;
    public GameObject Painting07;
    public GameObject Painting08;
    public GameObject Painting09;
    public GameObject Painting10;

    //this runs when the script is started
    void Start()
    {
        ArtSpawnChance = Random.Range(1,100);
        ArtLocation = transform.position;
        ArtList();
        PickArt();
        if (ArtSpawnChance <= 50)
        {
            Instantiate(ArtToSpawn, ArtLocation, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    //picks a random peice of art from the artgalleryLIst
    void PickArt()
    {
        SpawnNumber = Random.Range(0, ArtGallery.Count);
        ArtToSpawn = ArtGallery[SpawnNumber];
    }

    //fill the artgallery list with all my art prefab refrences
    void ArtList()
    {
        ArtGallery.Add(Painting01);
        ArtGallery.Add(Painting02);
        ArtGallery.Add(Painting03);
        ArtGallery.Add(Painting04);
        ArtGallery.Add(Painting05);
        ArtGallery.Add(Painting06);
        ArtGallery.Add(Painting07);
        ArtGallery.Add(Painting08);
        ArtGallery.Add(Painting09);
        ArtGallery.Add(Painting10);
    }
}
