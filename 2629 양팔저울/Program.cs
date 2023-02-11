using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static int n, t;
    static int[] weight, bead;
    static bool[,] measure = new bool[31, 40001];
    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        weight = Console.ReadLine().Split().Select(int.Parse).ToArray();
        t = int.Parse(Console.ReadLine());
        bead = Console.ReadLine().Split().Select(int.Parse).ToArray();
        dp(0, 0);
        for(int i = 0; i < t; i++)
            for(int j = 0; j < n; j++)
                if (measure[j, bead[i]]) measure[30, bead[i]] = true;
        for(int i = 0; i < t - 1; i++)
            Console.Write(measure[30, bead[i]] ? "Y " : "N ");
        Console.Write(measure[30, bead[t - 1]] ? "Y" : "N");
    }
    static void dp(int k, int w)
    {
        if (k == n || measure[k,w]) return;
        measure[k,w] = true;
        dp(k + 1, w + weight[k]);
        dp(k + 1, w);
        int absolute = w - weight[k];
        if (absolute < 0) absolute *= -1;
        dp(k + 1, absolute);
    }
}