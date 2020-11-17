using System;

namespace DbAccessWpfApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            var carList = new Car[3];

            carList[0] = new DumpCar("ダンプ1");
            carList[1] = new Bulldozer("ブルドーザー2");
            carList[2] = new Roller("ローラー3");

            for (int i = 0; i < carList.Length; i++)
            {
                Console.WriteLine(carList[i].GetPicture());
            }
            Console.ReadLine();

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
