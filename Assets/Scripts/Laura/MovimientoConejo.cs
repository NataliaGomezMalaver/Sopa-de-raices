using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoConejo : MonoBehaviour
{
    public float speed = 1.0f;
    private bool moveRight = true;
    public float final;
    private float position;

    private void Start()
    {
        position = transform.position.x;
    }

    void Update()
    {
        if (transform.position.x >= position)
        {
            moveRight = false;
        }
        else if (transform.position.x <= final)
        {
            moveRight = true;
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
}
