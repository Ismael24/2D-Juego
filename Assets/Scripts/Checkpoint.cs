using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer sprite;

    public Sprite cpOn, cpOff;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointController.instance.DeactivateCheckpoints();
            sprite.sprite = cpOn;
            CheckpointController.instance.SetSpawn(transform.position);

        }
    }

    public void ResetCheckpoint() { 
        sprite.sprite = cpOff;

    }
}
