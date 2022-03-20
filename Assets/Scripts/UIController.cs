using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * Script que controla el interfaz de jugador en este caso los corazones y la barra de maná
 * @author Ismael Paloma Narváez
 */
public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Image heart1, heart2, heart3, barraMana;

    public Sprite heartFull, heartEmpty, heartHalf;
    public Sprite manaFull, manaEmpty, manaHalf;

    public GameObject levelCompleteText;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //switch para cambiar los corazones en función del numero de vida
    public void UpdateHealthDisplay()
    {
        switch (VidaJugador.instance.currentHealth)
        {
            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break;

            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;

                break;

            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;

                break;
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;

                break;

            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;
            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;


                default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

        }
    }
    //switch que cambia el relleno de la barra en función de numero de maná que tengamos

    public void UpdateManaDisplay()
    {
        switch (VidaJugador.instance.currentMana)
        {
            case 2:
                barraMana.sprite = manaFull;

                break;

            case 1:
                barraMana.sprite = manaHalf;

                break;
            case 0:
                barraMana.sprite = manaEmpty;

                break;



            default:
                barraMana.sprite = manaEmpty;

                break;

        }
    }
}
