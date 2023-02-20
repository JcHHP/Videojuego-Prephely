using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movimientosSubjefeAnkas : MonoBehaviour
{
    public float tiempoDeGuardia;
    public float cronometro2;
    public bool ataco = false;
    private Animator animator;
    public Quaternion angulo;
    public float grado;
    private GameObject objetivo;
    private int direccionGuardia;
    private AudioSource sonidosSubjefe;
    //public AudioClip sonidoInvocar;

    //public ActivadorPregunta activarPregunta;
    private logicaVidaSubjefes Subjefe;
    private int vida = 500;

    private bool invocarReproducido = false;
    void Start()
    {
        //activarPregunta = GetComponentInParent<ActivadorPregunta>();

        Subjefe = GetComponentInParent<logicaVidaSubjefes>();

        animator = GetComponent<Animator>();
        objetivo=GameObject.Find("Prephely");
        direccionGuardia = 0;
        sonidosSubjefe = GetComponent<AudioSource>();
    }

    void Update()
    {
        //vida = Subjefe.vidaSubjefe;
        //velocidadRoca = roca.GetComponent<Rigidbody>().velocity.magnitude;

        if (Vector3.Distance(transform.position, objetivo.transform.position) >=60) //Saber si está a 60 unidades de Prephely
        {
            cronometro2 = 0;
            animator.SetBool("atacar", false);
            hacerGuardia();

        }else if (Vector3.Distance(transform.position, objetivo.transform.position) >= 3 && !invocarReproducido)
        {
            animator.SetBool("caminar", true);
            var lookPos = objetivo.transform.position - transform.position;
            lookPos.y = 0;
            var rotacion = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 3);
            transform.Translate(Vector3.forward * 3 * Time.deltaTime);
        }
        else
        {
            if(vida<= 400)
            {
                if (!invocarReproducido)
                {
                    //sonidosSubjefe.Pause();
                    //sonidosSubjefe.PlayOneShot(sonidoInvocar);
                    animator.Play("Invocar");

                    invocarReproducido = true;
                    //Invoke("Verpregunta", 2f);

                }
            }
            else
            {
                animator.SetBool("atacar", true);
            }
           
        }

        if (vida <= 0)
        {
            Invoke("VerMensajeTriunfo", 4f);
        }
    }
    void hacerGuardia()
    {
        tiempoDeGuardia += 1 * Time.deltaTime;

        if (tiempoDeGuardia >= 3)
        {
            angulo = Quaternion.Euler(0, 180 * direccionGuardia, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);

            if (tiempoDeGuardia >= 4.5f)
            {
                if (direccionGuardia == 1)
                {
                    direccionGuardia = 0;
                }
                else
                {
                    direccionGuardia = 1;
                }

                tiempoDeGuardia = 0;
            }
        }
        else
        {
            transform.Translate(0, 0, 3 * Time.deltaTime);
            animator.SetBool("caminar", true);
        }
    }

    void congelarTiempo()
    {
        Time.timeScale = 0;
    }

    void Verpregunta()
    {
        //activarPregunta.ActivarPreguntas();
    }

    void VerMensajeTriunfo()
    {
        //activarPregunta.VerMensajeTriunfo();
    }
}