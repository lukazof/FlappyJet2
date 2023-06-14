using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource audioSource;
    public AudioClip[] explosionSounds;

    public AudioClip scoreSound;
    public AudioClip coinSound;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayRandomSound(AudioClip[] clips)
    {
        int i = Random.Range(0, clips.Length);

        audioSource.PlayOneShot(clips[i]);
    }

}
