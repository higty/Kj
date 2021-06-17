import { $ } from "../../js/HtmlElementQuery.js";
import { HttpClient, HttpResponse } from "../../js/HttpClient.js";

type EditMode = "Add" | "Edit";

export class Page {
    public EditMode: EditMode = "Add";

    public initialize() {
        if ($("[name='EditMode']").getValue() == "Add") {
            this.EditMode = "Add";
        }
        else if ($("[name='EditMode']").getValue() == "Edit") {
            this.EditMode = "Edit";
        }
        //保存ボタンがクリックされた時のイベントハンドラーの登録
        $("#SaveButton").click(this.saveButton_Click.bind(this));
        $("#DeleteButton").click(this.deleteButton_Click.bind(this));
    }

    private saveButton_Click(e: Event) {
        const p = {
            PaymentCD: $("[name='PaymentCD']").getValue(),
            Title: $("[name='Title']").getValue(),
            Date: $("[name='Date']").getValue(),
            Price: $("[name='Price']").getValue(),
        };

        switch (this.EditMode) {
            case "Add":
                HttpClient.postJson("/Api/Payment/Add", p
                    , this.addPaymentCallback.bind(this), this.errorCallback.bind(this));
                break;
            case "Edit":
                HttpClient.postJson("/Api/Payment/Edit", p
                    , this.addPaymentCallback.bind(this), this.errorCallback.bind(this));
                break;
            default:
        }
    }
    private deleteButton_Click(e: Event) {
        const p = {
            PaymentCD: $("[name='PaymentCD']").getValue(),
        };
        HttpClient.postJson("/Api/Payment/Delete", p
            , this.addPaymentCallback.bind(this), this.errorCallback.bind(this));
    }
    private addPaymentCallback(response: HttpResponse) {
        //サーバーの処理が終わった後に呼ばれるメソッド
        location.href = "/Payment/List";
    }
    private errorCallback(response: HttpResponse) {
        alert("入力値にエラーがあります。");
    }
}

const page = new Page();
page.initialize();

