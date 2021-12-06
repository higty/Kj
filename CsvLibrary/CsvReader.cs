using System;
using System.Collections.Generic;

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
            var lines = bodyText.Split("\n");
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Trim();
            }
            
            var rowList = new List<String[]>();
            //rowList.Add(new string[] { "田中", "21", "東京都港区" });
            foreach (var line in lines)
            {
                var vv = line.Split(',');
                rowList.Add(vv);
            }
            return rowList.ToArray();
        }
    }
}
