using System;
using System.Reflection.Metadata;
using System.Text;
using System.IO;

namespace DbAccessConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMethodList.Method_Int32Plus();
        }
        static void File_Read()
        {
            String filePath = "C:\\Dev\\MyTextFile.txt";
            String body = System.IO.File.ReadAllText(filePath);
            Console.WriteLine(body);
            Console.ReadLine();
        }
        static void File_Write()
        {
            String filePath = "C:\\Dev\\MyTextFile.txt";
            File.WriteAllText(filePath, "中身を変えたよ！");
            Console.ReadLine();
        }
        static void File_Encoding()
        {
            var encoding = CodePagesEncodingProvider.Instance.GetEncoding(932);
            String filePath = "C:\\Dev\\MyTextFile.txt";
            String body = System.IO.File.ReadAllText(filePath, encoding);
            Console.WriteLine(body);
            File.WriteAllText(filePath, "中身を変えたよ！");
            Console.ReadLine();
        }
    }
}
