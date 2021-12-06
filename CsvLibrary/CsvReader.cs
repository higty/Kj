using System;

namespace CsvLibrary
{
    public class CsvReader
    {
        public String[] ReadLine(String line)
        {
            return line.Split(',');
        }
        public String[][] Read(String bodyText)
        {
            return null;
        }
    }
}
