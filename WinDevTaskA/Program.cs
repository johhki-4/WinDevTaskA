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
                {"0001101", "0"},
                {"0011001", "1"},
                {"0010011", "2"},
                {"0111101", "3"},
                {"0100011", "4"},
                {"0110001", "5"},
                {"0101111", "6"},
                {"0111011", "7"},
                {"0110111", "8"},
                {"0001011", "9"}
            };
            var encoding_table_right = new Dictionary<String, String>()
            {
                {"1110010", "0"},
                {"1100110", "1"},
                {"1101100", "2"},
                {"1000010", "3"},
                {"1011100", "4"},
                {"1001110", "5"},
                {"1010000", "6"},
                {"1000100", "7"},
                {"1001000", "8"},
                {"1110100", "9"}
            };

            foreach (String line in data) {
                string numeric_left = "";
                string numeric_right = "";

                //Left hand numeric values
                foreach (String code in ExtractLeftData(line))
                {
                    numeric_left = numeric_left + TranslateToNumeric(code, encoding_table_left);
                }
                
                //Right hand numeric values
                foreach (String code in ExtractRightData(line))
                {
                    numeric_right = numeric_right + TranslateToNumeric(code, encoding_table_right);
                }

                //Add whitespaces in the desired location and write to console
                Console.WriteLine(  numeric_left[0] + " " + numeric_left.Substring(1, 5) + " " + 
                                    numeric_right.Substring(0, 5) + " " + numeric_right[5]);
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
            code = code.Replace(' ', '0');
            code = code.Replace('▍', '1');
            return table[code];
        }
    }
}
