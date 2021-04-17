using System;
using System.Collections.Generic;
using System.IO;

namespace WinDevTaskA
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            String data_path = Directory.GetCurrentDirectory() + "\\testdata1.txt";
            String[] data = File.ReadAllLines(data_path);
            var encoding_table_left = new Dictionary<String, String>()
            {
                {"0", "   || |"},
                {"1", "  ||  |"},
                {"2", "  |  ||"},
                {"3", " |||| |"},
                {"4", " |   ||"},
                {"5", " ||   |"},
                {"6", " | ||||"},
                {"7", " ||| ||"},
                {"8", " || |||"},
                {"9", "   | ||"}
            };
            var encoding_table_right = new Dictionary<String, String>()
            {
                {"0", "|||  | "},
                {"1", "||  || "},
                {"2", "|| ||  "},
                {"3", "|    | "},
                {"4", "| |||  "},
                {"5", "|  ||| "},
                {"6", "| |    "},
                {"7", "|   |  "},
                {"8", "|  |   "},
                {"9", "||| |  "}
            };

            foreach (String line in data) {
                line.Trim();
                
                var left_hand = ExtractLeftData(line);
                Console.WriteLine("left:");
                foreach (String code in left_hand)
                {
                    Console.WriteLine(code);
                    //TODO Send to function that translates each code to numeric
                    TranslateToNumeric(code, encoding_table_left);
                }
                Console.WriteLine();

                var right_hand = ExtractRightData(line);
                Console.WriteLine("Right:");
                foreach (String code in right_hand)
                {
                    Console.WriteLine(code);
                }

            }
        }

        //Left hand is (3,7) (3+7, 7) (3+7+7, 7) (3+7+7+7, 7) etc..
        static List<String> ExtractLeftData(String line)
        {
            //String left_guard = line.Substring(0, 3);
            var left_data = new List<String>();
            for (int i = 0; i < 6; i++)
            {
                left_data.Add(line.Substring(3 + (7 * i), 7));
            }
            //String center_guard = line.Substring(44, 5);
            //var right_hand = new List<String>();
            //for (int i = 0; i < 6; i++)
            //{
            //    right_hand.Add(line.Substring(50 + (7 * i), 7));
            //}
            //String right_guard = line.Substring(line.Length - 3, 3);
            //Console.WriteLine("line start:" + left_guard + "-" + center_guard + "-" + right_guard + ".");
            return left_data;
        }

        static List<String> ExtractRightData(String line)
        {
            var right_data = new List<String>();
            for (int i = 0; i < 6; i++)
            {
                right_data.Add(line.Substring(50 + (7 * i), 7));
            }
            return right_data;
        }

        public static String TranslateToNumeric(String code, Dictionary<String, String> table)
        {
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] != ' ')
                {
                    //code.Replace()
                }
            }


            String numeric = code;
            return numeric;
        }
    }
}
