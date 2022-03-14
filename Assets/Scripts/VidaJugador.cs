using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public static VidaJugador instance;
    public int currentHealth, maxHealth;
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
        if (invincibleCounter <= 0) 
        {

            currentHealth--;
            ControladorJugador.instance.anim.SetTrigger("Hurt");

            if (currentHealth <= 0)
            {
                currentHealth = 0;
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
