using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audio;
    AudioSource audioSource;

    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update

    public void audioJump()
    {
        audioSource.PlayOneShot(audio[0]);
    }

    public void audioLand()
    {
        audioSource.PlayOneShot(audio[1]);
    }

    public void audioDie()
    {
        audioSource.PlayOneShot(audio[2]);
    }

    public void audioButton()
    {
        audioSource.PlayOneShot(audio[3]);
    }

}
