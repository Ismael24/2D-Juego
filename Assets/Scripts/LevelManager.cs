using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;
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

    IEnumerator RespawnCo() {

        yield return new WaitForSeconds(waitToRespawn);
        ControladorJugador.instance.gameObject.SetActive(false);

        ControladorJugador.instance.gameObject.SetActive(true);
        ControladorJugador.instance.transform.position = CheckpointController.instance.spawn;

        VidaJugador.instance.currentHealth = VidaJugador.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();


    }
}
