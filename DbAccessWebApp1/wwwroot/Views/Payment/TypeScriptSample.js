import { $ } from "../../js/HtmlElementQuery.js";
class Person {
    constructor() {
        this.name = "";
    }
    initialize() {
        $("#Button1").click(this.Button1_Click.bind(this));
        $("#Button2").click(this.Button2_Click.bind(this));
    }
    showName() {
        alert(this.name);
    }
    Button1_Click() {
        this.name = $("#TextBox1").getValue();
        this.showName();
    }
    Button2_Click() {
        $(".text1").setStyle("background-color", "#c000c0");
        $(".text1").setStyle("color", "#ffffff");
        $(".text1").setStyle("padding", "10px");
    }
}
class Car {
    constructor() {
        this.name = "";
    }
    sample() {
        var o = {}; //なんでも代入可能
        o = 1;
        const c = "再代入が不可";
        //c = "test";
        let x = 2;
        x = 3; //再代入が可能
    }
}
const p = new Person();
p.initialize();
//# sourceMappingURL=TypeScriptSample.js.map