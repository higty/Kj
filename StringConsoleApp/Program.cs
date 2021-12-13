using System;

namespace StringConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = " abcdefa   ";
            var s1 = s.Trim();
            var s2 = s.Replace("a", "b");
            var isStartA = s1.StartsWith("a");
            var isEndA = s1.EndsWith("a");
            var x1 = s1.IndexOf('c');
            var s3 = s.Substring(0, 2);

            var ss = new String[3];
            ss[0] = "abc";
            ss[1] = "def";
            ss[2] = "ghi";

            var ss1 = new String[3];
            for (int i = 0; i < ss.Length; i++)
            {
                ss1[i] = ss[i] + "x";
            }
            for (int i = 0; i < ss.Length; i++)
            {
                ss1[i] = ss[i].Replace("a", "");
            }
            var ss2 = new String[3];
            for (int i = 0; i < ss.Length; i++)
            {
                ss2[i] = ss[i].ToUpper();
            }

            Console.ReadLine();
        }
    }
}
