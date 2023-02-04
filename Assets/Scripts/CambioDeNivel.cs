using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeNivel : MonoBehaviour
{
    public int NumeroEscena; 

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.tag == "Player")
        {
            SceneManager.LoadScene(NumeroEscena);
        }    
    }
}
