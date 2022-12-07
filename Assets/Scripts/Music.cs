using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource scenaryGameMusic;
    private bool music;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer=0.1f;
        scenaryGameMusic = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        music=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            music=true;
            scenaryGameMusic.volume = 0.1f;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(music && other.CompareTag("Player")){
            music=false;
            scenaryGameMusic.volume = 1f;
        }
    }
}