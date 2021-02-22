class Person {
    public name = "";

    public initialize() {
        document.getElementById("Button1").addEventListener("click", this.Button1_Click.bind(this));
    }
    public showName() {
        alert(this.name);
    }
    private Button1_Click() {
        const tx = document.getElementById("TextBox1") as HTMLInputElement;
        this.name = tx.value;
        this.showName();
    }
}

class Car {
    public name = "";

    private sample() {
        var o = {};//なんでも代入可能
        o = 1;
        const c = "再代入が不可";
        //c = "test";
        let x = 2;
        x = 3;//再代入が可能
    }
}


const p = new Person();
p.initialize();
