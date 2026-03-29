import './style.css'
import { Trojuhelnik } from './Trojuhelnik';
import { Usecka } from './Usecka';
import { Vrchol } from './Vrchol';

// const mojeSVG = document.getElementById("svg");

// const path = document.createElementNS("http://www.w3.org/2000/svg", "path");
// path.setAttribute("d", "M 250 250 L 400 0 L 100 0 Z");
// path.setAttribute("fill", "purple");
// mojeSVG.appendChild(path);


const div = document.createElement("div");
div.classList.add("div");
document.body.appendChild(div);

div.innerHTML = '<svg width="100%" height="100%" id="trojuhelnik" style="display:block; background-color: hotpink; overflow: visible;"></svg>';
const trojuhelnik = new Trojuhelnik();




