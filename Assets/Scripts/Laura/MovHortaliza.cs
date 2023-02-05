using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class MovHortaliza : MonoBehaviour
{
    public float speed = 1.0f;
    private bool moveRight = true;
    public float final;
    private float position;
    private bool ismoving = false;
    public GameObject oprimirBotonImage;
    public AudioSource audioSource;

    [SerializeField]
    private Movimiento movimiento;

    private void Start()
    {
        movimiento = FindFirstObjectByType<Movimiento>();

    }


    void Update()
    {
        
        if (ismoving)
        {
            moveCircle();
            
        }
        
    }

    private void Awake()
    {
        
    }
    private void moveCircle ()
    {

        position = transform.position.y;
        

        Debug.Log(String.Format("positionX {0} - position {1} - final {2}", transform.position.x, position, final));
        if (transform.position.y <= final)
        {
            moveRight = true;
            oprimirBotonImage.SetActive(false);
        } else
        {
            moveRight = false;
            ismoving= false;
            
            movimiento.RecolectarVegetal();

            Destroy(gameObject, 0.4f);
            return;
        }
        


       if (moveRight)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
       
        Debug.Log(String.Format("final position {0}", transform.position));
    }
    

    

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("player"))
        {
            oprimirBotonImage.SetActive(true);


        }
        if (Input.GetButton("interactuar") && collision.CompareTag("player"))
        {
            
           ismoving= true;
           audioSource.Play();
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            oprimirBotonImage.SetActive(false);
        }
    }
}
