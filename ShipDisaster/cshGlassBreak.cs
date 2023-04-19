using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshGlassBreak : MonoBehaviour
{
    private AudioSource FireAxe;
    public AudioClip GlassBreak;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Glass")
        {
            playSound(GlassBreak, FireAxe);
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Exting")
        {
            playSound(GlassBreak, FireAxe);
            Destroy(other.gameObject);
        }
    }

    private void Start()
    {
        FireAxe = GetComponent<AudioSource>();
    }

    private void playSound(AudioClip clip, AudioSource source)
    {
        source.Stop();
        source.clip = clip;
        source.loop = false;
        source.time = 0;
        source.Play();
    }
}
