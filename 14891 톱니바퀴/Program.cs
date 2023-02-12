using System;

class Program
{
    static int K, G, score;
    static int[] flag = { 0, 0, 0, 0 };
    static int[] wise = new int[4];
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
        K = int.Parse(Console.ReadLine());
        for(int i = 0; i < K; i++)
        {
            string[] t = Console.ReadLine().Split();
            G = int.Parse(t[0]) - 1;
            for (int j = 0; j < 4; j++) wise[j] = 0;
            wise[G] = int.Parse(t[1]);
            for(int j = 0; G + j < 3; j++)
            {
                int l = flag[G + j] + 2; if (l >= 8) l -= 8;
                int r = flag[G + j + 1] + 6; if (r >= 8) r -= 8;
                if (gear[G + j, l] != gear[G + j + 1, r]) wise[G + j + 1] = wise[G + j] * -1;
            }
            for(int j = 0; G - j > 0; j++)
            {
                int l = flag[G - j - 1] + 2; if (l >= 8) l -= 8;
                int r = flag[G - j] + 6; if (r >= 8) r -= 8;
                if (gear[G - j, r] != gear[G - j - 1, l]) wise[G - j - 1] = wise[G - j] * -1;
            }
            for(int j = 0; j < 4; j++)
            {
                flag[j] -= wise[j];
                if (flag[j] < 0) flag[j] += 8;
                else if (flag[j] >= 8) flag[j] -= 8;
            }
        }
        for(int i = 0; i < 4; i++)
            if (gear[i, flag[i]])
                score += (int)Math.Pow(2, i);
        Console.WriteLine(score);
    }
}