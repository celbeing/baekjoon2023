using System;

class program
{
    static int N, count, tmp;
    static int[,] board = new int[50, 50];

    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        for(int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();
            for(int j = 0; j < N; j++)
            {
                if (line[j] == 'C') board[i, j] = 1;
                else if (line[j] == 'P') board[i, j] = 2;
                else if (line[j] == 'Z') board[i, j] = 3;
                else board[i, j] = 4;
            }
        }
        count = 0;

        // 행 최대값 확인
        for(int i = 0; i < N; i++)
        {
            int line = 1;
            for(int j = 0; j < N -1; j++)
            {
                if (board[i, j] == board[i, j + 1]) line++;
                else line = 1;
                count = Math.Max(count, line);
            }
        }


        // 열 최대값 확인
        for (int i = 0; i < N; i++)
        {
            int line = 1;
            for (int j = 0; j < N - 1; j++)
            {
                if (board[j, i] == board[j + 1, i]) line++;
                else line = 1;
                count = Math.Max(count, line);
            }
        }

        // 행 변경
        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < N - 1; j++)
            {
                if (board[i, j] == board[i, j + 1]) continue;
                tmp = board[i, j]; board[i, j] = board[i, j + 1]; board[i, j + 1] = tmp;
                int line = 1;
                for(int k = 0; k < N - 1; k++)
                {
                    if (board[i, k] == board[i, k + 1]) line++;
                    else line = 1;
                    count = Math.Max(count, line);
                }
                line = 1;
                for(int k = 0; k < N -1; k++)
                {
                    if (board[k, j] == board[k + 1, j]) line++;
                    else line = 1;
                    count = Math.Max(count, line);
                }
                line = 1;
                for (int k = 0; k < N - 1; k++)
                {
                    if (board[k, j + 1] == board[k + 1, j + 1]) line++;
                    else line = 1;
                    count = Math.Max(count, line);
                }
                tmp = board[i, j]; board[i, j] = board[i, j + 1]; board[i, j + 1] = tmp;
            }
        }

        // 열 변경
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N - 1; j++)
            {
                if (board[j, i] == board[j + 1, i]) continue;
                tmp = board[j, i]; board[j, i] = board[j + 1, i]; board[j + 1, i] = tmp;
                int line = 1;
                for (int k = 0; k < N - 1; k++)
                {
                    if (board[k, i] == board[k + 1, i]) line++;
                    else line = 1;
                    count = Math.Max(count, line);
                }
                line = 1;
                for (int k = 0; k < N - 1; k++)
                {
                    if (board[j, k] == board[j, k + 1]) line++;
                    else line = 1;
                    count = Math.Max(count, line);
                }
                line = 1;
                for (int k = 0; k < N - 1; k++)
                {
                    if (board[j + 1, k] == board[j + 1, k + 1]) line++;
                    else line = 1;
                    count = Math.Max(count, line);
                }
                tmp = board[j, i]; board[j, i] = board[j + 1, i]; board[j + 1, i] = tmp;
            }
        }

        Console.WriteLine(count);
    }
}