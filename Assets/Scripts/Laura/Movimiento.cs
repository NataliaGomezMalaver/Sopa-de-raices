using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;

    [Header("Movimiento")]

    private float movhoriz = 0f;

    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float suavidadMovimiento;

    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    public int health = 3;
    //public GameObject miTextMesh;
    public TMP_Text healthText;
    public Image barraVeg;
    public float valorUnitarioRecolectado;
    private int vegRecolectados = 0;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //healthText = gameObject.GetComponent<TextMeshPro>();

    }

    void Update()
    {
        movhoriz = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs(movhoriz));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Mover(movhoriz * Time.fixedDeltaTime);
    }

    private void Mover(float mover)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavidadMovimiento);

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }

        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoDerecha &= !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("conejo"))
        {
            health -= 1;
            healthText.text = "Vida: " + health;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

   // private void OnTriggerStay2D(Collider2D collision)
   // {

        //if (collision.CompareTag("hortaliza"))
        //{

            //RecolectarVegetal();

        //}

    //}

    public void RecolectarVegetal()
    {
        vegRecolectados++;

        float count = vegRecolectados * valorUnitarioRecolectado;

        barraVeg.fillAmount = count > 1 ? 1 : count;

    }


}
