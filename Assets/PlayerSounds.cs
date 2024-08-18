using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] clipsHit;
    private AudioSource audioSourceHit;

    [SerializeField] private AudioClip[] clipsInflate;
    private AudioSource audioSourceInflate;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceInflate = gameObject.AddComponent<AudioSource>();
        audioSourceHit = gameObject.AddComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitSound()
    {
        audioSourceHit.clip = clipsHit[Random.Range(0, clipsHit.Length)];
        audioSourceHit.pitch = Random.Range(0.9f, 1.1f);
        audioSourceHit.Play();
    }

    public void InflateSound()
    {
        audioSourceInflate.clip = clipsInflate[Random.Range(0, clipsInflate.Length)];
        audioSourceInflate.pitch = Random.Range(0.9f, 1.1f);
        audioSourceInflate.Play();
    }
}
