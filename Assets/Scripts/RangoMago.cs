using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Controlamos el rango del mago de forma cercana, si el jugador entra atacará y dejará de lanzar bolas de fuego
 * @author Ismael Paloma Narváez
 */
public class RangoMago : MonoBehaviour
{
    public Animator ani;
    public EnemyMago enemigo;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            
            ani.SetBool("attack", true);
            enemigo.atacando = true;
            GetComponent<BoxCollider2D>().enabled = false;

        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
