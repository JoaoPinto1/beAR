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
        BearAudio1.Play();


    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Wait());

    }


    IEnumerator Wait()
    {

        yield return new WaitForSeconds(5);
        BearAudio1.Play();

    }
}
