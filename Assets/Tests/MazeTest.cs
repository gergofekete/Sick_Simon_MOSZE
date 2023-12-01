using NUnit.Framework;
using UnityEngine;


public class MazeTest
{
    [Test]
    public void Generate_CreatesProperSizeMaze()
    {
        int width = 10;
        int height = 10;

        var maze = MazeGenerator.Generate(width, height);

        Assert.IsNotNull(maze, "A generált labirintus null.");
        Assert.AreEqual(width, maze.GetLength(0), "A labirintus szélessége nem megfelelő.");
        Assert.AreEqual(height, maze.GetLength(1), "A labirintus magassága nem megfelelő.");
    }
}
