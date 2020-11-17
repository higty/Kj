using System;

namespace DbAccessWpfApp6
{
    class Program
    {
        /// <summary>
        /// プロパティ、メソッド、イベントなどを子クラスで再利用できる
        /// 親クラスの変数に子クラスのインスタンスを代入できる
        /// virtaul method(仮想メソッド)は子クラスでoverrideできる許可を付与する
        /// overrideすると変数に代入したインスタンスのクラスのメソッドの方を呼べる
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var carList = new Car[4];

            carList[0] = new DumpCar("ダンプ1");
            carList[1] = new Bulldozer("ブルドーザー2");
            carList[2] = new Roller("ローラー3");
            carList[3] = new BackHoeCar("バックフォー");

            for (int i = 0; i < carList.Length; i++)
            {
                Console.WriteLine("名前は" + carList[i].Name);
                Console.WriteLine(carList[i].GetPicture());
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            }
            Console.ReadLine();

            //「リファクタリング」をしましょう。
            //デザインパターン
        }
        private static void Parent_Child_Sample()
        {
            var p = new Parent();
            p.Name = "鈴木";
            Console.WriteLine(p.Name);
            Console.ReadLine();

            Child c = new Child();
            c.Name = "田中";


            //親クラスの変数に子クラスのインスタンスを代入できる
            Parent c1 = new Child();
            c1.Name = "高橋";
        }
    }
}
