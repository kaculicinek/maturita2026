import { ControlPanel } from './ControlPanel';
import { Viewport } from './Viewport';
import { Mic } from './Mic';
import './style.css'

let animID = 0;
let beziAnimace = false;
let posledniCas = document.timeline.currentTime;
let jeNaZacatku = true;

const wrapper = document.createElement("div");
wrapper.classList.add("wrapper");
document.body.appendChild(wrapper);

const controlPanel = new ControlPanel(wrapper, callbackProTlacitko);
const viewport = new Viewport(wrapper);

const mic = new Mic(viewport.element);

let hodnoty;


function callbackProTlacitko() {
  beziAnimace = !beziAnimace;

  //spust animaci
  if (beziAnimace == true) {
    controlPanel.button.textContent = "STOP";

    if (jeNaZacatku == true) {
      hodnoty = controlPanel.ziskejHodnotyInputu();
      mic.nastavHodnoty(hodnoty.x, hodnoty.y, hodnoty.vx, hodnoty.vy, hodnoty.g);
      jeNaZacatku = false;
    }
    mic.vykresliMic();
    posledniCas = document.timeline.currentTime;
    simulate();
  }
  //zastav animaci
  else {
    cancelAnimationFrame(animID);
    jeNaZacatku = false;
    controlPanel.button.textContent = "CONTINUE";
  }
}

function simulate() {

  if (mic.jeMimoPlatno()) {
    jeNaZacatku = true;
    beziAnimace = false;
    controlPanel.button.textContent = "START";
    return;
  }

  const aktualniCas = document.timeline.currentTime;
  let dt = (aktualniCas - posledniCas) / 1000;
  mic.prepoctiHodnoty(dt);
  posledniCas = aktualniCas;
  animID = requestAnimationFrame(simulate);
}