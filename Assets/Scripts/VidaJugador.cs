using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
/**
 * Script que controlará tanto la vida como el mana de nuestro jugador, cuando se aplican daños, cuando nos curamos o bien cuando recivimos o gastamos mana.
 * @author Ismael Paloma Narváez
 */
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
    {   //aplicamos un tiempo en el que nuestro jugador sera invencible para darle algo de ventaja si esta sufriendo daños
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if (invincibleCounter<=0) 
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
            }
        }
    }
    //funcion que resta vida a nuestro jugador siempre que la invencibilidad no esté activa.
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
                    ControladorJugador.instance.stopInput = true;
                    //llamamos a otro script para respawnear a nuestro jugador
                    LevelManager.instance.RespawnPlayer();
                    

                }
                else
                {
                    invincibleCounter = invincibleLength;
                    sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, .5f);

                    ControladorJugador.instance.Knockback();
                }
                //actualización visual del UI
                UIController.instance.UpdateHealthDisplay();



            }


        }
        
        



    }
    //función que suma mana
    public void DarMana() { 
        currentMana++;
        if (currentMana > maxMana) 
        {
            currentMana = maxMana;
        }
        UIController.instance.UpdateManaDisplay();
    }
    //funcón que aplica la mecánica de autosanación que cura un corazón completo solo si te falta más de medio corazón
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
            Audio.instance.PlaySSFX(11);
            UIController.instance.UpdateHealthDisplay();
            UIController.instance.UpdateManaDisplay();
        }
    }
    //función que nos suma mana al jugador solo si el mana no esta al máximo
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
