using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Muerte del jugador cuando caiga al vac�o
 * @author Ismael Paloma Narv�ez
 */
public class Muerte : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            LevelManager.instance.RespawnPlayer();

        }
    
    }
}
