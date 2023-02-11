using System;

class Program
{
    static int N, L, count;
    static int[,] map;
    static void Main()
    {
        string[] nl = Console.ReadLine().Split();
        N = int.Parse(nl[0]);
        L = int.Parse(nl[1]);
        map = new int[N, N];
        for (int i = 0; i < N; i++)
        {
            string[] row = Console.ReadLine().Split();
            for (int j = 0; j < N; j++)
            {
                map[i, j] = int.Parse(row[j]);
            }
        }
        count = N * 2;
        // check row
        int cntH = 0;
        for (int i = 0; i < N; i++)
        {
            cntH = map[i, 0];
            bool[] hill = new bool[N];
            for(int j = 1; j < N; j++)
            {
                if(cntH != map[i, j])
                {
                    if (cntH + 1 == map[i, j])
                    {
                        if (j - L < 0)
                        {
                            j = N;
                            count--;
                            continue;
                        }
                        for (int l = 1; l <= L; l++)
                        {
                            if (hill[j - l])
                            {
                                j = N;
                                l = L + 1;
                            }
                            else if (cntH != map[i, j - l])
                            {
                                j = N;
                                l = L + 1;
                            }
                        }
                        if (j == N)
                        {
                            count--;
                            continue;
                        }
                        for (int l = 1; l <= L; l++)
                            hill[j - l] = true;
                    }
                    else if (cntH - 1 == map[i, j])
                    {
                        if (j + L > N)
                        {
                            j = N;
                            count--;
                            continue;
                        }
                        for (int l = 0; l < L; l++)
                        {
                            if (map[i, j] != map[i, j + l])
                            {
                                j = N;
                                l = L;
                            }
                        }
                        if (j == N)
                        {
                            count--;
                            continue;
                        }
                        for (int l = 0; l < L; l++)
                            hill[j + l] = true;
                    }
                    else
                    {
                        j = N;
                        count--;
                    }
                }
                cntH = map[i, j];
            }
        }
        Console.WriteLine(count);
    }
}