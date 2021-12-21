using CsvLibrary;
using System;
using System.IO;
using Xunit;

namespace CsvLibraryTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Row()
        {
            var reader = new CsvReader();
            var rowList = reader.Read("�c��,21,�����s�`��");
            var ss = rowList[0];

            Assert.Equal(3, ss.Length);
            Assert.Equal("�c��", ss[0]);
            Assert.Equal("21", ss[1]);
            Assert.Equal("�����s�`��", ss[2]);
        }
        [Fact]
        public void Test_FromFile()
        {
            var reader = new CsvReader();
            //var s = "�c��,21,�����s�`��" + Environment.NewLine + "���,22,�����s�V�h��";           
            var filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "Csv", "CsvSample.csv");
            var bodyText = File.ReadAllText(filePath);
            var rowList = reader.Read(bodyText);

            var line0 = rowList[0];
            Assert.Equal(3, line0.Length);
            Assert.Equal("�c��", line0[0]);
            Assert.Equal("21", line0[1]);
            Assert.Equal("�����s�`��", line0[2]);

            var line1 = rowList[1];
            Assert.Equal(3, line1.Length);
            Assert.Equal("���", line1[0]);
            Assert.Equal("22", line1[1]);
            Assert.Equal("�����s�V�h��", line1[2]);
        }
        [Fact]
        public void Test_FromFile_DoubleQuatation()
        {
            var reader = new CsvReader();
            //var s = "�c��,21,�����s�`��" + Environment.NewLine + "���,22,�����s�V�h��";           
            var filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "Csv", "CsvSample_DoubleQuatation.csv");
            var bodyText = File.ReadAllText(filePath);
            var rowList = reader.Read(bodyText);

            var line0 = rowList[0];
            Assert.Equal(3, line0.Length);
            Assert.Equal("�c��", line0[0]);
            Assert.Equal("21", line0[1]);
            Assert.Equal("�����s�`��", line0[2]);

            var line1 = rowList[1];
            Assert.Equal(3, line1.Length);
            Assert.Equal("���", line1[0]);
            Assert.Equal("22", line1[1]);
            Assert.Equal("�����s�V�h��", line1[2]);
        }
        [Fact]
        public void Test_FromFile_DoubleQuatation_WithNewLine()
        {

            var reader = new CsvReader();
            //var s = "�c��,21,�����s�`��" + Environment.NewLine + "���,22,�����s�V�h��";           
            var filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "Csv", "CsvSample_DoubleQuatation_WithNewLine.csv");
            var bodyText = File.ReadAllText(filePath);
            var rowList = reader.Read(bodyText);

            var line0 = rowList[0];
            Assert.Equal(3, line0.Length);
            Assert.Equal("�c��", line0[0]);
            Assert.Equal("21", line0[1]);
            Assert.Equal("�����s\r\n�`��", line0[2]);

            var line1 = rowList[1];
            Assert.Equal(3, line1.Length);
            Assert.Equal("���", line1[0]);
            Assert.Equal("22", line1[1]);
            Assert.Equal("�����s�V�h��", line1[2]);
        }
    }
}
