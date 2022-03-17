using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cofreSalto : MonoBehaviour
{
    public Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            ControladorJugador.instance.ActivarDobleSalto();
            ani.SetBool("abrir", true);

        }

    }
}
