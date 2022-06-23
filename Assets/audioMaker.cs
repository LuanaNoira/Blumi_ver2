using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMaker : MonoBehaviour
{
    public AudioClip[] audioClips;
    
    AudioSource randomSound;

    [SerializeField] float timer = 0;

    [SerializeField] float randomNumber;

    // Start is called before the first frame update
    void Awake()
    {
        randomSound = GetComponent<AudioSource>();
        randomNumber = Random.Range(7, 14);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > randomNumber)
        {
            RandomSound();
            randomNumber = Random.Range(7, 14);
            timer = 0;
        }
    }

    void RandomSound()
    {
        randomSound.clip = audioClips[Random.Range(0, audioClips.Length)];
        randomSound.PlayOneShot(randomSound.clip);
    }
}
