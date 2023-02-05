using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb2D;

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
    public GameObject canvas;

    private Animator animator;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private float x = 0;
    private float y = 0;
    public float delay = 3;
    private float timer;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //healthText = gameObject.GetComponent<TextMeshPro>();
    }

    void Update()
    {
        animator.SetFloat("Horizontal", Mathf.Abs(movhoriz));
        animator.SetFloat("x", Mathf.Abs(x));
        animator.SetFloat("y", Mathf.Abs(y));

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        movhoriz = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;

        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            y = 1;
            rb2D.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            // Debug.Log(x);  
            // x = 1;
        }

        if (Input.GetKeyDown(KeyCode.X)&& isTouchingGround)
        {
            x = 1;
        }

        timer += Time.deltaTime;
        if (timer > delay)
        {
            x = 0;
            y = 0;
            timer = 0;
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
                canvas.SetActive(true);
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
