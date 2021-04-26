import { $ } from "../../js/HtmlElementQuery.js";
import { HttpClient } from "../../js/HttpClient.js";
export class Page {
    initialize() {
        //追加ボタンがクリックされた時のイベントハンドラーの登録
        $("#SaveButton").click(this.saveButton_Click.bind(this));
        $("[name='Price']").keydown(this.priceTextBox_Keydown.bind(this));
        //$("body").on("keydown", "[name='Price']", this.priceTextBox_Keydown1.bind(this))
    }
    priceTextBox_Keydown(e) {
        $("#KeyCodePanel").setInnerText(e.keyCode.toString());
    }
    saveButton_Click(e) {
        const p = {
            Title: $("[name='Title']").getValue(),
            Date: $("[name='Date']").getValue(),
            Price: $("[name='Price']").getValue(),
        };
        //ID #MyID
        //Class .my-class
        //Attribtue [my-attribute]
        //Attribtue&Value [my-attribute='']
        //オブジェクトpをJSON形式でサーバーへ送信する
        //BSONとJSON
        //↓JSONのメリットとデメリット
        //可読性
        //デバッグしづらい
        //ネットでたくさん検索結果がある
        //ちょっと遅い
        HttpClient.postJson("/Api/Payment/Add", p, this.addPaymentCallback.bind(this));
    }
    addPaymentCallback(response) {
        //サーバーの処理が終わった後に呼ばれるメソッド
        location.href = "/Payment/List";
    }
}
const page = new Page();
page.initialize();
//# sourceMappingURL=Add.js.map