using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth health;
    public Image HealthBarUi;
    public float fillamount = 0;


    void Update()
    {
        fillamount = health.CurrentHealth / health.MaxHealth;
        HealthBarUi.fillAmount = fillamount;


        if (fillamount == 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(2);
        }

    }
}
