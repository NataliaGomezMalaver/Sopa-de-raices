using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    private RigidBody2D rb2D;
    private float MovimientoHorizontal;
    public float VelocidadPersonaje = 0f;
    private Vector3  Velocidad = Vector3.zero;  


    public float Suavizar;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<RigidBody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoHorizontal = inputMovimiento * VelocidadPersonaje;
    }

    void FixedUpdate() {
        Movimiento(MovimientoHorizontal * Time.fixedDeltaTime);
    }

    void Movimiento(float mover)
    {
        float inputMovimiento = Input.GetAxisRaw("Horizontal");
    
        Vector3 VelocidadObjetivo = new Vector2(mover, rb2D.velocity.y) 
        rb2D.velocity = Vector3.smoothDamp(rb2D.velocity, VelocidadObjetivo, ref Velocidad, Suavizar);
    }
}
