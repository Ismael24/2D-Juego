using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * Este sript controlará el nivel, en concreto el respawnear y el finalizar
 * @author Ismael Paloma Narváez
 */
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;
    public int potionsCollected;
    public string final;
    // Start is called before the first frame update

    private void Awake() {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //respawneamos al jugador
    public void RespawnPlayer() {
        StartCoroutine(RespawnCo());
        
    }
    //funcion para respawnear al jugador de forma instantanea si cae al vacío
    public void RespawnPlayerInstant()
    {
        Audio.instance.PlaySSFX(7);
        ControladorJugador.instance.gameObject.SetActive(false);

        ControladorJugador.instance.gameObject.SetActive(true);
        ControladorJugador.instance.transform.position = CheckpointController.instance.spawn;

        VidaJugador.instance.currentHealth = VidaJugador.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();
    }
    //corutina que espera a la animación de muerte para respawnear al jugador
    IEnumerator RespawnCo() {

        yield return new WaitForSeconds(waitToRespawn);
        ControladorJugador.instance.gameObject.SetActive(false);

        ControladorJugador.instance.gameObject.SetActive(true);
        ControladorJugador.instance.transform.position = CheckpointController.instance.spawn;

        VidaJugador.instance.currentHealth = VidaJugador.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();


    }
    //para finalizar el nivel
    public void EndLevel() 
    {
        StartCoroutine(EndLevelCo());
    }
    //corutina en la que haremos que se espere un tiempo para finalizar el nivel, el suficiente como para mostrar un texto y después nos llevará al main menu
    public IEnumerator EndLevelCo() 
    {
        ControladorJugador.instance.stopInput = true;
        yield return new WaitForSeconds(1);
        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(final);


    }


}
