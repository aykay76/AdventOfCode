using System;
using System.Collections.Generic;
using System.IO;

public class Eleventh
{
    private void FlashOctopus(byte[] octopuses, bool[] flashes, int stride, int x, int y)
    {
        if (octopuses[y * stride + x] <= 9) return;
        if (flashes[y * stride + x]) return;

        flashes[y * stride + x] = true;

        int ny = y;

        // do those above if we're not on the edge
        if (y > 0)
        {
            ny = y - 1;

            // upper-left
            if (x > 0)
            {
                int nx = x - 1;
                octopuses[ny * stride + nx]++;
                FlashOctopus(octopuses, flashes, stride, nx, ny);
            }

            // up
            octopuses[ny * stride + x]++;
            FlashOctopus(octopuses, flashes, stride, x, ny);

            if (x < stride - 1)
            {
                int nx = x + 1;
                octopuses[ny * stride + nx]++;
                FlashOctopus(octopuses, flashes, stride, nx, ny);
            }
        }

        ny = y;
        if (x > 0)
        {
            int nx = x - 1;
            octopuses[ny * stride + nx]++;
            FlashOctopus(octopuses, flashes, stride, nx, ny);
        }

        octopuses[ny * stride + x]++;
        FlashOctopus(octopuses, flashes, stride, x, ny);

        if (x < stride - 1)
        {
            int nx = x + 1;
            octopuses[ny * stride + nx]++;
            FlashOctopus(octopuses, flashes, stride, nx, ny);
        }

        if (y < stride - 1)
        {
            ny = y + 1;

            if (x > 0)
            {
                int nx = x - 1;
                octopuses[ny * stride + nx]++;
                FlashOctopus(octopuses, flashes, stride, nx, ny);
            }

            octopuses[ny * stride + x]++;
            FlashOctopus(octopuses, flashes, stride, x, ny);

            if (x < stride - 1)
            {
                int nx = x + 1;
                octopuses[ny * stride + nx]++;
                FlashOctopus(octopuses, flashes, stride, nx, ny);
            }
        }
    }

    public void Run1()
    {
        int totalFlashes = 0;
        // load input
        string[] lines = File.ReadAllLines("11.txt");
        int stride = lines[0].Length;
        byte[] octopuses = new byte[lines.Length * lines[0].Length];

        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                octopuses[i * lines[0].Length + j] = (byte)(lines[i][j] - '0');
            }
        }

        // increase all the energy levels
        for (int step = 0; step < 100; step++)
        {
            bool[] flashes = new bool[octopuses.Length];

            for (int i = 0; i < octopuses.Length; i++)
            {
                octopuses[i]++;
            }

            // see what flashes
            for (int i = 0; i < octopuses.Length; i++)
            {
                if (octopuses[i] > 9)
                {
                    FlashOctopus(octopuses, flashes, stride, i % stride, i / stride);
                }
            }

            // reset all the flashed octopi
            for (int i = 0; i < flashes.Length; i++)
            {
                if (flashes[i])
                {
                    totalFlashes++;
                    octopuses[i] = 0;
                }
            }
        }

        Console.WriteLine(totalFlashes);
    }

    public void Run2()
    {
        int totalFlashes = 0;
        // load input
        string[] lines = File.ReadAllLines("11.txt");
        int stride = lines[0].Length;
        byte[] octopuses = new byte[lines.Length * lines[0].Length];

        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                octopuses[i * lines[0].Length + j] = (byte)(lines[i][j] - '0');
            }
        }

        // increase all the energy levels
        int step = 0;
        do
        {
            bool[] flashes = new bool[octopuses.Length];

            for (int i = 0; i < octopuses.Length; i++)
            {
                octopuses[i]++;
            }

            // see what flashes
            for (int i = 0; i < octopuses.Length; i++)
            {
                if (octopuses[i] > 9)
                {
                    FlashOctopus(octopuses, flashes, stride, i % stride, i / stride);
                }
            }

            // reset all the flashed octopi
            totalFlashes = 0;
            for (int i = 0; i < flashes.Length; i++)
            {
                if (flashes[i])
                {
                    totalFlashes++;
                    octopuses[i] = 0;
                }
            }
            step++;
        }
        while (totalFlashes < octopuses.Length);

        Console.WriteLine(step);        
    }
}