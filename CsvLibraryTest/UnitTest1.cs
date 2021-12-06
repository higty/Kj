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
            var ss = reader.ReadLine("�c��,21,�����s�`��");

            Assert.Equal(3, ss.Length);
            Assert.Equal("�c��", ss[0]);
            Assert.Equal("21", ss[1]);
            Assert.Equal("�����s�`��", ss[2]);
        }
    }
}
