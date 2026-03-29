export class Usecka{
    constructor(vrchol1, vrchol2, parent){
        this.vrchol1 = vrchol1;
        this.vrchol2 = vrchol2;
        
        this.element = document.createElementNS("http://www.w3.org/2000/svg", "line");
        this.element.setAttribute("stroke", 'black');
        this.element.setAttribute("stroke-width", '4');

        parent.appendChild(this.element);

        this.zmenSouradnice();
    }
    
        zmenSouradnice(){
        this.element.setAttribute("x1", this.vrchol1.x);
        this.element.setAttribute("y1", this.vrchol1.y);
        this.element.setAttribute("x2", this.vrchol2.x);
        this.element.setAttribute("y2", this.vrchol2.y);
    }
}