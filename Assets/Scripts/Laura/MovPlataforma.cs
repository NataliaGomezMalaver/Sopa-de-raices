using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlataforma : MonoBehaviour
{
    public float speed = 1.0f;
    private bool moveRight = false;
    public float final;
    private float position;

    private Animator animator;
    private bool mirandoDerecha = true;

    private void Start()
    {
        Girar();
        position = transform.position.x;
    
    }
   
    void Update()
    {
        if (transform.position.x >= position)
        {
            moveRight = false;
            Girar();
        }
        else if (transform.position.x <= final)
        {
            moveRight = true;
            Girar();
        }

        if (moveRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);

        }
    }

    private void Girar()
    {
        mirandoDerecha &= !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

}

