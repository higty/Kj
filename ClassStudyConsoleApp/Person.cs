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
    /// 必ずInitializeメソッドを呼ぶこと！！！
    /// 
    /// </summary>
    class Person
    {
        private Int32 _Age = 0;

        public String Name { get; set; }
        public String HomeTown { get; set; }
        public String Number { get; set; }
        public String OrganizationName { get; set; }
        public String PositionName { get; set; }
        public Int32 Age
        {
            get { return _Age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _Age = value;
            }
        }

        public Person(String name, Int32 age)
        {
            this.Name = name;
            this.Age = age;
        }

        public void Initialize(String name, Int32 age)
        {
            this.Name = name;
            this.Age = age;
        }
        public void ShowName()
        {
            Console.WriteLine("名前は" + this.Name + "です。"
                + this.Age + "歳です。");
        }
    }
}
