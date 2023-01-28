using System;
using System.IO;
class Program
{
    static double T, C;
    static BufferedStream bs = new BufferedStream(Console.OpenStandardOutput());
    static StreamWriter sw = new StreamWriter(bs);
    static void Main()
    {
        T = int.Parse(Console.ReadLine());
        for (int i = 0; i < T; i++)
        {
            C = int.Parse(Console.ReadLine());
            sw.WriteLine(C * C);
        }
        sw.Close();
    }
}