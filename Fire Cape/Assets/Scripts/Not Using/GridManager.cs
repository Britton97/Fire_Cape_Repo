using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] public int _width, _length;

    [SerializeField] private Tile tilePrefab;

    [SerializeField] private Transform cam;

    [SerializeField] private GameObject tileHolder;

    [SerializeField] public bool generateMap = false;



    private void Awake()
    {
        if (generateMap)
        {
            GenerateGrid();
        }
        else
        {
            AverageCamPos();
        }
    }

    private void AverageCamPos()
    {
        /*
        Vector3 average = Vector3.zero;
        foreach(Transform child in tileHolder.transform)
        {
            print(child.name);
            average += child.transform.position;
        }

        average = average / tileHolder.transform.childCount;
        cam.transform.position = new Vector3(average.x, average.y, cam.transform.position.z);
        */
    }

    void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _length; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
                spawnedTile.transform.parent = tileHolder.transform;
            }
        }

        cam.transform.position = new Vector3((float)_width / 2 -.5f, (float)_length / 2 -.5f, -10);
    }
}
