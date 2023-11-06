using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth health;
    public Image HealthBarUi;
    private float fillamount = 0f;
    private float maxHealth = 0f;
    private float currentHealth = 0f;

    void Update()
    {

        maxHealth = health.MaxHealth;
        currentHealth = health.CurrentHealth;

        fillamount = currentHealth / maxHealth;
        HealthBarUi.fillAmount = fillamount;
     

        if (fillamount == 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(2);
        }

    }
}
