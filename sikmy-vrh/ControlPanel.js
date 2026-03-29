import { InputLabel } from "./InputLabel";

export class ControlPanel{
    constructor(parent, callbackProTlacitko){
        this.element = document.createElement("div");
        this.element.classList.add("panel");
        parent.appendChild(this.element);
        
        this.x = new InputLabel("X:", this.element);
        this.y = new InputLabel("Y:", this.element);
        this.vx = new InputLabel("VX:", this.element);
        this.vy = new InputLabel("VY:", this.element);
        this.g = new InputLabel("G:", this.element);

        this.button = document.createElement("button");
        this.button.textContent = "START";
        this.element.appendChild(this.button);

        this.button.addEventListener("click", callbackProTlacitko);
    }

    ziskejHodnotyInputu(){
        return{
            x: this.x.ziskejHodnotuInput(),
            y: this.y.ziskejHodnotuInput(),
            vx: this.vx.ziskejHodnotuInput(),
            vy: this.vy.ziskejHodnotuInput(),
            g: this.g.ziskejHodnotuInput(),
        }
    }
}