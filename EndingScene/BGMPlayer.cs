using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public AudioClip[] BGMMusic = new AudioClip[3];
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
            RandomPlayBGM();
    }

    void RandomPlayBGM()
    {
        audioSource.clip = BGMMusic[Random.Range(0, BGMMusic.Length)];
        audioSource.Play();
    }
}
