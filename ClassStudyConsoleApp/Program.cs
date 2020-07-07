using System;

namespace ClassStudyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //C#命名規則
            //クラス
            //フィールド
            //インスタンス
            //メソッド
            //コンストラクタ
            //プロパティ
            //アクセッサ―
            //継承
            //
            //コンピューター。HD、メモリ、CPU、画面
           
            //入力が簡単になる。（IDEのおかげ）
            //使用する項目をグループ化できる。
            var p = new Person();
            p.Name = "Hig";
            p.HomeTown = "福岡";
            p.Number = "1234";
            p.OrganizationName = "機械部";
            p.PositionName = "課長";
            p.ShowName();
            //Console.WriteLine(p.Name + "です。" + p.HomeTown + "生まれです。");

            var p1 = new Person();
            p1.Name = "Komii";
            p1.HomeTown = "北海道";
            p1.Number = "3306";
            p1.OrganizationName = "機械部";
            p1.PositionName = "部長";
            p1.ShowName();


            Console.ReadLine();
        }
    }
}
