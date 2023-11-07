using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{

    public Transform arCamera;
    public GameObject projectile;
    public int WeakPointsHit;
    public Explode exp;
    private Animator animator;
    public ARPlacement c;
    

    public float shootForce = 700.0f;
    public NumberBullets number;
    private bool canShoot = true;
    public AudioSource ShootAudio;


    void Update()
    {
        if (WeakPointsHit == exp.numberOfWeakPoints)
        {
            c.move = 1;
            // Get the Animator component attached to the GameObject
            animator = c.spawnedObject.GetComponent<Animator>();

            // Play the animation
            animator.Play("Bear_Death");

            StartCoroutine(Wait());


        }


        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && canShoot)
        {
            ShootAudio.Play();
            GameObject bullet = Instantiate(projectile, arCamera.position, arCamera.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward * shootForce);

            number.numeroDeBalas--;

            if (number.numeroDeBalas == 0)
            {
                StartCoroutine(WaitBullets());
                canShoot = false;
            }
        }
    }

    IEnumerator Wait()
    {

        yield return new WaitForSeconds(5);
        c.move = 0;
        SceneManager.LoadScene(3);

    }

    IEnumerator WaitBullets()
    {

        yield return new WaitForSeconds(5);
        number.numeroDeBalas = 20;
        canShoot = true;

    }



}


