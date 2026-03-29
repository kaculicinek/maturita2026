import { Usecka } from "./Usecka";
import { Vrchol } from "./Vrchol";

export class Trojuhelnik {
    constructor() {
        this.trojuhelnik = document.getElementById("trojuhelnik");

        this.vrchol1 = new Vrchol(100, 200, this.trojuhelnik, () => this.callback());
        this.vrchol2 = new Vrchol(200, 300, this.trojuhelnik, () => this.callback());
        this.vrchol3 = new Vrchol(300, 50, this.trojuhelnik, () => this.callback()); 

        this.usecka1 = new Usecka(this.vrchol1, this.vrchol2, this.trojuhelnik);
        this.usecka2 = new Usecka(this.vrchol2, this.vrchol3, this.trojuhelnik);
        this.usecka3 = new Usecka(this.vrchol3, this.vrchol1, this.trojuhelnik);
 
    }

    callback(){
        this.usecka1.zmenSouradnice();
        this.usecka2.zmenSouradnice();
        this.usecka3.zmenSouradnice();
    }
}
