using System;
using System.Linq;
class Program
{
    static int n, t;
    static int[] weight, bead;
    static int[] sum;
    static bool[] measure = new bool[15001];
    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        sum = new int[n];
        weight = Console.ReadLine().Split().Select(int.Parse).ToArray();
        t = int.Parse(Console.ReadLine());
        bead = Console.ReadLine().Split().Select(int.Parse).ToArray();
        check(0);
        for(int i = 0; i < t - 1; i++)
            Console.Write(measure[bead[i]] ? "Y " : "N ");
        Console.Write(measure[bead[t - 1]] ? "Y" : "N");
    }
    static void check(int d)
    {
        if (d == n)
        {
            int index = 0;
            for(int i = 0; i < n; i++)
                index += sum[i] * weight[i];
            if (index > 0) measure[index] = true;
            return;
        }
        for(int i = -1; i < 2; i++)
        {
            sum[d] = i;
            check(d + 1);
        }
    }
}