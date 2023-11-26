using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalDistance : MonoBehaviour
{
    public TextMeshProUGUI DistanciaTexto;

    void Start()
    {
        float totalDistance = PlayerPrefs.GetFloat("TotalDistance", 0f);

        // Format the float value to display only one decimal place
        string formattedDistance = totalDistance.ToString("F1");

        DistanciaTexto.text = "Distância percorrida:\n" + formattedDistance + "m";
    }
}
