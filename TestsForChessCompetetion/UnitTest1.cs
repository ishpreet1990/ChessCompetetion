using System;
using Xunit;
using ChessCompetetion;
using System.IO;

namespace TestsForChessCompetetion
{
    public class UnitTest1
    {
        [Fact]
        public void ReadNameTest()
        {
            //act
            ReadMyFiles read = new ReadMyFiles();
            Stream stream = File.OpenRead(@"C:\Users\Administrator\Desktop\Case 1 - herkansing\Uitslagen 2017-01-03.txt");
            
            var reader = new StreamReader(stream);
            string titelline = reader.ReadLine();
            reader.ReadLine();
            reader.ReadLine();
            string readName = reader.ReadLine();
            Assert.Equal("Piet en Passant\t", readName);
        }
        [Fact]
        public void ReadScoreTest()
        {
            //act
            ReadMyFiles read = new ReadMyFiles();
            Stream stream = File.OpenRead(@"C:\Users\Administrator\Desktop\Case 1 - herkansing\Uitslagen 2017-01-03.txt");

            var reader = new StreamReader(stream);
            string titelline = reader.ReadLine();
            reader.ReadLine();
            reader.ReadLine();
            reader.ReadLine();
            reader.ReadLine();
            string readscore = reader.ReadLine();
            Assert.Equal("1 - 0\t", readscore);
        }
    }
}
