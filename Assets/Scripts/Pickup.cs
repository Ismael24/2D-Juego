using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * En este script controlaremos el efecto de pickup en este caso sobre una poción
 * @author Ismael Paloma Narváez
 */
public class Pickup : MonoBehaviour
{
    private bool isCollected;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        //si entra el jugador en el collider o la poción no ha sido recolectada previamente
        if (other.CompareTag("Player") && !isCollected) {
            //si la bharra de mana del jugador ya está completa no se podrá recolectar una nueva poción
            if (VidaJugador.instance.currentMana != VidaJugador.instance.maxMana)
            {
                //llamamos a una funcion para aplicar el efecto de la pocion en este caso rellenar media barra
                VidaJugador.instance.DarMana();
                Audio.instance.PlaySSFX(11);
                isCollected = true;
                //finalmente, ya ha sido recolectado por lo que destruimos el objeto
                Destroy(gameObject);
            }
            

        }
    }
}
