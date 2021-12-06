using CsvLibrary;
using System;
using Xunit;

namespace CsvLibraryTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var reader = new CsvReader();
            var ss = reader.ReadLine("“c’†,21,“Œ‹“s`‹æ");

            Assert.Equal(3, ss.Length);
            Assert.Equal("“c’†", ss[0]);
            Assert.Equal("21", ss[1]);
            Assert.Equal("“Œ‹“s`‹æ", ss[2]);
        }
        [Fact]
        public void Test2()
        {
            var reader = new CsvReader();
            //var s = "“c’†,21,“Œ‹“s`‹æ" + Environment.NewLine + "—é–Ø,22,“Œ‹“sVh‹æ";
            var rowList = reader.Read(@"“c’†,21,“Œ‹“s`‹æ
—é–Ø,22,“Œ‹“sVh‹æ");

            var line0 = rowList[0];
            Assert.Equal(3, line0.Length);
            Assert.Equal("“c’†", line0[0]);
            Assert.Equal("21", line0[1]);
            Assert.Equal("“Œ‹“s`‹æ", line0[2]);

            var line1 = rowList[1];
            Assert.Equal(3, line1.Length);
            Assert.Equal("—é–Ø", line1[0]);
            Assert.Equal("22", line1[1]);
            Assert.Equal("“Œ‹“sVh‹æ", line1[2]);
        }
    }
}
