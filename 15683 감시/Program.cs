using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int N, M;
    static List<int[]> office = new List<int[]>();
    static void Main()
    {
        string[] nm = Console.ReadLine().Split();
        N = int.Parse(nm[0]); M = int.Parse(nm[1]);
        for(int i = 0; i < N; i++)
            office.Add(Console.ReadLine().Split().Select(int.Parse).ToArray());

    }

}