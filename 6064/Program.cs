using System;

class program
{
    static int T, M, N, x, y, L;

    static void Main()
    {
        T = int.Parse(Console.ReadLine());
        for(int i = 0; i < T; i++)
        {
            string[] testcase = Console.ReadLine().Split();
            M = int.Parse(testcase[0]);
            N = int.Parse(testcase[1]);
            x = int.Parse(testcase[2]);
            y = int.Parse(testcase[3]);
            
            L = Least(M, N);

            int a = 0; int b = 0;
            int X = x; int Y = y;

            // 부정방정식 해 찾기
            while (M * a + x != N * b + y)
            {
                if (M * a + x > N * b + y) b++;
                else a++;
                if (M * a + x > L || N * b + y > L) break;
            }
            if (M * a + x == N * b + y) Console.WriteLine(M * a + x);
            else Console.WriteLine(-1);
        }
    }

    static int Least(int x, int y)  // 최소공배수 구하기
    {
        int a = x; int b = y;
        while(a != b)
        {
            if (a > b) b += y;
            else a += x;
        }
        return a;
    }
}