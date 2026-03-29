export class MovableObject {
    constructor(parent, jeZTlacitka) {
        this.element = document.createElement("div");
        this.element.classList.add("movableObject");
        parent.appendChild(this.element);

        this.element.style.cursor = "grab";

        this.stisknuto = false;
        this.x = 0; 
        this.y = 0;

        if(jeZTlacitka){
            this.stisknuto = true;

        }
        else{
            this.x = Math.random() * (parent.clientWidth - this.element.clientWidth);
            this.y = Math.random() * (parent.clientHeight - this.element.clientHeight);
        }

        this.vykresliObj();

        this.element.addEventListener("mousedown", (e) => {
            e.stopPropagation();
            e.preventDefault();
            this.stisknuto = true;
            this.element.style.cursor = "grabbing";
        })

        window.addEventListener("mousemove", (e) => {
            if (this.stisknuto) {
                this.x += e.movementX;
                this.y += e.movementY;
                this.vykresliObj();
            }
        })
        window.addEventListener("mouseup", (e) => {
            this.stisknuto = false;
            this.element.style.cursor = "grab";
        })
    }

    vykresliObj() {
        this.element.style.left = this.x + "px";
        this.element.style.top = this.y + "px";
    }
}