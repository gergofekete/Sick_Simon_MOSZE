using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class EnemySpawnerTests
{
    [UnityTest]
    public IEnumerator Spawner_SpawnsCorrectNumberOfEnemies()
    {
        // Labirintus létrehozása és ellenség spawner inicializálása
        var maze = MazeGenerator.Generate(10, 10);
        var spawnerGameObject = new GameObject();
        var enemySpawner = spawnerGameObject.AddComponent<EnemySpawner>();
        enemySpawner.enemyPrefab = Resources.Load<GameObject>("EnemyPrefab");
        enemySpawner.enemyCount = 4;
        enemySpawner.mazeWidth = 10;
        enemySpawner.mazeHeight = 10;

        // Ellenségek spawnolása
        enemySpawner.SpawnEnemies(maze);

        // Várakozás a spawnolás befejezõdésére
        yield return null;

        // Ellenõrzés, hogy a megfelelõ számú ellenség lett-e létrehozva
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Assert.AreEqual(4, enemies.Length);
    }
}
