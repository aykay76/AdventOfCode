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

        Console.WriteLine($"Low points {lowPoints.Count}, risk = {risk}");
    }

    public void Run2()
    {
        string[] lines = File.ReadAllLines("09.txt");
        List<Tuple<int,int>> lowPoints = new List<Tuple<int,int>>();

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
                    lowPoints.Add(new Tuple<int, int>(x, y));
                }
            }
        }

        // from each low point, spread out until can't go anywhere because either another basin is in the way or all 9
        // this needs a recursive approach
        List<int> sizes = new List<int>();
        bool[] visited = new bool[lines.Length * lines[0].Length];
        foreach (Tuple<int, int> pos in lowPoints)
        {
            int size = 0;
            CheckBasin(lines, pos.Item1, pos.Item2, visited, ref size);
            sizes.Add(size);
        }

        sizes.Sort();

        int basins = sizes.Count;
        int result = sizes[basins - 1] * sizes[basins - 2] * sizes[basins - 3];
        Console.WriteLine(result);
    }

    protected void CheckBasin(string[] lines, int x, int y, bool[] visited, ref int size)
    {
        if (visited[y * lines[0].Length + x] == true) return;
        if (lines[y][x] == '9') return;

        size++;
        visited[y * lines[0].Length + x] = true;

        // see if I can move up
        if (y > 0)
        {
            CheckBasin(lines, x, y - 1, visited, ref size);
        }
        if (y < lines.Length - 1)
        {
            CheckBasin(lines, x, y + 1, visited, ref size);
        }
        if (x > 0)
        {
            CheckBasin(lines, x - 1, y, visited, ref size);
        }
        if (x < lines[0].Length - 1)
        {
            CheckBasin(lines, x + 1, y, visited, ref size);
        }
    }
}