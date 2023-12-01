using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class EnemySpawnerTests
{
    [UnityTest]
    public IEnumerator Spawner_SpawnsCorrectNumberOfEnemies()
    {
        // Labirintus l�trehoz�sa �s ellens�g spawner inicializ�l�sa
        var maze = MazeGenerator.Generate(10, 10);
        var spawnerGameObject = new GameObject();
        var enemySpawner = spawnerGameObject.AddComponent<EnemySpawner>();
        enemySpawner.enemyPrefab = Resources.Load<GameObject>("EnemyPrefab");
        enemySpawner.enemyCount = 4;
        enemySpawner.mazeWidth = 10;
        enemySpawner.mazeHeight = 10;

        // Ellens�gek spawnol�sa
        enemySpawner.SpawnEnemies(maze);

        // V�rakoz�s a spawnol�s befejez�d�s�re
        yield return null;

        // Ellen�rz�s, hogy a megfelel� sz�m� ellens�g lett-e l�trehozva
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Assert.AreEqual(4, enemies.Length);
    }
}
