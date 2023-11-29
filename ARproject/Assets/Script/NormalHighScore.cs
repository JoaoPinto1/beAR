using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NormalHighScore : MonoBehaviour
{
    public TextMeshProUGUI Texto;

    void Start()
    {
        float HighScore = PlayerPrefs.GetFloat("BestTimeNormal", 999f);

        if (HighScore == 999)
        {
            Texto.text = "NORMAL\n Sem Recorde \n(20 alvos)";
        }
        else
        {
            string formattedText = HighScore.ToString("F2");
            Texto.text = "NORMAL\n Recorde:" + formattedText + "s\n(20 alvos)";
        }
    }

}
