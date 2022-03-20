using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    public static LevelExit instance;
    public bool mago = false;
    public bool samu = false;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") 
        {
            if (mago && samu) 
            {
                LevelManager.instance.EndLevel();
            }
            
        }
    }

    public void MagoDerrotado()
    {
        mago = true;
       
    }
    public void SamuDerrotado()
    {
        samu = true;

    }
}
