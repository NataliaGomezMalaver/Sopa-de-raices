using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mostrarocultar : MonoBehaviour
{

    public GameObject canvas;
    // Update is called once per frame
   public void Abrir() 
    {
        if (canvas.activeSelf)
        {
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
        }
        
    }
}
