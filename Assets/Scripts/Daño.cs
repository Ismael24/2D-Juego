using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Script que aplica el daño recivido
 * @author Ismael Paloma Narváez
 */
public class Daño : MonoBehaviour
{
  
    //si nuestro jugador colisiona con el collider le haremos daño
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            //bajamos su vida
            VidaJugador.instance.DealDamage();
        }
    
    }
}
