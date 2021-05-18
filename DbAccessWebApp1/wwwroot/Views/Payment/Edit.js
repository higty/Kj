import { $ } from "../../js/HtmlElementQuery.js";
import { HttpClient } from "../../js/HttpClient.js";
export class Page {
    initialize() {
        //編集ボタンがクリックされた時のイベントハンドラーの登録
        $("#SaveButton").click(this.saveButton_Click.bind(this));
        $("#DeleteButton").click(this.deleteButton_Click.bind(this));
    }
    saveButton_Click(e) {
        const p = {
            PaymentCD: $("[name='PaymentCD']").getValue(),
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
        HttpClient.postJson("/Api/Payment/Edit", p, this.addPaymentCallback.bind(this), this.errorCallback.bind(this));
    }
    deleteButton_Click(e) {
        const p = {
            PaymentCD: $("[name='PaymentCD']").getValue(),
        };
        HttpClient.postJson("/Api/Payment/Delete", p, this.addPaymentCallback.bind(this), this.errorCallback.bind(this));
    }
    addPaymentCallback(response) {
        //サーバーの処理が終わった後に呼ばれるメソッド
        location.href = "/Payment/List";
    }
    errorCallback(response) {
        alert("入力値にエラーがあります。");
    }
}
const page = new Page();
page.initialize();
//# sourceMappingURL=Edit.js.map