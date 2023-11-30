using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Flags]
public enum FalTulajdonsagok
{
    // 0000 -> Nincs fal
    // 1111 -> BAL,JOBB,FEL,LE
    BAL = 1, // 0001
    JOBB = 2, // 0010
    FEL = 4, // 0100
    LE = 8, // 1000

    LATOGATVA = 128, // 1000 0000
}

public struct Pozicio
{
    public int X;
    public int Y;
}

public struct Neighbour
{
    public Pozicio Pozicio;
    public FalTulajdonsagok KozosFal;
}

public static class MazeGenerator
{

    private static FalTulajdonsagok GetOppositeWall(FalTulajdonsagok fal)
    {
        switch (fal)
        {
            case FalTulajdonsagok.JOBB: return FalTulajdonsagok.BAL;
            case FalTulajdonsagok.BAL: return FalTulajdonsagok.JOBB;
            case FalTulajdonsagok.FEL: return FalTulajdonsagok.LE;
            case FalTulajdonsagok.LE: return FalTulajdonsagok.FEL;
            default: return FalTulajdonsagok.BAL;
        }
    }

    private static FalTulajdonsagok[,] ApplyRecursiveBacktracker(FalTulajdonsagok[,] labirintus, int width, int height)
    {
        var RandomSzG = new System.Random();
        var PozicioVerem = new Stack<Pozicio>();
        var pozicio = new Pozicio { X = RandomSzG.Next(0, width), Y = RandomSzG.Next(0, height) };

        labirintus[pozicio.X, pozicio.Y] |= FalTulajdonsagok.LATOGATVA;  // 1000 1111
        PozicioVerem.Push(pozicio);

        while (PozicioVerem.Count > 0)
        {
            var current = PozicioVerem.Pop();
            var szomszed = GetUnvisitedNeighbours(current, labirintus, width, height);

            if (szomszed.Count > 0)
            {
                PozicioVerem.Push(current);

                var Index = RandomSzG.Next(0, szomszed.Count);
                var RandomSzomszed = szomszed[Index];

                var szomszedPozicio = RandomSzomszed.Pozicio;
                labirintus[current.X, current.Y] &= ~RandomSzomszed.KozosFal;
                labirintus[szomszedPozicio.X, szomszedPozicio.Y] &= ~GetOppositeWall(RandomSzomszed.KozosFal);
                labirintus[szomszedPozicio.X, szomszedPozicio.Y] |= FalTulajdonsagok.LATOGATVA;

                PozicioVerem.Push(szomszedPozicio);
            }
        }

        return labirintus;
    }

    private static List<Neighbour> GetUnvisitedNeighbours(Pozicio p, FalTulajdonsagok[,] labirintus, int width, int height)
    {
        var listazas = new List<Neighbour>();

        if (p.X > 0) // BAL
        {
            if (!labirintus[p.X - 1, p.Y].HasFlag(FalTulajdonsagok.LATOGATVA))
            {
                listazas.Add(new Neighbour
                {
                    Pozicio = new Pozicio
                    {
                        X = p.X - 1,
                        Y = p.Y
                    },
                    KozosFal = FalTulajdonsagok.BAL
                });
            }
        }

        if (p.Y > 0) // LE
        {
            if (!labirintus[p.X, p.Y - 1].HasFlag(FalTulajdonsagok.LATOGATVA))
            {
                listazas.Add(new Neighbour
                {
                    Pozicio = new Pozicio
                    {
                        X = p.X,
                        Y = p.Y - 1
                    },
                    KozosFal = FalTulajdonsagok.LE
                });
            }
        }

        if (p.Y < height - 1) // FEL
        {
            if (!labirintus[p.X, p.Y + 1].HasFlag(FalTulajdonsagok.LATOGATVA))
            {
                listazas.Add(new Neighbour
                {
                    Pozicio = new Pozicio
                    {
                        X = p.X,
                        Y = p.Y + 1
                    },
                    KozosFal = FalTulajdonsagok.FEL
                });
            }
        }

        if (p.X < width - 1) // JOBB
        {
            if (!labirintus[p.X + 1, p.Y].HasFlag(FalTulajdonsagok.LATOGATVA))
            {
                listazas.Add(new Neighbour
                {
                    Pozicio = new Pozicio
                    {
                        X = p.X + 1,
                        Y = p.Y
                    },
                    KozosFal = FalTulajdonsagok.JOBB
                });
            }
        }

        return listazas;
    }

    public static FalTulajdonsagok[,] Generate(int width, int height)
    {
        FalTulajdonsagok[,] labirintus = new FalTulajdonsagok[width, height];
        FalTulajdonsagok initial = FalTulajdonsagok.JOBB | FalTulajdonsagok.BAL | FalTulajdonsagok.FEL | FalTulajdonsagok.LE;
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                labirintus[i, j] = initial;  // 1111
            }
        }

        return ApplyRecursiveBacktracker(labirintus, width, height);
    }
}
