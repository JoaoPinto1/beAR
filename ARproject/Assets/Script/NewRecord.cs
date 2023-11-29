using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewRecord : MonoBehaviour
{
    public TextMeshProUGUI DistanciaTexto;
    public TextMeshProUGUI TempoTexto;
    int difficulty = DifficultyManager.selectedDifficulty;


    void Start()
    {
        if (difficulty == 0)
        {
            Record("BestTimeEasy", "DistanceEasy");
        }
        else if (difficulty == 1)
        {
            Record("BestTimeNormal", "DistanceNormal");
        }
        else
        {
            Record("BestTimeHard", "DistanceHard");
        }

    }
    
    void Record(string Time , string Distance)
    {
        float totalDistance = PlayerPrefs.GetFloat("TotalDistance", 0f);
        float totalTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);

        // Format the float value to display only one decimal place
        string formattedDistance = totalDistance.ToString("F1");
        string formattedTime = totalTime.ToString("F2");

        float HighScore = PlayerPrefs.GetFloat(Time, 999f);
        float BestDistance = PlayerPrefs.GetFloat(Distance, 999f);

        if (totalTime < HighScore)
        {
            PlayerPrefs.SetFloat(Time, totalTime);
            PlayerPrefs.Save();

            PlayerPrefs.SetFloat(Distance, totalDistance);
            PlayerPrefs.Save();

            DistanciaTexto.text = "NOVO RECORDE!!\nDistância percorrida:\n" + formattedDistance + "m";
            TempoTexto.text = "Duração de jogo:\n" + formattedTime + "s";

        }
        else if (totalTime == HighScore)
        {
            if (totalDistance < BestDistance)
            {
                PlayerPrefs.SetFloat(Time, totalTime);
                PlayerPrefs.Save();

                PlayerPrefs.SetFloat(Distance, totalDistance);
                PlayerPrefs.Save();

                DistanciaTexto.text = "NOVO RECORDE!!\nDistância percorrida:\n" + formattedDistance + "m";
                TempoTexto.text = "Duração de jogo:\n" + formattedTime + "s";
            }
        }
        //No new record.
        else
        {
            DistanciaTexto.text = "\nDistância percorrida:\n" + formattedDistance + "m";
            TempoTexto.text = "Duração de jogo:\n" + formattedTime + "s";
        }

    }
}
