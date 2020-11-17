using System;
using System.Collections.Generic;
using System.Text;

namespace DbAccessWpfApp6
{
    public class Car
    {
        public String Name { get; set; }

        /// <summary>
        /// virtaul method(仮想メソッド)は子クラスでoverrideできる許可を付与する
        /// </summary>
        /// <returns></returns>
        public virtual String GetPicture()
        {
            return "親クラスのカーです";
        }
    }
}
