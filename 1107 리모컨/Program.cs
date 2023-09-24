using System;
using System.Collections.Generic;

class program
{
    static int ch = 100;
    static int N, M, near, up, down;
    static int[] click = new int[4];
    static List<int> button = new List<int>();
    static List<int> channel = new List<int>();
    static void Main()
    {
        while (true)
        {
            button.Clear();
            channel.Clear();
            for (int i = 0; i < 4; i++) click[i] = 0;

            N = int.Parse(Console.ReadLine());
            M = int.Parse(Console.ReadLine());
            for (int i = 0; i < 10; i++) button.Add(i);
            if (M > 0)
            {
                string[] broken = Console.ReadLine().Split();
                foreach (string s in broken) button.Remove(int.Parse(s));
            }
            channel.Add(N);

            int digit = N.ToString().Length;
            int square = 1;

            // 근사값 만들기
            int btn = button.Count;
            int low = 0; int high = 0;
            if (btn > 0)
            {
                low = button[0];
                high = button[btn - 1];
            }
            int[] compare = new int[btn];
            for (int i = 0; i < digit - 1; i++) square *= 10;
            for (int i = 0; i < 4; i++) click[i] = 0;

            near = ch;
            up = ch;
            down = ch;

            if (btn > 0)
            {
                while (square > 0)
                {
                    for (int i = 0; i < btn; i++) compare[i] += square * button[i];
                    for (int i = 0; i < btn; i++)
                    {
                        if (compare[i] > N)
                        {
                            if (i > 0)
                            {
                                int j = 1;
                                for (; j < square; j = 10 * j + 1) ;
                                j /= 10;
                                int least = compare[i - 1] + j * high;
                                int most = compare[i] + j * low;
                                if (N - least < most - N)
                                {
                                    for (int k = 0; k < btn; k++)
                                        compare[k] = compare[i - 1];
                                }
                                else
                                {
                                    for (int k = 0; k < btn; k++)
                                        compare[k] = compare[i];
                                }
                            }
                            else
                            {
                                for (int k = 0; k < btn; k++)
                                    compare[k] = compare[0];
                            }
                            break;
                        }
                        else if (i == btn - 1)
                        {
                            for (int k = 0; k < btn; k++)
                                compare[k] = compare[i];
                        }
                    }
                    square /= 10;
                }
                near = compare[0];
                click[1] = digit;

                if (btn > 1)
                {
                    up = button[1];
                    for (int i = 0; i < digit; i++)
                        up = 10 * up + button[0];
                    click[2] = digit + 1;
                }
                else if (button[0] != 0)
                {
                    up = button[0];
                    for (int i = 0; i < digit; i++)
                        up = 10 * up + button[0];
                    click[2] = digit + 1;
                }

                if (button[btn - 1] != 0)
                {
                    down = button[btn - 1];
                    for (int i = 2; i < digit; i++)
                        down = 10 * down + button[btn - 1];
                    click[3] = digit - 1;
                }

            }

            click[0] += Math.Max(ch, N) - Math.Min(ch, N);
            click[1] += Math.Max(near, N) - Math.Min(near, N);
            click[2] += Math.Max(up, N) - Math.Min(up, N);
            click[3] += Math.Max(down, N) - Math.Min(down, N);

            Console.WriteLine(Math.Min(Math.Min(click[0], click[1]), Math.Min(click[2], click[3])));
        }
    }
}