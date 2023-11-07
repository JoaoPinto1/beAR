using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberBullets : MonoBehaviour
{
    public Text textoNumeroDeBalas;
    public int numeroDeBalas;
    

    // Start is called before the first frame update
    void Start()
    {
        numeroDeBalas = 20;
        textoNumeroDeBalas.text =  numeroDeBalas.ToString();
    }

    void Update()
    {
        if (numeroDeBalas <= 0)
        {
            textoNumeroDeBalas.text = "A recarregar...";
        }
        else
        {
            // Atualize o texto do objeto de texto com o número de balas
            textoNumeroDeBalas.text = numeroDeBalas.ToString();
        }

        
    }
}
