using System;
using System.Collections.Generic;
using System.Text;

namespace DbAccessWpfApp6
{
    public class Bulldozer : Car
    {
        public Bulldozer(String name)
        {
            this.Name = name;
        }
        public override String GetPicture()
        {
            return @"
　　　 ∧∧　 ズゴゴ…
　　　( ･∀)　＿＿
　　／( ⊃¶／　／[)
　∠／｜ |∠＿／ ｜ _
　L_L_(＿/＿＿[)∠／/
`∠∠∠∠∠∠／)／　L_
(◎ ◎ ◎ ◎)∠/　　／
=＼◎ ◎ ◎／==L＿／
";
        }
    }
}
