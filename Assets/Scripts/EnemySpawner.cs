using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 4;
    public int mazeWidth = 10;
    public int mazeHeight = 10;

    void Start()
    {
        FalTulajdonsagok[,] maze = MazeGenerator.Generate(mazeWidth, mazeHeight);
        SpawnEnemies(maze);
    }

    public void SpawnEnemies(FalTulajdonsagok[,] maze)
    {
        List<Pozicio> freeCells = GetFreeCells(maze);
        int enemiesToSpawn = Mathf.Min(enemyCount, freeCells.Count);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            if (freeCells.Count == 0) break;

            int randomIndex = Random.Range(0, freeCells.Count);
            Pozicio cell = freeCells[randomIndex];
            freeCells.RemoveAt(randomIndex);

            Vector3 spawnPosition = new Vector3(cell.X - mazeWidth / 2, 0.15f, cell.Y - mazeHeight / 2);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
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