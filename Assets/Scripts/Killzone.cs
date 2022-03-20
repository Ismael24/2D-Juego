using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Para la muerte instant�nea si caemos al vac�o
 * @author Ismael Paloma Narv�ez
 */
public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            LevelManager.instance.RespawnPlayerInstant();
        }

    }
}
