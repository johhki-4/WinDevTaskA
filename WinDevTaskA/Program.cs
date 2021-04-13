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
                line.Trim();
                Console.WriteLine("line: " + line);
                Extract_valid_data(line);
                foreach (Char ch in line) {
                    Console.WriteLine(ch);
                }

            }
        }

        //Left hand is (2,7) (2+7, 7) (2+7+7, 7) (2+7+7+7, 7) etc..
        static String Extract_valid_data(String line)
        {
            String left_guard = line.Substring(0, 3);
            String[] left_hand;
            String center_guard = line.Substring(44, 5);
            String[] right_hand;
            String right_guard = line.Substring(line.Length-3, 3);
            Console.WriteLine("line start:" + left_guard + "-" + center_guard + "-" + right_guard + ".");
            return left_guard;
        }
    }
}
