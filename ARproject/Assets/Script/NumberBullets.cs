using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberBullets : MonoBehaviour
{
    public Text textoNumeroDeBalas;
    public int numeroDeBalas;
    int difficulty = DifficultyManager.selectedDifficulty;


    void Start()
    {
        if (difficulty == 0)
        {
            numeroDeBalas = 20;
        }
        else if (difficulty == 1)
        {
            numeroDeBalas = 15;
        }
        else
        {
            numeroDeBalas = 10;
        }

        textoNumeroDeBalas.text =  numeroDeBalas.ToString();
    }

    void Update()
    {
        if (numeroDeBalas <= 0)
        {
            //Balas acabaram, tem de recarregar.
            textoNumeroDeBalas.text = "A recarregar...";
        }
        else
        {
            // Atualize o texto do objeto de texto com o número de balas
            textoNumeroDeBalas.text = numeroDeBalas.ToString();
        }

        
    }
}
