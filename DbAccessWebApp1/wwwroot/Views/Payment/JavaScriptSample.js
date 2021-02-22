//DOM Element (WPFで言うとコントロール)

//document.Panel1.Text = "";
const panel1 = document.getElementById("Panel1");
panel1.innerText = "Hello World!";
panel1.style["font-size"] = "80px";
panel1.style["color"] = "#ff0000";


//JavaScriptでDOM Elementの操作ができる。
//Attribute, Style, Class, Textとかを操作できる。
//WEBサーバーへリクエストを送る。
//JSON形式の文字列を操作する。

const button1 = document.getElementById("Button1");
button1.addEventListener("click", Button1_Click);
button1.addEventListener("mouseover", Button1_Mouseover);
button1.addEventListener("mouseout", Button1_Mouseout);

function Button1_Click() {
    for (var i = 0; i < 10; i++) {
        const span = document.createElement("span");
        span.classList.add("square-panel");

        const panel2 = document.getElementById("Panel2");
        panel2.appendChild(span);
    }
}
function Button1_Mouseover() {
    const button1 = document.getElementById("Button1");
    button1.style["font-size"] = "64px";
}
function Button1_Mouseout() {
    const button1 = document.getElementById("Button1");
    button1.style["font-size"] = "20px";

    //動的言語→型が無い→実行時にエラー
    //静的言語→型がある→コンパイル→エラー
    //堅牢なシステムを組みたい→静的言語
    var x = "test";
    x = 1;
}


const button2 = document.getElementById("Button2");
button2.addEventListener("click", Button2_Click);
function Button2_Click() {
    const textBox1 = document.getElementById("TextBox1");
    const text = textBox1.value;
    alert(text);
}






