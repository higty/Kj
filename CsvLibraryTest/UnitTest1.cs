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
        [Fact]
        public void Test2()
        {
            var reader = new CsvReader();
            var lines = reader.Read(@"�c��,21,�����s�`��
���,22,�����s�V�h��");

            var line0 = lines[0];
            Assert.Equal(3, line0.Length);
            Assert.Equal("�c��", line0[0]);
            Assert.Equal("21", line0[1]);
            Assert.Equal("�����s�`��", line0[2]);

            var line1 = lines[1];
            Assert.Equal(3, line1.Length);
            Assert.Equal("���", line1[0]);
            Assert.Equal("22", line1[1]);
            Assert.Equal("�����s�V�h��", line1[2]);
        }
    }
}
