using System;
using System.Collections.Generic;
using System.Text;

namespace ClassStudyConsoleApp
{
    /// <summary>
    /// 社員のデータを表現するクラス
    /// 
    /// ■クラスのメリットその１
    /// 複数の値をグループ化できる
    /// 
    /// 
    /// </summary>
    class Person
    {
        public String Name = "";
        public String HomeTown = "";
        public String Number = "";
        public String OrganizationName = "";
        public String PositionName = "";

        public void ShowName()
        {
            Console.WriteLine("名前は" + this.Name + "です。");
        }
    }
}
