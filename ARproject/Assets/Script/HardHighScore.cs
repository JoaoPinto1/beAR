using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HardHighScore : MonoBehaviour
{
    public TextMeshProUGUI Texto;

    void Start()
    {
        float HighScore = PlayerPrefs.GetFloat("BestTimeHard", 999f);

        if (HighScore == 999)
        {
            Texto.text = "DIFICIL\n Sem Recorde \n(30 alvos)";
        }
        else
        {
            string formattedText = HighScore.ToString("F2");
            Texto.text = "DIFICIL\n Recorde:" + formattedText + "s\n(30 alvos)";
        }
    }

}
