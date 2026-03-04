

class Bod {
    constructor(x, y) {
        this.x = x;
        this.y = y;

        this.element = document.createElement("div");
        document.body.appendChild(this.element);

        this.element.classList.add("bod");

        const style = getComputedStyle(this.element);
        const velikost = parseFloat(style.width);

        this.posunuti = velikost / 2;

        this.vykresliBod();

        this.element.addEventListener("mousedown", () => {
            this.element.style.cursor = "grabbing";

            document.addEventListener("mousemove", this.pohybMysi);
            document.addEventListener("mouseup", this.pustenaMys);
        })
    }

    vykresliBod = () => {
        this.element.style.left = this.x - this.posunuti + "px";
        this.element.style.top = this.y + "px";
    }

    pohybMysi = (event) => {
        this.x = event.clientX;
        this.y = event.clientY;
        this.vykresliBod();
        trojuhelnik.vykresliTrojuhelnik();
    }

    pustenaMys = () => {
        document.removeEventListener("mousemove", this.pohybMysi);
        document.removeEventListener("mouseup", this.pustenaMys);
        this.element.style.cursor = "grab";
    }
}

class Trojuhelnik {
    constructor(a, b, c) {
        this.a = a;
        this.b = b;
        this.c = c;

        this.element = document.createElement("div");
        document.body.appendChild(this.element);
        this.element.classList.add("trojuhelnik");

        this.vykresliTrojuhelnik();
    }

    vykresliTrojuhelnik = () => {
        this.element.style.clipPath = `polygon(${this.a.x}px ${this.a.y}px, ${this.b.x}px ${this.b.y}px, ${this.c.x}px ${this.c.y}px)`;
    }
}

const a = new Bod(100, 200);
const b = new Bod(300, 50);
const c = new Bod(500, 250);

const trojuhelnik = new Trojuhelnik(a, b, c);
