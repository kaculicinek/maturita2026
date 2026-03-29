import { MovableObject } from "./MovableObject";

export class Viewport{
    constructor(parent){
        this.element = document.createElement("div");
        this.element.classList.add("viewport");
        parent.appendChild(this.element);
    }
}