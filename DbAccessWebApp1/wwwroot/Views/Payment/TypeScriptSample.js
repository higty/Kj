var Person = /** @class */ (function () {
    function Person() {
        this.name = "";
    }
    Person.prototype.initialize = function () {
        document.getElementById("Button1").addEventListener("click", this.Button1_Click.bind(this));
    };
    Person.prototype.showName = function () {
        alert(this.name);
    };
    Person.prototype.Button1_Click = function () {
        var tx = document.getElementById("TextBox1");
        this.name = tx.value;
        this.showName();
    };
    return Person;
}());
var Car = /** @class */ (function () {
    function Car() {
        this.name = "";
    }
    Car.prototype.sample = function () {
        var o = {}; //なんでも代入可能
        o = 1;
        var c = "再代入が不可";
        //c = "test";
        var x = 2;
        x = 3; //再代入が可能
    };
    return Car;
}());
var p = new Person();
p.initialize();
//# sourceMappingURL=TypeScriptSample.js.map