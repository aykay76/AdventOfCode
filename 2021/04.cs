using System;
using System.Collections.Generic;
using System.IO;

public class Board
{
    private int[] numbers;
    private bool[] marked;
    private bool alreadyWon = false;

    public Board(int[] values)
    {
        numbers = values;
        marked = new bool[25];
        for (int i = 0; i < 25; i++) marked[i] = false;
    }

    public bool CheckWin(int number)
    {
        if (alreadyWon) return false;
        
        // first mark the number if there is a match
        for (int i = 0; i < 25; i++)
        {
            if (marked[i] == false && numbers[i] == number)
            {
                marked[i] = true;
            }
        }

        // now check the rows
        for (int r = 0; r < 5; r++)
        {
            bool win = true;
            for (int i = r * 5; i < r * 5 + 5; i++)
            {
                if (marked[i] == false) win = false;
            }
            if (win) 
            {
                alreadyWon = true;
                return true;
            }
        }

        // and check the columns
        for (int c = 0; c < 5; c++)
        {
            bool win = true;
            for (int i = c; i < c + 5 * 5; i += 5)
            {
                if (marked[i] == false) win = false;
            }
            if (win) 
            {
                alreadyWon = true;
                return true;
            }
        }

        return false;
    }

    public int GetScore()
    {
        int score = 0;
        for (int i = 0; i < 25; i++)
        {
            if (marked[i] == false) score += numbers[i];
        }
        return score;
    }
}

public class Fourth
{
    public void Run1()
    {
        List<Board> boards = new List<Board>();
        string[] lines = File.ReadAllLines("04.txt");
        string[] parts = lines[0].Split(",");

        int line = 2;
        while (line < lines.Length)
        {
            int[] values = new int[25];
            int v = 0;

            for (int l = 0; l < 5; l++)
            {
                for (int i = 0; i < 5; i++)
                {
                    values[v++] = Convert.ToInt32(lines[line].Substring(i * 3, 2));
                }
                line++;
            }
            line++;
            boards.Add(new Board(values));
        }

        string[] numbers = lines[0].Split(",");
        foreach (string s in numbers)
        {
            int number = Convert.ToInt32(s);
            foreach (Board board in boards)
            {
                if (board.CheckWin(number))
                {
                    int score = board.GetScore();
                    Console.WriteLine($"We have a winner: {score * number}");
                    return;
                }
            }
        }
    }

    public void Run2()
    {
        List<Board> boards = new List<Board>();
        string[] lines = File.ReadAllLines("04.txt");
        string[] parts = lines[0].Split(",");

        int line = 2;
        while (line < lines.Length)
        {
            int[] values = new int[25];
            int v = 0;

            for (int l = 0; l < 5; l++)
            {
                for (int i = 0; i < 5; i++)
                {
                    values[v++] = Convert.ToInt32(lines[line].Substring(i * 3, 2));
                }
                line++;
            }
            line++;
            boards.Add(new Board(values));
        }

        Board lastWinner = null;
        int winningNumber = -1;
        string[] numbers = lines[0].Split(",");
        foreach (string s in numbers)
        {
            int number = Convert.ToInt32(s);
            foreach (Board board in boards)
            {
                if (board.CheckWin(number))
                {
                    lastWinner = board;
                    winningNumber = number;
                }
            }
        }

        if (lastWinner != null)
        {
            int score = lastWinner.GetScore();
            Console.WriteLine($"Last winner board score: {score * winningNumber}");
        }
    }
}