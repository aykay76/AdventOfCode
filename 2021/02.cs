using System;
using System.Collections.Generic;
using System.IO;

public class Second
{
    public void Run1()
    {
        string[] lines = File.ReadAllLines("02.txt");
        int x = 0;
        int d = 0;

        foreach (string line in lines)
        {
            string[] parts = line.Split(" ");
            int value = int.Parse(parts[1]);

            if (parts[0] == "forward")
            {
                x += value;
            }
            else if (parts[0] == "up")
            {
                d -= value;
            }
            else if (parts[0] == "down")
            {
                d += value;
            }
        }

        Console.WriteLine($"Horizontal times depth: {x * d}");
    }

    // https://adventofcode.com/2021/day/2#part2
    public void Run2()
    {
        string[] lines = File.ReadAllLines("02.txt");
        int x = 0;
        int d = 0;
        int aim = 0;

        foreach (string line in lines)
        {
            string[] parts = line.Split(" ");
            int value = int.Parse(parts[1]);

            if (parts[0] == "forward")
            {
                x += value;
                d += aim * value;
            }
            else if (parts[0] == "up")
            {
                // d -= value;
                aim -= value;
            }
            else if (parts[0] == "down")
            {
                // d += value;
                aim += value;
            }
        }

        Console.WriteLine($"Horizontal times depth: {x * d}");
    }
}