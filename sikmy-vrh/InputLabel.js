export class InputLabel{
    constructor(text, parent){
        this.input = document.createElement("input");
        this.label = document.createElement("label");
        this.wrapper = document.createElement("div");

        this.label.textContent = text;
        this.wrapper.classList.add("inputLabel");

        this.wrapper.appendChild(this.label);
        this.wrapper.appendChild(this.input);
        parent.appendChild(this.wrapper);
    }

    ziskejHodnotuInput(){
        return parseFloat(this.input.value || 0);
    }
}