using System;

class Program
{
    static int K;
    static bool[,] gear = new bool[4,8];
    static void Main()
    {
        for(int i = 0; i < 4; i++)
        {
            string g = Console.ReadLine();
            for (int j = 0; j < 8; j++)
            {
                if (g[j] == '0') gear[i, j] = false;
                else gear[i, j] = true;
            }
        }

    }
    static void turn(int n, int d)
    {
        bool mem;
        if (d == 1) mem = gear[n, 7];
        else mem = gear[n, 0];
        for(int i = 0; i < 8; i++)
    }
}