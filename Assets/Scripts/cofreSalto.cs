using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Cofre que al colisionar nos desbloqueará el salto doble
 * @author Ismael Paloma Narváez
 */
public class cofreSalto : MonoBehaviour
{
    public Animator ani;
    private bool abrir = true;

    void Start()
    {
        ani = GetComponent<Animator>();
    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (abrir)
            {
                Audio.instance.PlaySSFX(6);
                abrir = false;
            }
            

            ControladorJugador.instance.ActivarDobleSalto();
            ani.SetBool("abrir", true);

        }

    }
}
