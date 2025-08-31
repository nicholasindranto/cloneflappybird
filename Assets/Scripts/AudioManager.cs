using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager singleton; // bikin singleton
    public AudioClip[] clips;
    private AudioSource audioSource;

    private void Awake()
    {
        singleton = this; // singleton nya adalah script ini
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySFX(int index)
    {
        // kenapa oneshot? karna SFX. SFX itu singkat dan keplay sekali doang
        audioSource.PlayOneShot(clips[index]);
    }
}
