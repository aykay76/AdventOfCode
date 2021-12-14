using System;
using System.Collections.Generic;
using System.IO;

public class Ninth
{
    public void Run1()
    {
        string[] lines = File.ReadAllLines("09.txt");
        List<int> lowPoints = new List<int>();

        for (int x = 0; x < lines[0].Length; x++)
        {
            for (int y = 0; y < lines.Length; y++)
            {
                int h = lines[y][x];
                int u = int.MaxValue;
                if (y > 0) u = lines[y - 1][x];
                int d = int.MaxValue;
                if (y < lines.Length - 1)
                {
                    d = lines[y + 1][x];
                }
                int l = int.MaxValue;
                if (x > 0) l = lines[y][x - 1];
                int r = int.MaxValue;
                if (x < lines[0].Length - 1) r = lines[y][x + 1];

                if (h < u && h < d && h < l && h < r)
                {
                    lowPoints.Add(h + 1 - '0');
                }
            }
        }

        int risk = 0;
        foreach (int value in lowPoints)
        {
            risk += value;
        }

        Console.WriteLine(risk);
    }
}