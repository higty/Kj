import { $ } from "../../js/HtmlElementQuery.js";
import { HttpClient, HttpResponse } from "../../js/HttpClient.js";

export class Page {
    public initialize() {
        //追加ボタンがクリックされた時のイベントハンドラーの登録
        $("#SaveButton").click(this.saveButton_Click.bind(this));
        $("[name='Price']").keydown(this.priceTextBox_Keydown.bind(this));

        //$("body").on("keydown", "[name='Price']", this.priceTextBox_Keydown1.bind(this))
    }
    private priceTextBox_Keydown(e: KeyboardEvent) {
        $("#KeyCodePanel").setInnerText(e.keyCode.toString());
    }

    private saveButton_Click(e: Event) {
        const p = {
            DisplayName: $("[name='DisplayName']").getValue(),
            Date: $("[name='Date']").getValue(),
            Price: $("[name='Price']").getValue(),
        };

        //ID #MyID
        //Class .my-class
        //Attribtue [my-attribute]
        //Attribtue&Value [my-attribute='']

        //オブジェクトpをサーバーへ送信する
        HttpClient.postJson("/Api/Payment/Add", p, this.addPaymentCallback.bind(this));
    }
    private addPaymentCallback(response: HttpResponse) {
        //サーバーの処理が終わった後に呼ばれるメソッド
        alert("サーバーから戻ってきたよ");
    }
}

const page = new Page();
page.initialize();

