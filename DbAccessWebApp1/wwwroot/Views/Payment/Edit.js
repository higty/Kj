import { $ } from "../../js/HtmlElementQuery.js";
import { HttpClient } from "../../js/HttpClient.js";
export class Page {
    constructor() {
        this.EditMode = "Add";
    }
    initialize() {
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
    saveButton_Click(e) {
        const p = {
            PaymentCD: $("[name='PaymentCD']").getValue(),
            Title: $("[name='Title']").getValue(),
            Date: $("[name='Date']").getValue(),
            Price: $("[name='Price']").getValue(),
        };
        switch (this.EditMode) {
            case "Add":
                HttpClient.postJson("/Api/Payment/Add", p, this.addPaymentCallback.bind(this), this.errorCallback.bind(this));
                break;
            case "Edit":
                HttpClient.postJson("/Api/Payment/Edit", p, this.addPaymentCallback.bind(this), this.errorCallback.bind(this));
                break;
            default:
        }
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