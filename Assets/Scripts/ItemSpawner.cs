using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public int itemCount = 4;
    public int mazeWidth = 10;
    public int mazeHeight = 10;

    void Start()
    {
        FalTulajdonsagok[,] maze = MazeGenerator.Generate(mazeWidth, mazeHeight);
        SpawnItems(maze);
    }

    void SpawnItems(FalTulajdonsagok[,] maze)
    {
        List<Pozicio> freeCells = GetFreeCells(maze);
        int itemsToSpawn = Mathf.Min(itemCount, freeCells.Count);

        for (int i = 0; i < itemsToSpawn; i++)
        {
            if (freeCells.Count == 0) break;

            int randomIndex = Random.Range(0, freeCells.Count);
            Pozicio cell = freeCells[randomIndex];
            freeCells.RemoveAt(randomIndex);

            Vector3 spawnPosition = new Vector3(cell.X - mazeWidth / 2, 0.15f, cell.Y - mazeHeight / 2);
            Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        }
    }

    List<Pozicio> GetFreeCells(FalTulajdonsagok[,] maze)
    {
        List<Pozicio> freeCells = new List<Pozicio>();
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                if (maze[x, y].HasFlag(FalTulajdonsagok.LATOGATVA))
                {
                    freeCells.Add(new Pozicio { X = x, Y = y });
                }
            }
        }
        return freeCells;
    }
}
