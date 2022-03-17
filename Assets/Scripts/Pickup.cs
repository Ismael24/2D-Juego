using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private bool isCollected;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") && !isCollected) {

            if (VidaJugador.instance.currentMana != VidaJugador.instance.maxMana)
            {
                VidaJugador.instance.DarMana();

                isCollected = true;
                Destroy(gameObject);
            }
            

        }
    }
}
