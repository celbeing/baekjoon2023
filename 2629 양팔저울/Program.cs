using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static int n, t;
    static int[] weight, bead;
    static List<int> measure = new List<int>();
    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        weight = Console.ReadLine().Split().Select(int.Parse).ToArray();
        t = int.Parse(Console.ReadLine());
        bead = Console.ReadLine().Split().Select(int.Parse).ToArray();
        measure.Add(0);
        for(int i = 1; i <= n; i++)
        {
            for(int j = 0; j < measure.Count; j++)
            {
                int k = measure[j];
                k -= weight[i - 1];
                if(k > 0 && !measure.Contains(k))
                    measure.Add(k);
                k += weight[i - 1] * 2;
                if (k > 0 && !measure.Contains(k))
                    measure.Add(k);
            }
        }
        for(int i = 0; i < t - 1; i++)
            Console.Write(measure.Contains(bead[i]) ? "Y " : "N ");
        Console.Write(measure.Contains(bead[t - 1]) ? "Y" : "N");
    }
}