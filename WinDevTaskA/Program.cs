﻿using System;
using System.Collections.Generic;
using System.IO;

namespace WinDevTaskA
{
    public class Program
    {
        public static Dictionary<String, String> encoding_table_left = new Dictionary<String, String>()
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
        public static Dictionary<String, String> encoding_table_right = new Dictionary<String, String>()
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

        public static void Main(string[] args)
        {
            Line line = new Line();
            String data_path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\testdata1.txt";

            line.Data = File.ReadAllLines(data_path)[0];
            line.TranslateToBinary();

            line.ExtractLeftHand();
            line.ExtractRightHand();

            Console.WriteLine(line.TranslateLeftToNumeric() + " " + line.TranslateRightToNumeric());
        }
    }
}
