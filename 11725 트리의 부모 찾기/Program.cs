using System;
using System.Collections.Generic;
class program
{
    static int N, a, b;
    static string[] input = new string[2];
    static Queue<int> edge = new Queue<int>();
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        int[,] nodes = new int[N, 2];
        int[] mother = new int[N];
        for (int i = 0; i < N - 1; i++)
        {
            input = Console.ReadLine().Split();
            nodes[i, 0] = int.Parse(input[0]) - 1;
            nodes[i, 1] = int.Parse(input[1]) - 1;
        }
        edge.Enqueue(0);
        while (edge.Count != 0)
        {
            for (int i = 0; i < N - 1; i++)
            {
                if (nodes[i, 0] == edge.Peek())
                {
                    mother[nodes[i, 1]] = edge.Peek();
                    edge.Enqueue(nodes[i, 1]);
                    nodes[i, 0] = -1; nodes[i, 1] = -1;
                }
                else if (nodes[i, 1] == edge.Peek())
                {
                    mother[nodes[i, 0]] = edge.Peek();
                    edge.Enqueue(nodes[i, 0]);
                    nodes[i, 0] = -1; nodes[i, 1] = -1;
                }
            }
            edge.Dequeue();
        }
        for (int i = 1; i < N; i++)
        {
            mother[i]++;
            Console.WriteLine(mother[i]);
        }
    }
}