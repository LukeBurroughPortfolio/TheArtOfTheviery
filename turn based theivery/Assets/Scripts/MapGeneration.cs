using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    //info to be transfered
    public int LevelNum = 1;
    public int BaseRoomCount = 5;
    int TotalTiles;
    

    //keeps track of the place to spawn the next tile
    Vector3 TileLocation = new Vector3(0, 0, 0);

    //directions + what axis to effect when laying down tiles
    bool YAxis = true; //TRUE is moveing on the y axis and FASLE is moveing on the x
    int PosOrNeg; // this handles if it is -6 or 6 when moveing a tile 
    Quaternion Rotation = new Quaternion(0,0,90,0);// this handles the rotation of tiles
    int RandomRotation;

    //lists for the tiles
    List<GameObject> BaseTileList = new List<GameObject>();
    List<GameObject> CurrentFloorTiles = new List<GameObject>();
    List<Vector3> LocationOfTiles = new List<Vector3>();

    //public variable refrences
    public GameObject StartTile;
    public GameObject TileRef01;
    public GameObject TileRef02;
    public GameObject TileRef03;
    public GameObject TileRef04;
    public GameObject TileRef05;
    public GameObject TileRef06;
    public GameObject TileRef07;
    public GameObject TileRef08;
    public GameObject EndTile;
    
    // this builds a map with tiles equal to Levelnum + baseroomcount and then randomly selects a tile from the baseTileList
    public void BuildMap()
    {
        TotalTiles = BaseRoomCount + LevelNum;
        //runs the filltilebank method to put all the current usable tiles into a list
        FillTileBank();
        int Counter = 0;
        //what number in the list to pull from
        int TileNum;
        GameObject SelectedTile;

        while (Counter < TotalTiles)
        {
            //this generates a random number that fits the length of my useable tile list so that i can grab a random tile
            TileNum = Random.Range(0, 8);
            SelectedTile = BaseTileList[TileNum];
            RandomRotation = Random.Range(1, 4);

            //this assigns a rotation to rotation
            if (RandomRotation == 1)
            {
                Rotation = new Quaternion(0, 0, 0, 0); 
            }
            else if (RandomRotation == 2)
            {
                Rotation = new Quaternion(0, 0, 90, 0);
            }
            else if (RandomRotation == 3)
            {
                Rotation = new Quaternion(0, 0, 180, 0);
            }
            else if (RandomRotation == 4)
            {
                Rotation = new Quaternion(0, 0, 270, 0);
            }

            // if the current tile being put down is the first tile it will always be start tile
            if (Counter == 0)
            {
                Instantiate(StartTile, new Vector3(0, 0, 0), Quaternion.identity);
                //this adds the start tile to our currentfloortile list
                CurrentFloorTiles.Add(StartTile);
                LocationOfTiles.Add(TileLocation);
            }
            else if (Counter != TotalTiles - 1)
            {
                CalculateNewTilePlace();
                Instantiate(SelectedTile, TileLocation, Rotation);
                //this adds the currenty selected tile to our currentfloortile list
                CurrentFloorTiles.Add(SelectedTile);
                LocationOfTiles.Add(TileLocation);
            }
            else
            {
                CalculateNewTilePlace();
                Instantiate(EndTile, TileLocation, Quaternion.identity);
                //this adds the end tile to our currentfloortile list
                CurrentFloorTiles.Add(EndTile);
                LocationOfTiles.Add(TileLocation);
            }
            Counter++;
        }
        //reset all the list in preperation of the next level
        BaseTileList = new List<GameObject>();
        CurrentFloorTiles = new List<GameObject>();
        LocationOfTiles = new List<Vector3>();
    }

    // fills the basetileList with all the tile prefabs that are usable
    void FillTileBank()
    {
        BaseTileList.Add(TileRef01);
        BaseTileList.Add(TileRef02);
        BaseTileList.Add(TileRef03);
        BaseTileList.Add(TileRef04);
        BaseTileList.Add(TileRef05);
        BaseTileList.Add(TileRef06);
        BaseTileList.Add(TileRef07);
        BaseTileList.Add(TileRef08);
        //Debug.Log(BaseTileList.Count); // this tells me how many unique tiles there are
    }

    public void CalculateNewTilePlace()
    {
        PosOrNeg = Random.Range(1, 20);
        //figure out if we are changeing the y axis or the x axis
        if (YAxis == true)// moveing on the Y axis
        {
            YAxis = false;
            if (PosOrNeg <= 10)// moving up the Y axis
            {
                Vector3 TempLocation = TileLocation + new Vector3(0, 6, 0);
                Vector3 TempLocation2 = TileLocation + new Vector3(0, -6, 0);
                Vector3 TempLocation3 = TileLocation + new Vector3(6, 0, 0);
                Vector3 TempLocation4 = TileLocation + new Vector3(-6, 0, 0);
                if (LocationOfTiles.Contains(TempLocation) == false) //this checks to see if the these coordanites exist already
                {
                    TileLocation = TileLocation + new Vector3(0, 6, 0); //places the next tile above the previous
                }
                else if (LocationOfTiles.Contains(TempLocation2) == false)
                {
                    TileLocation = TileLocation + new Vector3(0, -6, 0); //places the next tile below the previous
                }
                else if (LocationOfTiles.Contains(TempLocation3) == false)
                {
                    TileLocation = TileLocation + new Vector3(6, 0, 0);//places the next tile to the right of the previous
                }
                else if (LocationOfTiles.Contains(TempLocation4) == false)
                {
                    TileLocation = TileLocation + new Vector3(-6, 0, 0);//places the next tile to the left of the previous
                }
                else
                {
                    TileLocation = TileLocation + new Vector3(-12, 0, 0);//places the next tile to the left of the previous
                }
            }
            else// moveing down the Y axis
            {
                Vector3 TempLocation = TileLocation + new Vector3(0, -6, 0);
                Vector3 TempLocation2 = TileLocation + new Vector3(0, 6, 0);
                Vector3 TempLocation3 = TileLocation + new Vector3(6, 0, 0);
                Vector3 TempLocation4 = TileLocation + new Vector3(-6, 0, 0);
                if (LocationOfTiles.Contains(TempLocation) == false)//this checks to see if the these coordanites exist already
                {
                    TileLocation = TileLocation + new Vector3(0, -6, 0);//places the next tile above the previous
                }
                else if (LocationOfTiles.Contains(TempLocation) == false)
                {
                    TileLocation = TileLocation + new Vector3(0, 6, 0);//places the next tile below the previous
                }
                else if (LocationOfTiles.Contains(TempLocation3) == false)
                {
                    TileLocation = TileLocation + new Vector3(6, 0, 0);//places the next tile to the right of the previous
                }
                else if (LocationOfTiles.Contains(TempLocation4) == false)
                {
                    TileLocation = TileLocation + new Vector3(-6, 0, 0);//places the next tile to the left of the previous
                }
                else
                {
                    TileLocation = TileLocation + new Vector3(-12, 0, 0);//places the next tile to the left of the previous
                }
            }
        }
        else
        {
            YAxis = true;
            if (PosOrNeg <= 10)// moving right on the x axis
            {
                Vector3 TempLocation = TileLocation + new Vector3(6, 0, 0);
                Vector3 TempLocation2 = TileLocation + new Vector3(-6, 0, 0);
                Vector3 TempLocation3 = TileLocation + new Vector3(0, 6, 0);
                Vector3 TempLocation4 = TileLocation + new Vector3(0, -6, 0);
                if (LocationOfTiles.Contains(TempLocation) == false)//this checks to see if the these coordanites exist already
                {
                    TileLocation = TileLocation + new Vector3(6, 0, 0);//places the next tile to the left of the previous
                }
                else if (LocationOfTiles.Contains(TempLocation2) == false)
                {
                    TileLocation = TileLocation + new Vector3(-6, 0, 0);//places the next tile to the right of the previous
                }
                else if (LocationOfTiles.Contains(TempLocation3) == false)
                {
                    TileLocation = TileLocation + new Vector3(0, 6, 0);//places the next tile to the right of the previous
                }
                else if (LocationOfTiles.Contains(TempLocation4) == false)
                {
                    TileLocation = TileLocation + new Vector3(0, -6, 0);//places the next tile above the previous
                }
                else
                {
                    TileLocation = TileLocation + new Vector3(0, -12, 0);
                }
            }
            else// moveing left on the x axis
            {
                Vector3 TempLocation = TileLocation + new Vector3(-6, 0, 0);
                Vector3 TempLocation2 = TileLocation + new Vector3(6, 0, 0);
                Vector3 TempLocation3 = TileLocation + new Vector3(0, 6, 0);
                Vector3 TempLocation4 = TileLocation + new Vector3(0, -6, 0);
                if (LocationOfTiles.Contains(TempLocation) == false)//this checks to see if the these coordanites exist already
                {
                    TileLocation = TileLocation + new Vector3(-6, 0, 0);//places the next tile to the right of the previous
                }
                else if (LocationOfTiles.Contains(TempLocation2) == false)
                {
                    TileLocation = TileLocation + new Vector3(6, 0, 0);//places the next tile to the left of the previous
                }
                else if (LocationOfTiles.Contains(TempLocation3) == false)
                {
                    TileLocation = TileLocation + new Vector3(0, 6, 0);//places the next tile to the right of the previous
                }
                else if (LocationOfTiles.Contains(TempLocation4) == false)
                {
                    TileLocation = TileLocation + new Vector3(0, -6, 0);//places the next tile to the right of the previous
                }
                else
                {
                    TileLocation = TileLocation + new Vector3(0, -12, 0);//places the next tile above the previous
                }
            }
        }
    }
}

