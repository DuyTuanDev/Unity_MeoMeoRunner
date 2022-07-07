using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager Instance;
    public AudioSource audioSource;
    public AudioClip bullet;
    public AudioClip triggerBullet;
    private void Awake() {
        Instance = this;
    }
    public void SoundBullet(){
        audioSource.PlayOneShot(bullet);
    }
    public void SoundTriggerBullet(){
        audioSource.PlayOneShot(triggerBullet);
    }
}
