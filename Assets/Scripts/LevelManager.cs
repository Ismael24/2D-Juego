using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void RespawnPlayer() {
        StartCoroutine(RespawnCo());
        
    }

    public void RespawnPlayerInstant()
    {
        Audio.instance.PlaySSFX(7);
        ControladorJugador.instance.gameObject.SetActive(false);

        ControladorJugador.instance.gameObject.SetActive(true);
        ControladorJugador.instance.transform.position = CheckpointController.instance.spawn;

        VidaJugador.instance.currentHealth = VidaJugador.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();
    }

    IEnumerator RespawnCo() {

        yield return new WaitForSeconds(waitToRespawn);
        ControladorJugador.instance.gameObject.SetActive(false);

        ControladorJugador.instance.gameObject.SetActive(true);
        ControladorJugador.instance.transform.position = CheckpointController.instance.spawn;

        VidaJugador.instance.currentHealth = VidaJugador.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();


    }
    public void EndLevel() 
    {
        StartCoroutine(EndLevelCo());
    }
    public IEnumerator EndLevelCo() 
    {
        ControladorJugador.instance.stopInput = true;
        yield return new WaitForSeconds(1);
        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(final);


    }


}
