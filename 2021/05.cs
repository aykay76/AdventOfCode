using System;
using System.Collections.Generic;
using System.IO;

public class Fifth
{
    public void Run1()
    {
        string[] lines = File.ReadAllLines("05.txt");
        Dictionary<Tuple<int, int>, int> results = new Dictionary<Tuple<int, int>, int>();

        foreach (string line in lines)
        {
            string[] ends = line.Split(" -> ");
            string[] start = ends[0].Split(",");
            string[] finish = ends[1].Split(",");

            int sx = int.Parse(start[0]);
            int sy = int.Parse(start[1]);
            int fx = int.Parse(finish[0]);
            int fy = int.Parse(finish[1]);

            if (sx == fx)
            {
                for (int y = Math.Min(sy, fy); y <= Math.Max(sy, fy); y++)
                {
                    Tuple<int, int> pos = new Tuple<int, int>(sx, y);
                    if (results.ContainsKey(pos))
                    {
                        results[pos] = results[pos] + 1;
                    }
                    else
                    {
                        results[pos] = 1;
                    }
                }
            }   

            if (sy == fy)
            {
                for (int x = Math.Min(sx, fx); x <= Math.Max(sx, fx); x++)
                {
                    Tuple<int, int> pos = new Tuple<int, int>(x, sy);
                    if (results.ContainsKey(pos))
                    {
                        results[pos] = results[pos] + 1;
                    }
                    else
                    {
                        results[pos] = 1;
                    }
                }
            }         
        }

        int count = 0;
        foreach (int value in results.Values)
        {
            if (value > 1) count++;
        }

        Console.WriteLine($"Count: {count}");
    }

    public void Run2()
    {
        string[] lines = File.ReadAllLines("05.txt");
        Dictionary<Tuple<int, int>, int> results = new Dictionary<Tuple<int, int>, int>();

        foreach (string line in lines)
        {
            string[] ends = line.Split(" -> ");
            string[] start = ends[0].Split(",");
            string[] finish = ends[1].Split(",");

            int sx = int.Parse(start[0]);
            int sy = int.Parse(start[1]);
            int fx = int.Parse(finish[0]);
            int fy = int.Parse(finish[1]);

            if (sx == fx)
            {
                for (int y = Math.Min(sy, fy); y <= Math.Max(sy, fy); y++)
                {
                    Tuple<int, int> pos = new Tuple<int, int>(sx, y);
                    if (results.ContainsKey(pos))
                    {
                        results[pos] = results[pos] + 1;
                    }
                    else
                    {
                        results[pos] = 1;
                    }
                }
            }   
            else if (sy == fy)
            {
                for (int x = Math.Min(sx, fx); x <= Math.Max(sx, fx); x++)
                {
                    Tuple<int, int> pos = new Tuple<int, int>(x, sy);
                    if (results.ContainsKey(pos))
                    {
                        results[pos] = results[pos] + 1;
                    }
                    else
                    {
                        results[pos] = 1;
                    }
                }
            }
            else
            {
                int x1 = sx;
                int y1 = sy;
                int x2 = fx;
                int y2 = fy;

                if (fx < sx)
                {
                    x1 = fx;
                    y1 = fy;
                    x2 = sx;
                    y2 = sy;
                }

                int y = y1;
                for (int x = x1; x <= x2; x++)
                {
                    Tuple<int, int> pos = new Tuple<int, int>(x, y);
                    if (results.ContainsKey(pos))
                    {
                        results[pos] = results[pos] + 1;
                    }
                    else
                    {
                        results[pos] = 1;
                    }
                    if (y2 < y1)
                    {
                        y--;
                    }
                    else
                    {
                        y++;
                    }
                }
            }
        }

        int count = 0;
        foreach (int value in results.Values)
        {
            if (value > 1) count++;
        }

        Console.WriteLine($"Count: {count}");
    }
}