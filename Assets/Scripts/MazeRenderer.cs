using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{

    [SerializeField]
    [Range(1, 50)]
    private int width = 10;

    [SerializeField]
    [Range(1, 50)]
    private int height = 10;

    [SerializeField]
    private float size = 1f;

    [SerializeField]
    private Transform wallPrefab = null;

    [SerializeField]
    private Transform floorPrefab = null;

    void Start()
    {
        var maze = MazeGenerator.Generate(width, height);
        Draw(maze);
    }

    private void Draw(FalTulajdonsagok[,] maze)
    {

        var floor = Instantiate(floorPrefab, transform);
        floor.localScale = new Vector3(width, 1, height);

        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {

                var cell = maze[i, j];
                var position = new Vector3(-width / 2 + i, 0, -height / 2 + j);

                if (cell.HasFlag(FalTulajdonsagok.FEL))
                {
                    var topWall = CreateWall(position + new Vector3(0, 0, size / 2));
                }

                if (cell.HasFlag(FalTulajdonsagok.FEL))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(FalTulajdonsagok.BAL))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(FalTulajdonsagok.JOBB))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(+size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(FalTulajdonsagok.LE))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }

        }

    }
    private Transform CreateWall(Vector3 position, bool rotate = false)
    {
        var wall = Instantiate(wallPrefab, position, Quaternion.identity, transform);
        if (rotate)
        {
            wall.eulerAngles = new Vector3(0, 90, 0);
        }
        wall.gameObject.tag = "Wall"; // Itt adjuk hozz� a "Wall" taget a falakhoz
        return wall;
    }

    void Update()
    {

    }
}
