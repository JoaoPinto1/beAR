using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoBackMainMenu : MonoBehaviour
{

    public Button BackToMenuButton; // Reference to your button in the Inspector

    void Start()
    {
        BackToMenuButton.onClick.AddListener(MainMenu);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
