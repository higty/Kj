import { $ } from "../../js/HtmlElementQuery.js";
export class Page {
    initialize() {
        //追加ボタンがクリックされた時のイベントハンドラーの登録
        $("#SaveButton").click(this.saveButton_Click.bind(this));
        $("[name='Price']").keydown(this.priceTextBox_Keydown.bind(this));
        //$("body").on("keydown", "[name='Price']", this.priceTextBox_Keydown1.bind(this))
    }
    saveButton_Click(e) {
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
    }
    priceTextBox_Keydown(e) {
        $("#KeyCodePanel").setInnerText(e.keyCode.toString());
    }
}
const page = new Page();
page.initialize();
//# sourceMappingURL=Add.js.map