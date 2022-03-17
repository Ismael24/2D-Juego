using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class VidaJugador : MonoBehaviour
{
    public static VidaJugador instance;
    public int currentHealth, maxHealth;
    public int currentMana, maxMana;
    public float invincibleLength;
    private float invincibleCounter;

    private SpriteRenderer sprite;
    

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;

        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if (invincibleCounter<=0) 
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
            }
        }
    }

    public void DealDamage() 
    {
        if (currentHealth != 0)
        {
            if (invincibleCounter <= 0)
            {

                currentHealth--;
                Audio.instance.PlaySSFX(1);
                ControladorJugador.instance.anim.SetTrigger("Hurt");

                if (currentHealth <= 0)
                {
                    ControladorJugador.instance.anim.SetTrigger("Death");
                    LevelManager.instance.RespawnPlayer();

                }
                else
                {
                    invincibleCounter = invincibleLength;
                    sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, .5f);

                    ControladorJugador.instance.Knockback();
                }

                UIController.instance.UpdateHealthDisplay();



            }


        }
        
        



    }
    public void DarMana() { 
        currentMana++;
        if (currentMana > maxMana) 
        {
            currentMana = maxMana;
        }
        UIController.instance.UpdateManaDisplay();
    }
    public void DarVida()
    {
        if (currentHealth<=4 && currentMana>0)
        {
            currentHealth = currentHealth + 2;
            DealMana();
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            UIController.instance.UpdateHealthDisplay();
            UIController.instance.UpdateManaDisplay();
        }
    }

    public void DealMana()
    {
        
            if (currentMana != 0)
            {
                currentMana = currentMana - 1;
                UIController.instance.UpdateManaDisplay();
                UIController.instance.UpdateHealthDisplay();









            }

            UIController.instance.UpdateManaDisplay();
            UIController.instance.UpdateHealthDisplay();

        


    }

}
