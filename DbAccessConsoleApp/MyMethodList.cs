using System;
using System.Collections.Generic;
using System.Text;

namespace DbAccessConsoleApp
{
    class MyMethodList
    {
        public static void Method_Int32Plus()
        {
            Console.WriteLine("1個目の数字");
            Int32 x1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("2個目の数字");
            Int32 x2 = Int32.Parse(Console.ReadLine());
            Int32 x3 = x1 + x2;
            Console.WriteLine(x3.ToString());
            Console.ReadLine();
        }
        public static void Method_StringJoin()
        {
            Console.WriteLine("1個目の文字列");
            String c1 = Console.ReadLine();
            Console.WriteLine("2個目の文字列");
            String c2 = Console.ReadLine();

            Console.WriteLine(c1 + c2);
            Console.ReadLine();
        }
        public static void Method_Japanese()
        {
            Console.WriteLine("何か入力してください。");
            String line = Console.ReadLine();
            Console.WriteLine("あなたの入力＝" + line);

            Console.ReadLine();
        }
        public static void Method_English()
        {
            Console.WriteLine("Please input...");
            String line = Console.ReadLine();
            Console.WriteLine("Your input=" + line);

            Console.ReadLine();
        }
    }
}
