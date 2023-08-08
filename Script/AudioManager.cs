using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip FP;
    public AudioClip hit;
    public AudioClip enemyHit;
    public AudioClip die;
    public AudioSource lazer;
    

    private AudioSource audioSource;
    public static AudioManager instance;
    void Start()
    {
        instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playJump(){playsound(jump);}
    public void playCoin() {playsound(FP);}
    public void playHit() { playsound(hit); }
    public void playDie() { playsound(die); }
    public void playenemyHit() { playsound(enemyHit); }
    public void playelazert() { lazer.Play(); }
    public void playsound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
