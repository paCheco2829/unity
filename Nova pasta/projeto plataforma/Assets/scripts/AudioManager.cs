using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicaSouce;
    public AudioSource sfxSource;
    public AudioClip sfxtiro;
    public AudioClip sfxmorte;
    public AudioClip sfxcoin;
    
    public void sfxManager(AudioClip sxfClip, float volume)
    {
        sfxSource.PlayOneShot(sxfClip, volume);
    }
}
