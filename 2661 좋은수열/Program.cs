using System;
using System.Collections.Generic;
class Program
{
    static int N;
    static int[] goodarray;
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        goodarray = new int[N];
    }
    static void bt(int depth)
    {
        if (check(depth)) return;
        if (depth == N) return;
        for(int i = 1; i < 4; i++)
        {
            goodarray[depth] = i;
            bt(depth + 1);
        }
    }
    static bool check(int depth)
    {
        for(int i = 1; i * 2 <= N; i++)
        {
            bool result = false;
            for(int j = 0; j < i; j++)
            {
                if(goodarray[depth - i + j] != goodarray[depth - i*2 + j])
                {
                    result = true;
                    break;
                }
            }
            if (result) continue;
            else return false;
        }
        return true;
    }
}