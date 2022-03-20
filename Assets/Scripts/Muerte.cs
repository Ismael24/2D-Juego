using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Muerte del jugador cuando caiga al vacío
 * @author Ismael Paloma Narváez
 */
public class Muerte : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            LevelManager.instance.RespawnPlayer();

        }
    
    }
}
