using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HintText : MonoBehaviour
{

    public ARPlacement AR;
    public Text texto;

    // Update is called once per frame
    void Update()
    {
        if(AR.spawnedObject != null)
        {
            texto.enabled = false;
        }
    }
}
