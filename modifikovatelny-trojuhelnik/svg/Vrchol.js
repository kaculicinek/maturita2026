export class Vrchol{
    constructor(x, y, parent, callback){
        this.x = x;
        this.y = y;
        this.r = 15;
        

        this.element = document.createElementNS("http://www.w3.org/2000/svg", "circle");
        this.element.style.cursor = "grab";
        this.nastavAVykresliBod();

        parent.appendChild(this.element);
        this.stisknuto = false;

        this.element.addEventListener("mousedown", () => {
            this.stisknuto = true;
            this.element.style.cursor = "grabbing";
        })

        window.addEventListener("mouseup", () => {
            this.stisknuto = false;
            this.element.style.cursor = "grab";
        })

        window.addEventListener("mousemove", (e) => {
            if(this.stisknuto){
                this.x = e.clientX;
                this.y = e.clientY;
                this.nastavAVykresliBod();
                callback();
            };
        })
    }

    nastavAVykresliBod(){
        this.element.setAttribute("cx", this.x);
        this.element.setAttribute("cy", this.y);
        this.element.setAttribute("r", this.r);

    }
}