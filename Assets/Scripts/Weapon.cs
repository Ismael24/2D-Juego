using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int contadorBoss = 6;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy") 
        {
            other.transform.parent.gameObject.SetActive(false);

        
        }
        if (other.tag == "Boss")
        {
            contadorBoss--;
            if (contadorBoss == 0)
            {
                other.transform.parent.gameObject.SetActive(false);
            }
            
                


            


        }

        

        



    }
}
