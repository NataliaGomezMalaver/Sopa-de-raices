using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] TextMeshProUGUI tiempo;
    
    private float restante;
    private bool corriendo;
    public GameObject panel;
    public GameObject canvas;
    public GameObject video;
    public AudioSource audioSource;

    private void Awake(){
        restante = (min * 60) +  seg;
        // restante = seg;
        corriendo = true;
    }
    void Start(){
        // panel.gameObject.SetActive(false);
        
        video.gameObject.SetActive(true);
        canvas.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if(corriendo)
        {
            restante -= Time.deltaTime;

            // Debug.Log("HOLA");
            // Debug.Log(restante);

            if (restante < 24){


                video.gameObject.SetActive(false);
            }
            
            if (restante < 1)
            {
                audioSource.Play();
                corriendo = true;
                panel.gameObject.SetActive(false);
                canvas.SetActive(true);
                
                // plataformas.gameObject.SetActive(true);
                //SONIDO DE QUE SE ACABÓ EL TIEMPO
                //DESHABILITAR LA TECLA ESPACIO (?)
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format( "{00:00}:{01:00}" , tempMin, tempSeg); 
        }
    }
}
