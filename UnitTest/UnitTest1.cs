using NUnit.Framework;
using System;
using System.IO;
using WinDevTaskA;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //If we only extract data for the left side, the right side should be empty
        [Test]
        public void ExtractDataTest1()
        {
            Line line = new Line();
            String data_path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString()) + "\\WinDevTaskA\\testdata1.txt";
            line.Data = File.ReadAllLines(data_path)[0];
            line.TranslateToBinary();

            line.ExtractLeftHand();

            Assert.IsNotNull(line.LeftHand);
            Assert.IsNull(line.RightHand);
        }

        //If we extract data for both left and right side, they will not be empty
        [Test]
        public void ExtractDataTest2()
        {
            Line line = new Line();
            String data_path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString()) + "\\WinDevTaskA\\testdata1.txt";
            line.Data = File.ReadAllLines(data_path)[0];
            line.TranslateToBinary();

            line.ExtractLeftHand();
            line.ExtractRightHand();

            Assert.IsNotNull(line.LeftHand);
            Assert.IsNotNull(line.RightHand);
        }

        //Make sure that the answer is correct. 
        [Test]
        public void DesiredResultTest()
        {
            Line line = new Line();
            String data_path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString()) + "\\WinDevTaskA\\testdata1.txt";
            line.Data = File.ReadAllLines(data_path)[0];
            line.TranslateToBinary();
            line.ExtractLeftHand();
            line.ExtractRightHand();

            Assert.AreEqual(line.TranslateLeftToNumeric(), "0 51000");
            Assert.AreEqual(line.TranslateRightToNumeric(), "01251 7");
        }

        //Make sure that the total length of the initial data is correct. 
        [Test]
        public void DataLengthTest()
        {
            Line line = new Line();
            String data_path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString()) + "\\WinDevTaskA\\testdata1.txt";
            line.Data = File.ReadAllLines(data_path)[0];

            Assert.AreEqual(line.Data.Length, 95);
        }
    }
}