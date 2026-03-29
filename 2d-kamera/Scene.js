import { MovableObject } from "./MovableObject";

export class Scene{
    constructor(parent){
        this.element = document.createElement("div");
        this.element.classList.add("scene");
        parent.appendChild(this.element);

        this.element.style.cursor = "grab";

        this.vytvorObjekty(40);
    }

    vytvorObjekty(pocet){
        for(let i =0; i<pocet; i++){
            const obj = new MovableObject(this.element);
        }
    }
}