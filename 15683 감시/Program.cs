using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int N, M;
    static int[] bruteforce;
    static List<int[]> office = new List<int[]>();
    static List<int[]> camera = new List<int[]>();
    static List<int[]> rotate = new List<int[]>();
    // 각 카메라별로 회전하면서 방을 비추는 형태를 저장하고
    // 회전 상태의 방 평면도를 모두 겹쳐서 전부 0인 지점만 세기
    static void Main()
    {
        string[] nm = Console.ReadLine().Split();
        N = int.Parse(nm[0]); M = int.Parse(nm[1]);
        for(int i = 0; i < N; i++)
        {
            office.Add(Console.ReadLine().Split().Select(int.Parse).ToArray());
            for (int j = 0; j < M; j++)
            {
                if (office[i][j] > 0 && office[i][j] < 6)
                {
                    camera.Add(new int[]{office[i][j], i, j});
                }
            }
        }
        bruteforce = new int[camera.Count];
        BF(0);
        Console.WriteLine();
    }
    static int scan(int[,] view)
    {
        bool[,] sight = new bool[N, M];
        for (int i = 0; i < N; i++)
            for (int j = 0; j < M; j++)
                sight[i, j] = (office[i][j] == 0) ? false : true;

        for(int i = 0; i < bruteforce.Length; i++)
        {
            switch (camera[i][0])
            {
                case 1:

                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }

        int blindspot = 0;
        for(int i = 0; i < N; i++)
            for(int j = 0; j < M; j++)
                if (view[i, j] == 0) blindspot++;
        return blindspot;
    }
    static void BF(int d)
    {
        if (d == bruteforce.Length)
        {
            int[] ca = new int[d];
            for (int i = 0; i < d; i++)
                ca[i] = bruteforce[i];
            rotate.Add(ca);
            return;
        }
        int c;
        if (camera[d][0] == 2) c = 2;
        else if (camera[d][0] == 5) c = 1;
        else c = 4;
        for(int i = 0; i < c; i++)
        {
            bruteforce[d] = i;
            BF(d+1);
        }
    }
}