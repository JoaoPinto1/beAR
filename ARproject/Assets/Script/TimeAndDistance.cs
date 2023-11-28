using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeAndDistance : MonoBehaviour
{
    public TextMeshProUGUI DistanciaTexto;
    public TextMeshProUGUI TempoTexto;

    void Start()
    {
        float totalDistance = PlayerPrefs.GetFloat("TotalDistance", 0f);
        float totalTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);

        // Format the float value to display only one decimal place
        string formattedDistance = totalDistance.ToString("F1");
        string formattedTime = totalTime.ToString("F2");

        DistanciaTexto.text = "Distância percorrida:\n" + formattedDistance + "m";
        TempoTexto.text = "Duração de jogo:\n" + formattedTime + "s";
    }
}
