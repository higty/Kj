using System;
using System.Collections.Generic;
using System.Text;

namespace DbAccessWpfApp6
{
    public class Roller : Car
    {
        public Roller(String name)
        {
            this.Name = name;
        }
        public override String GetPicture()
        {
            return @"
　　　　　　　∧∧
　[]　　　/⌒(´∀)
　∥＿＿_(_)∪ ∪
/￣/ ＿＿/￣ヽ(_)
L＿L/EEE∥[二二[二]
|／・＼E∥ ／￣＼三＼
｜･○･ L∥｜=㊥=｜三｜
 ＼・／／￣＼＿／三／
￣￣￣￣￣￣￣￣￣￣￣";
        }
    }
}
