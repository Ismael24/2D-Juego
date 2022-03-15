using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio instance;

    public AudioSource[] soundEffects;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySSFX(int soundToPlay) 
    {
        soundEffects[soundToPlay].Play();
    }
}
