using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PlayerHealth : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;
    public GameObject explosion;
    int difficulty = DifficultyManager.selectedDifficulty;//Get current difficulty

    void Start()
    {

        if (difficulty == 0)
        {
            MaxHealth = 10;
            CurrentHealth = MaxHealth;
        }
        else if (difficulty == 1)
        {
            MaxHealth = 8;
            CurrentHealth = MaxHealth;
        }
        else
        {
            MaxHealth = 6;
            CurrentHealth = MaxHealth;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves a game object with the tag "Bear"
        if (collision.gameObject.CompareTag("Bear"))
        {
            // Handle the collision logic here
            Debug.Log("Bear touched the player!");
            CurrentHealth--;
        }
    }



}
