using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Para la muerte instantánea si caemos al vacío
 * @author Ismael Paloma Narváez
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
