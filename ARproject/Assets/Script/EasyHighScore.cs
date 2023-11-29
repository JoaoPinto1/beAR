using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EasyHighScore : MonoBehaviour
{
    public TextMeshProUGUI Texto;

    void Start()
    {
        float HighScore = PlayerPrefs.GetFloat("BestTimeEasy", 999f);

        if (HighScore == 999)
        {
            Texto.text = "FACIL\n Sem Recorde \n(10 alvos)";
        }
        else
        {
            string formattedText = HighScore.ToString("F2");
            Texto.text = "FACIL\n Recorde:" + formattedText + "s\n(10 alvos)";
        }
    }

}
