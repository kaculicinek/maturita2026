export class Mic{
    constructor(parent){
        this.element = document.createElement("div");
        this.element.classList.add("mic");

        this.parent = parent;
        this.parent.appendChild(this.element);

        this.x = 0;
        this.y = 0;
        this.vx = 0;
        this.vy = 0;
        this.g = 0;

        this.vykresliMic();
    }

    vykresliMic(){
        this.element.style.left = this.x + "px";
        this.element.style.top = this.y + "px";
    }

    nastavHodnoty(x, y, vx, vy, g){
        this.x = x;
        this.y = y;
        this.vx = vx;
        this.vy = vy;
        this.g = g;
    }

    prepoctiHodnoty(dt){
        this.vy = this.vy + this.g*dt;
        this.x = this.x + this.vx*dt;
        this.y = this.y + this.vy*dt;
        this.vykresliMic();
    }

    jeMimoPlatno(){
        if(this.x >= this.parent.clientWidth || this.x < 0){
            return true;
        }
        else if(this.y >= this.parent.clientHeight || this.y < 0){
            return true;
        }
        else return false;
    }
}