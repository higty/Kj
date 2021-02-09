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

function Button1_Click() {
    for (var i = 0; i < 10; i++) {
        const span = document.createElement("span");
        span.classList.add("square-panel");

        const panel2 = document.getElementById("Panel2");
        panel2.appendChild(span);
    }
}





