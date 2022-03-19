using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entradaCueva : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Audio.instance.PlaySSFX(8);
            

        }
    }
}
