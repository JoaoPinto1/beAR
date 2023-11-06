using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;
    public GameObject explosion;
    public ARPlacement c;
    public Image PlayerHealthUI;
    public int numberOfDeaths;
    private Animator animator;
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

        animator = c.spawnedObject.GetComponent<Animator>();

    }


 
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves a game object with the tag "Bear"
        if (collision.gameObject.CompareTag("Bear"))
        {
            // Touched the bear, bear attacks and player loses health
            // Play the animation
            c.move = 1;
            animator.Play("Bear_Attack1");
            StartCoroutine(Wait());
            CurrentHealth--;
        }
    }


    IEnumerator Wait()
    {

        yield return new WaitForSeconds(3);
        c.move = 0;

    }



}
