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
        public List<String[]> Read(String bodyText)
        {
            //行ごとに分割
            var lines = bodyText.Split("\n");
            //\r（文字コード13の改行コードを消す）
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Trim();
            }
            
            //各行をカンマ区切りで分割
            var rowList = new List<String[]>();
            //rowList.Add(new string[] { "田中", "21", "東京都港区" });
            foreach (var line in lines)
            {
                var vv = line.Split(',');
                rowList.Add(vv);
            }
            return rowList;
        }
    }
}
