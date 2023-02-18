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

    public float velInicial;
    public float velAgachado;

    public GameObject Espada;

    private AudioSource audios;
    public AudioClip sonidoCaminar;
    public AudioClip sonidoAtacar;
    void Start()
    {
        velocidadMovimiento = 5.0f;
        velocidadRotacion = 200.0f;
        saltarDisponible = false;
        animador = GetComponent<Animator>();

        velInicial = velocidadMovimiento;
        velAgachado = velocidadMovimiento * 0.5f;

        Espada.GetComponent<BoxCollider>().enabled = false;
        audios = GetComponent<AudioSource>();
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

            if (Input.GetMouseButtonDown(0))
            {
                animador.SetBool("Atacar", true);
                Invoke("reproducirSonidoAtacar", 0.5f);
                Invoke("dejarAtacar", 1);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                animador.SetBool("agachado", true);
                velocidadMovimiento = velAgachado;
            }
            else
            {
                animador.SetBool("agachado", false);
                velocidadMovimiento = velInicial;
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

    void dejarAtacar ()
    {
        animador.SetBool("Atacar", false);
    }
    void reproducirSonidoAtacar()
    {
        audios.PlayOneShot(sonidoAtacar);
    }

    void activarColliderEspada()
    {
        Espada.GetComponent<BoxCollider>().enabled = true;
    }

    void desactivarCollider()
    {
        Espada.GetComponent<BoxCollider>().enabled = false;
    }
}