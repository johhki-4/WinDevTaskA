using System;
using System.Collections.Generic;

public class Line
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
    public Line()
	{
	}

    public string Binary { get; set; }
    public string Data { get; set; }
    public string LeftHand { get; set; }
    public string RightHand { get; set; }

    public void ExtractLeftHand()
    {
        LeftHand = Binary.Substring(3, 42);
    }

    public void ExtractRightHand()
    {
        RightHand = Binary.Substring(50, 42);
    }

    public void TranslateToBinary()
    {
        Binary = Data.Replace(' ', '0');
        Binary = Binary.Replace('▍', '1');
    }

    public string TranslateLeftToNumeric()
    {
        string left_numeric = "";
        string temp = "";
        left_numeric = left_numeric + encoding_table_left[LeftHand.Substring(0, 7)] + " ";
        for (int i = 1; i < 6; i++)
        {
            temp = encoding_table_left[LeftHand.Substring((7 * i), 7)];
            left_numeric = left_numeric + temp;
        }
        return left_numeric;
    }
    public string TranslateRightToNumeric()
    {
        string right_numeric = "";
        for (int i = 0; i < 5; i++)
        {
            var temp = encoding_table_right[RightHand.Substring((7 * i), 7)];
            right_numeric = right_numeric + temp;
        }
        right_numeric = right_numeric + " " + encoding_table_right[RightHand.Substring((5 * 7), 7)];
        return right_numeric;
    }
}
