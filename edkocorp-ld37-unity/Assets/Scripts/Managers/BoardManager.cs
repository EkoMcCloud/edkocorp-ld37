using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public GameObject door;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] wallAngleTiles;

    public GameObject[] spawners;

    private int currentLvl = 1;

    private int nbSpawners;

    private int columns = 15;
    private int rows = 10;

    public Transform boardHolder { get; private set; }

    private List<Vector3> gridPositions = new List<Vector3>();
    private GameObject player;

    public void SetupScene()
    {
        InitializeList();
        BoardSetup();

        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = RandomPosition();
        CameraManager.instance.FollowPlayer();


        //Instantiate(exit, new Vector3(columns - 1, rows - 1, 0), Quaternion.identity);
    }

    private void InitializeList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0));
            }
        }
    }

    private void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = RandomGameObject(floorTiles);
                float rotation = 0;
                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    if (x == -1 && y == -1)
                    {
                        toInstantiate = RandomGameObject(wallAngleTiles);
                        rotation = 90;
                    }
                    else if (x == -1 && y == rows)
                    {
                        toInstantiate = RandomGameObject(wallAngleTiles);
                        rotation = 0;
                    }
                    else if (x == columns && y == -1)
                    {
                        toInstantiate = RandomGameObject(wallAngleTiles);
                        rotation = 180;
                    }
                    else if (x == columns && y == rows)
                    {
                        toInstantiate = RandomGameObject(wallAngleTiles);
                        rotation = 270;
                    }
                    else
                    {
                        toInstantiate = RandomGameObject(wallTiles);
                        if (x == -1) rotation = 0;
                        else if (x == columns) rotation = 180;
                        else if (y == -1) rotation = 90;
                        else if (y == rows) rotation = 270;
                    }
                }

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                instance.transform.Rotate(new Vector3(0, 0, rotation)); 

                instance.transform.SetParent(boardHolder);
            }
        }

        nbSpawners = currentLvl;
        for(int i = 0; i < nbSpawners; i++)
        {
            GameObject spawner = Instantiate(RandomGameObject(spawners), RandomPosition(), Quaternion.identity) as GameObject;
            spawner.transform.SetParent(boardHolder);
        }
    }

    private GameObject RandomGameObject(GameObject[] gameObjects)
    {
        return gameObjects[Random.Range(0, gameObjects.Length)];
    }

    private Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);

        return randomPosition;
    }

    private void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void OnSpawnerDestroyed()
    {
        nbSpawners--;
        if(nbSpawners == 0)
        {
            currentLvl++;
            GameManager.instance.OnLevelClear();
        }
    }
}
