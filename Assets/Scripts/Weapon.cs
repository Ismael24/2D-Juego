using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (other.tag == "Enemy") 
        {
            Audio.instance.PlaySSFX(4);
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffectSlime, other.transform.position, other.transform.rotation);
            Instantiate(potion, other.transform.position, other.transform.rotation);//No funciona, no hace el drop de la pocion
            



        }
        if (other.tag == "Boss")
        {
            contadorBoss--;
            Audio.instance.PlaySSFX(5);
            if (contadorBoss == 0)
            {
                other.transform.parent.gameObject.SetActive(false);
                Instantiate(deathEffectSamu, other.transform.position, other.transform.rotation);
                LevelExit.instance.SamuDerrotado();
            }
            
            
            
                


            


        }
        if (other.tag == "Mago")
        {
            Audio.instance.PlaySSFX(5);

            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffectMago, other.transform.position, other.transform.rotation);
            Instantiate(potion, other.transform.position, other.transform.rotation);//No funciona, no hace el drop de la pocion
            LevelExit.instance.MagoDerrotado();

            

        }










    }
}
