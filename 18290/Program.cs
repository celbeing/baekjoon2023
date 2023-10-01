using System;
using System.Collections.Generic;

class program
{
    static int N, M, K;
    static int[,] set = new int[12, 12];
    static Stack<int> select = new Stack<int>();

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        N = int.Parse(input[0]);
        M = int.Parse(input[1]);
        K = int.Parse(input[2]);
    }

    void BackTrack(int i, int d)
    {
        
    }
}