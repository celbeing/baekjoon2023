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
        count = N * 2;  // 안되는 경우 1씩 깎기
        // check row
        for (int i = 0; i < N; i++)
        {
            int[] hill = new int[N];
            for (int j = 1; j < N; j++)
            {
                switch (map[i, j] - map[i, j - 1])
                {
                    case 0:
                        break;
                    case 1:     // j - 1 까지 L 칸 오르막
                        if (j - L >= 0)
                            for (int l = 1; l <= L; l++)
                                hill[j - l]++;
                        else
                        { j = N; hill[0] = 2; }
                        break;
                    case -1:    // j 부터 L 칸 내리막
                        if (j + L <= N)
                            for (int l = 0; l < L; l++)
                                hill[j + l]++;
                        else { j = N; hill[0] = 2; }
                        break;
                    default:
                        j = N;
                        hill[0] = 2;
                        break;
                }   
            }
            for (int k = 0; k < N; k++)
                if (hill[k] > 1) { count--; break; }
        }
        // check column
        for (int i = 0; i < N; i++)
        {
            int[] hill = new int[N];
            for (int j = 1; j < N; j++)
            {
                switch (map[j, i] - map[j - 1, i])
                {
                    case 0:
                        break;
                    case 1:     // j - 1 까지 L 칸 오르막
                        if (j - L >= 0)
                            for (int l = 1; l <= L; l++)
                                hill[j - l]++;
                        else
                        { j = N; hill[0] = 2; }
                        break;
                    case -1:    // j 부터 L 칸 내리막
                        if (j + L <= N)
                            for (int l = 0; l < L; l++)
                                hill[j + l]++;
                        else { j = N; hill[0] = 2; }
                        break;
                    default:
                        j = N;
                        hill[0] = 2;
                        break;
                }
            }
            for (int k = 0; k < N; k++)
                if (hill[k] > 1) { count--; break; }
        }
        Console.WriteLine(count);
    }
}