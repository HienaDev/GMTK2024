using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnAwake : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
