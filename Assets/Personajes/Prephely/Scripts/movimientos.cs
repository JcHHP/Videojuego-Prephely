using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientos : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator animador;
    public float x, y;

    public Rigidbody rigidBody;
    public float fuerzaDeSalto = 8f;
    public bool saltarDisponible;
    void Start()
    {
        saltarDisponible = false;
        animador = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
    }
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animador.SetFloat("velocidadX", x);
        animador.SetFloat("velocidadY", y);

        if (saltarDisponible)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animador.SetBool("Salto", true);
                rigidBody.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
            }
            animador.SetBool("Toco suelo", true);
        }
        else
        {
            caer();
        }
    }
    void caer()
    {
        animador.SetBool("Toco suelo", false);
        animador.SetBool("Salto", false);
    }
}