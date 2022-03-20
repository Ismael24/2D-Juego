using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Script para el rango del samurai y controlar que si algo entra en el mismo atacará 
 * @author Ismael Paloma Narváez
 */
public class rangoSamu : MonoBehaviour
{
    public Animator ani;
    public EnemigoStrong enemigo;

    void OnTriggerEnter2D(Collider2D coll) 
    {
        if (coll.CompareTag("Player")) 
        {
            ani.SetBool("walk", false);
            ani.SetBool("run", false);

            ani.SetBool("attack", true);
            Audio.instance.PlaySSFX(10);
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
