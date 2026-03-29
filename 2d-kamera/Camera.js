import { Viewport } from './Viewport'
import { Scene } from './Scene'
import { MovableObject } from './MovableObject';

export class Camera {

    constructor() {
        this.viewport = new Viewport(document.body);
        this.scena = new Scene(this.viewport.element);

        this.tlacitko = document.createElement("button");
        this.tlacitko.style.left = 100 + "px";
        this.tlacitko.style.top = 100 + "px";
        this.tlacitko.textContent = "Pridej objekt";
        this.tlacitko.style.zIndex = 1;
        this.viewport.element.appendChild(this.tlacitko);


        this.stisknutaMys = false;
        this.x = 0;
        this.y = 0;

        this.tlacitko.addEventListener("click", ()=>{
            new MovableObject(this.scena.element, true);
        })

        this.scena.element.addEventListener("mousedown", () => {
            this.stisknutaMys = true;
            this.scena.element.style.cursor = "grabbing";
        })
        window.addEventListener("mouseup", () => {
            this.stisknutaMys = false;
            this.scena.element.style.cursor = "grab";
            
        })
        this.scena.element.addEventListener("mousemove", (e) => {
            if(this.stisknutaMys){
                this.x += e.movementX;
                this.y += e.movementY;
                this.scena.element.style.transform = `translate(${this.x}px, ${this.y}px)`;
            }
            
        })
    }
}