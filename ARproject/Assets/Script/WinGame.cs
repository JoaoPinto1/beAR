using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Make sure to include this namespace for IEnumerator

public class WinGame : StateMachineBehaviour
{
    private MonoBehaviour monoBehaviour; // Reference to a MonoBehaviour component

    // Assign the MonoBehaviour component in the inspector
    public MonoBehaviour targetMonoBehaviour;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Assign the MonoBehaviour component from the inspector
        monoBehaviour = targetMonoBehaviour;

        // Start the WaitAndLoadScene coroutine
        monoBehaviour.StartCoroutine(WaitAndLoadScene());
    }

    IEnumerator WaitAndLoadScene()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Do something after waiting for 2 seconds
        SceneManager.LoadScene(3);
    }
}
