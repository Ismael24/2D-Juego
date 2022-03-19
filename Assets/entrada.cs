using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entrada : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Audio.instance.PlaySSFX(9);


        }
    }
}
