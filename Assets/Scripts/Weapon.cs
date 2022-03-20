using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Script que controla la colisión de nuestra caja de hacer daño contra enemigos.
 * @author Ismael Paloma Narváez
 */
public class Weapon : MonoBehaviour
{
    public static Weapon instance;
    private int contadorBoss = 1;
    public GameObject deathEffectSlime;
    public GameObject potion;
    public GameObject deathEffectSamu; 
    public GameObject deathEffectMago;
    public int samuFin = 0;
    public int magoFin = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) 
    {
        //si colisiona con enemy lo destruimos y aplicamos distintos efectos
        if (other.tag == "Enemy") 
        {
            Audio.instance.PlaySSFX(4);
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffectSlime, other.transform.position, other.transform.rotation);
            Instantiate(potion, other.transform.position, other.transform.rotation);//No funciona, no hace el drop de la pocion
            



        }
        //si colisiona con boss y le bajamos todo el contador lo destruiremos y aplicaremos distintos efectos
        if (other.tag == "Boss")
        {
            contadorBoss--;
            Audio.instance.PlaySSFX(5);
            if (contadorBoss == 0)
            {
                other.transform.parent.gameObject.SetActive(false);
                Instantiate(deathEffectSamu, other.transform.position, other.transform.rotation);
                //llamada a otra funcion para guardar en base de datos si este está destruido o no
                LevelExit.instance.SamuDerrotado();
            }
            
            
            
                


            


        }
        //si colisiona con boss y le bajamos todo el contador lo destruiremos y aplicaremos distintos efectos
        if (other.tag == "Mago")
        {
            Audio.instance.PlaySSFX(5);

            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffectMago, other.transform.position, other.transform.rotation);
            Instantiate(potion, other.transform.position, other.transform.rotation);
            //llamada a otra funcion para guardar en base de datos si este está destruido o no
            LevelExit.instance.MagoDerrotado();

            

        }










    }
}
