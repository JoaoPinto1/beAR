using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explode : MonoBehaviour
{
    public GameObject explosion;
    public int numberOfWeakPoints;
    public Shoot s;

    private void OnCollisionEnter(Collision collision)
    {
        int difficulty = DifficultyManager.selectedDifficulty;
        float speed = 1f;

        if (difficulty == 0)
        {
            numberOfWeakPoints = 10;
        }
        else if (difficulty == 1)
        {
            numberOfWeakPoints = 20;
        }
        else
        {
            numberOfWeakPoints = 30;
        }


        if (collision.transform.tag == "Weakpoint")
        {
            Destroy(collision.transform.gameObject); // destroy weakpoint
            s.WeakPointsHit++;

            Instantiate(explosion, collision.transform.position, collision.transform.rotation);

        }
        else if (collision.transform.tag == "Bear")
        {
            // Calculate the reflection vector
            Vector3 reflectionDirection = Vector3.Reflect(transform.forward, collision.contacts[0].normal);

            // Update the bullet's direction to the reflection direction
            transform.forward = reflectionDirection;

        }

    }

}
