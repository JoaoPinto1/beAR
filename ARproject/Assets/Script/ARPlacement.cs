using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ARPlacement : MonoBehaviour
{
    public Camera camera;
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    public GameObject shoot;
    public GameObject spawnedObject;
    private GameObject weakPoint;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;
    public GameObject weakPointPrefab;
    public int numberOfWeakPoints; // Number of weak points to spawn around the object.
    public float moveSpeed = 1f;
    public float rotationSpeed = 60f;
    public int numberOfDeaths = 0;
    public int move = 0;
    private float initialYPosition; // Para armazenar a altura inicial
    private Animator animator;
    public PlayerHealth health;
    int difficulty = DifficultyManager.selectedDifficulty;




    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        shoot.SetActive(false);

        if(difficulty == 0)
        {
            numberOfWeakPoints = 10;
            moveSpeed= 0.2f;
        }
        else if(difficulty == 1)
        {
            numberOfWeakPoints = 20;
            moveSpeed = 0.3f;
        }
        else
        {
            numberOfWeakPoints = 30;
            moveSpeed = 0.4f;
        }

    }

    // need to update placement indicator, placement pose and spawn 
   void Update()
    {
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
            shoot.SetActive(true);
            animator = spawnedObject.GetComponent<Animator>();
        }

    
        if (spawnedObject != null && move == 0)
        {
            // Calcula a direção da câmera em relação ao objeto AR
            Vector3 cameraDirection = camera.transform.position - spawnedObject.transform.position;
            
            // Mantém a altura do urso a mesma que a altura inicial
            Vector3 newPosition = new Vector3(spawnedObject.transform.position.x, initialYPosition, spawnedObject.transform.position.z);

            // Mova o objeto AR na direção da câmera com velocidade controlada, apenas atualizando X e Z
            spawnedObject.transform.position = newPosition + cameraDirection.normalized * moveSpeed * Time.deltaTime;

            Vector3 n = new Vector3(camera.transform.position.x, 0f, camera.transform.position.z) - new Vector3(spawnedObject.transform.position.x, 0f, spawnedObject.transform.position.z);

            Quaternion targetRotation = Quaternion.LookRotation(n);
            spawnedObject.transform.rotation = Quaternion.Slerp(spawnedObject.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);



            if (Vector3.Distance(new Vector3(spawnedObject.transform.position.x, 0f, spawnedObject.transform.position.z), new Vector3(camera.transform.position.x, 0f, camera.transform.position.z)) < 0.6f)
            {

                animator.SetTrigger("AttackTrigger");

                health.CurrentHealth--;
                move = 1;

                animator.SetTrigger("IdleTrigger");

                StartCoroutine(AttackColdown());


            }
            
            CheckWallCollisions();
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();


    }

    IEnumerator AttackColdown()
    {
        if (difficulty == 0)
        {
            yield return new WaitForSeconds(4);
        }
        else if (difficulty == 1)
        {
            yield return new WaitForSeconds(3);
        }
        else
        {
            yield return new WaitForSeconds(2);
        }


        animator.SetTrigger("NeutralTrigger");
        move = 0;


    }





    void CheckWallCollisions()
    {
        RaycastHit hit;
        Vector3 currentPosition = transform.position;

        // Cast rays from all sides of the object to detect collisions with walls
        if (Physics.Raycast(currentPosition, Vector3.forward, out hit, 0.5f) ||
            Physics.Raycast(currentPosition, -Vector3.forward, out hit, 0.5f) ||
            Physics.Raycast(currentPosition, Vector3.right, out hit, 0.5f) ||
            Physics.Raycast(currentPosition, -Vector3.right, out hit, 0.5f))
        {
            // Bounce back by reversing the movement direction
            moveSpeed *= -1;
        }
    }



    void UpdatePlacementIndicator()
    {
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

  void UpdatePlacementPose()
    {
        var screenCenter = camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;

        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    void ARPlaceObject()
    {
        Quaternion rotation = Quaternion.Euler(PlacementPose.rotation.eulerAngles.x, PlacementPose.rotation.eulerAngles.y + 180f, PlacementPose.rotation.eulerAngles.z);
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, rotation);
        
        initialYPosition = spawnedObject.transform.position.y; 

        float weakPointDistance = 1f;
        float maxRadius = 3f; // Maximum distance from the center where weak points can be placed.

        // Get the mesh filter component from the spawned object.
        MeshFilter meshFilter = spawnedObject.GetComponent<MeshFilter>();

        if (meshFilter == null || meshFilter.sharedMesh == null)
        {
            Debug.LogError("MeshFilter or Mesh not found on the spawned object.");
            return;
        }

        Mesh mesh = meshFilter.sharedMesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

        // Spawn weak points on the outer surface of the mesh.
        for (int i = 0; i < numberOfWeakPoints; i++)
        {
            // Randomly select a vertex from the mesh.
            int randomVertexIndex = Random.Range(0, vertices.Length);
            Vector3 randomVertex = spawnedObject.transform.TransformPoint(vertices[randomVertexIndex]);
            Vector3 randomNormal = normals[randomVertexIndex]; // Use the same index for normals.

            // Calculate the weak point position based on the selected vertex and normal.
            Vector3 weakPointPosition = randomVertex;
            Quaternion weakPointRotation = Quaternion.LookRotation(randomNormal, Vector3.up);

            // Instantiate weak point prefab at the calculated position and rotation.
            weakPoint = Instantiate(weakPointPrefab, weakPointPosition, weakPointRotation);

            // Set the spawnedObject as the parent so the weakpoints move along with it
            weakPoint.transform.parent = spawnedObject.transform;
        }
    }




}
