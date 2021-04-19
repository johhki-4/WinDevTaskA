using System;
using System.Collections.Generic;
using System.IO;

namespace WinDevTaskA
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Line line = new Line();
            String data_path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()) + "\\testdata1.txt";

            //In this case, there is only one entry barcode. If it should handle more in the future, this needs to be changed.
            line.Data = File.ReadAllLines(data_path)[0];
            line.TranslateToBinary();

            // filter out some "noise" in the form of left/center/right guards.
            line.ExtractLeftHand();
            line.ExtractRightHand();

            //The decoded barcode in the correct structure.
            Console.WriteLine(line.TranslateLeftToNumeric() + " " + line.TranslateRightToNumeric());
        }
    }
}
