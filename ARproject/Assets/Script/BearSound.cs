using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSound : MonoBehaviour
{
    public AudioSource BearAudio1;
    public AudioSource BearAudio2;
    public AudioSource BearAudio3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayBearSounds());
    }

    IEnumerator PlayBearSounds()
    {
        // Play the first sound
        BearAudio1.Play();

        // Wait for 5 seconds
        yield return new WaitForSeconds(5);

        // Play the second sound after the delay
        BearAudio2.Play();

        // Wait for another 5 seconds
        yield return new WaitForSeconds(5);

        // Play the third sound after the second delay
        BearAudio3.Play();

        // Optional: If you want to loop the sounds, call the coroutine again
        StartCoroutine(PlayBearSounds());
    }
}
