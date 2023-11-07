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

    void Update()
    {
        if(WeakPointsHit == exp.numberOfWeakPoints)
        {
            c.move = 1;
            // Get the Animator component attached to the GameObject
            animator = c.spawnedObject.GetComponent<Animator>();
            
            // Play the animation
            animator.Play("Bear_Death");

            StartCoroutine(Wait());


        }



        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            
            
            // Get the screen position of the touch
            Vector3 touchPos = Input.GetTouch(0).position;

            // Get the Camera component from the arCamera object
            Camera arCameraComponent = arCamera.GetComponent<Camera>();

            // Check if the Camera component is not null
            if (arCameraComponent != null)
            {
                // Convert the screen position to a ray
                Ray ray = arCameraComponent.ScreenPointToRay(touchPos);

                // Create a plane at the object's position (assuming the ground is at y=0)
                Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
                number.numeroDeBalas = 19; //é para meter -- mas estou a fazer testes nao me dispara nada xD
                float rayDistance;
                if (groundPlane.Raycast(ray, out rayDistance))
                {
                    // Get the point on the plane where the ray hits
                    Vector3 targetPosition = ray.GetPoint(rayDistance);

                   
                    // Instantiate the projectile at the touched position
                    GameObject bullet = Instantiate(projectile, targetPosition, Quaternion.identity) as GameObject;

                    
                    // Apply force to the projectile
                    bullet.GetComponent<Rigidbody>().AddForce(arCamera.forward * shootForce);
                }
            }
            else
            {
                Debug.LogError("Camera component not found on arCamera object.");
            }
        }
    }

    IEnumerator Wait()
    {

        yield return new WaitForSeconds(5);
        c.move = 0;
        SceneManager.LoadScene(3);

    }



}


