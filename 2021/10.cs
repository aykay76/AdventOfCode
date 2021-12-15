using System;
using System.Collections.Generic;
using System.IO;

public class Tenth
{
    Stack<char> openers = new Stack<char>();

    int CheckLine(string line)
    {
        foreach (char c in line)
        {
            if (c == '{' || c == '(' || c == '[' || c == '<')
            {
                openers.Push(c);
            }
            else if (c == ')')
            {
                char opener = openers.Pop();
                if (opener != '(')
                {
                    return 3;
                }
            }
            else if (c == ']')
            {
                char opener = openers.Pop();
                if (opener != '[')
                {
                    return 57;
                }
            }
            else if (c == '}')
            {
                char opener = openers.Pop();
                if (opener != '{')
                {
                    return 1197;
                }
            }
            else if (c == '>')
            {
                char opener = openers.Pop();
                if (opener != '<')
                {
                    return 25137;
                }
            }
        }

        return 0;
    }

    public void Run1()
    {
        string[] lines = File.ReadAllLines("10.txt");
        int total = 0;

        foreach (string line in lines)
        {
            int value = CheckLine(line);
            total += value;
        }
        Console.WriteLine(total);
    }

    public void Run2()
    {
        string[] lines = File.ReadAllLines("10.txt");
        List<Int64> scores = new List<Int64>();

        foreach (string line in lines)
        {
            openers.Clear();
            int value = CheckLine(line);
            if (value == 0)
            {
                // process the remaining stack
                Int64 score = 0;
                while (openers.Count > 0)
                {
                    score = score * 5;
                    char c = openers.Pop();
                    if (c == '(') score += 1;
                    if (c == '[') score += 2;
                    if (c == '{') score += 3;
                    if (c == '<') score += 4;
                }

                Console.WriteLine(score);
                scores.Add(score);
            }
        }

        scores.Sort();

        Console.WriteLine(scores[scores.Count / 2]);
    }
}