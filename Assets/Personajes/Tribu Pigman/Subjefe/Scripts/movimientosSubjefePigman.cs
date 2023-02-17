using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movimientosSubjefePigman : MonoBehaviour
{
    private logicaManosSubjefePigman logicaManos;
    private logicaRoca logicaRoca;
    public float tiempoDeGuardia;
    public float cronometro2;
    public bool ataco = false;
    private Animator animator;
    public Quaternion angulo;
    public float grado;
    private GameObject objetivo;
    private GameObject roca;
    private float velocidadRoca;
    private int direccionGuardia;
    private AudioSource sonidosSubjefe;
    public AudioClip sonidoLanzarRoca;
    public AudioClip sonidoInvocar;
    void Start()
    {
        logicaManos = FindObjectOfType<logicaManosSubjefePigman>();
        logicaRoca = FindObjectOfType<logicaRoca>();
        animator = GetComponent<Animator>();
        objetivo=GameObject.Find("Prephely");
        roca = GameObject.Find("Roca");
        direccionGuardia = 0;
        sonidosSubjefe = GetComponent<AudioSource>();
    }

    void Update()
    {
        velocidadRoca = roca.GetComponent<Rigidbody>().velocity.magnitude;

        if (Vector3.Distance(transform.position, objetivo.transform.position) >=35) //Saber si está a 35 unidades de Prephely
        {
            cronometro2 = 0;
            animator.SetBool("atacar", false);
            hacerGuardia();

        }else if (Vector3.Distance(transform.position, objetivo.transform.position) >= 10)
        {
            animator.SetBool("invocar", false);
            var lookPos = objetivo.transform.position - transform.position;
            lookPos.y = 0;
            var rotacion = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 3);

            cronometro2 += Time.deltaTime;

            if (!ataco && cronometro2 >= 0.5f)
            {
                animator.SetBool("atacar", true);
                sonidosSubjefe.PlayOneShot(sonidoLanzarRoca);
                Invoke("tirarPiedra", 0.4f);
                ataco = true;
                cronometro2 = 0;
            }

            if (ataco && logicaRoca.rocaFueClonada == true)
            {
                animator.SetBool("atacar", false);
                ataco = false;
                cronometro2 = 0;
                logicaRoca.rocaFueClonada = false;
                logicaRoca.clonacion = false;
            }
        }
        else
        {
            sonidosSubjefe.PlayOneShot(sonidoInvocar);
            animator.SetBool("invocar", true);
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
    void tirarPiedra() 
    {
        logicaManos.agarraPiedra(objetivo);
    }
}