using System;
using System.IO;

namespace WinDevTaskA
{
    class Program
    {
        static void Main(string[] args)
        {
            String data_path = Directory.GetCurrentDirectory() + "\\testdata1.txt";
            String[] data = File.ReadAllLines(data_path);

            foreach (String line in data) {
                Console.WriteLine("line: " + line);
            }
        }
    }
}
