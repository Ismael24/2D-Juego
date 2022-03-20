using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script que controla los checkpoints qued�ndose con el �ltimo al que accedamos
 * @author Ismael Paloma Narv�ez
 */
public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;

    public Checkpoint[] checkpoints;

    public Vector3 spawn;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        checkpoints = FindObjectsOfType<Checkpoint>();
        spawn = ControladorJugador.instance.transform.position;
    }

    public void DeactivateCheckpoints()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            
            checkpoints[i].ResetCheckpoint();

        }
        

    }
    public void SetSpawn(Vector2 newSpawn) 
    
    {
        spawn = newSpawn;
        
    }
}
