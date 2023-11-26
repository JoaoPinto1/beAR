using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BearHealthBar : MonoBehaviour
{
    public Explode exp;
    public Shoot s;
    public Image HealthBarUi;
    public float fillamount = 0;
    public float CurrentWeakPoints = 0f;


    void Update()
    {
        CurrentWeakPoints = exp.numberOfWeakPoints - s.WeakPointsHit;

        fillamount = CurrentWeakPoints / exp.numberOfWeakPoints;
        HealthBarUi.fillAmount = fillamount;


        if (fillamount == 0)
        {
            Time.timeScale = 1; 
            SceneManager.LoadScene(3);

        }

    }
}
