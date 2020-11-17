using System;
using System.Collections.Generic;
using System.Text;

namespace DbAccessWpfApp6
{
    public class DumpCar : Car
    {
        public DumpCar(String name)
        {
            this.Name = name;
        }
        public override String GetPicture()
        {
            return @"
  
　　　　　 ＿＿＿＿＿__.＿＿.__ 
　　　 , '""――――‐ , '""――ヽ`i:1 
 ./ ∧＿∧　　 .//~￣￣l.|.|::| | 
　　..i （・∀・ ）　　.i! i |.|::| |
.[;]__!_っ⌒'と　）.0[;]l |.　r‐_,.-'.. |.|:| :|＿＿＿＿＿＿＿n＿＿＿＿n

 ~l､二二二二二ノi.'ｰ''""~.....__.|.i:| :|lｰ‐―i iｰ‐―i iｰ‐―i iｰ‐―l　i| 
. .li:-.., ＿＿_ ,..-:iｺ..::＿_~_!i_ | __ | l＿＿!_!＿＿!_!＿＿!_!＿＿l__! |
  l!＿} ≡≡ {＿」;i..::' /⌒ヽヽll::!=ｲ二li,:''""⌒)二/＿/ ⌒ヽヽ(ﾆ(] 
.　 {i=i::l=[二]=l::i=i::｣　 |i.（*）.i;;;;|:lii□□:l`ｰ-''"";:::::|;;;;;;|ii.（*） i;;;| 
　　￣￣ゞ三ノ￣￣￣ゞ＿ノ￣　 ￣ゞゞ三ノ ~ ￣ゞゞ＿ノ ~ ≡3         ";
        }
    }
}
