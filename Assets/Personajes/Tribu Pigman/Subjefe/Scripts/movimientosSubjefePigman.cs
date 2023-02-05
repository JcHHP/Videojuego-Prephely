using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movimientosSubjefePigman : MonoBehaviour
{
    private logicaManosSubjefePigman logicaManos;
    private logicaRoca logicaRoca;
    public float cronometro;
    public float cronometro2;
    public float cronometro3;
    public bool ataco = false;
    private Animator animator;
    public Quaternion angulo;
    public float grado;
    private GameObject objetivo;
    private GameObject roca;
    private Vector3 velocidadRoca;
    private int direccionGuardia;
    void Start()
    {
        logicaManos = FindObjectOfType<logicaManosSubjefePigman>();
        logicaRoca = FindObjectOfType<logicaRoca>();
        animator = GetComponent<Animator>();
        objetivo=GameObject.Find("Prephely");
        roca = GameObject.Find("Roca");
        direccionGuardia = 1;
    }

    void Update()
    {
        velocidadRoca = roca.GetComponent<Rigidbody>().velocity;

        if (Vector3.Distance(transform.position, objetivo.transform.position) >=35)
        {
            cronometro2 = 0;
            cronometro3= 0;
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
                Invoke("tirarPiedra", 0.4f);
                ataco = true;
                cronometro2 = 0;
            }

            if (ataco && velocidadRoca.Equals(new Vector3(0, 0, 0)) && logicaRoca.rocaClonada)
            {
                Instantiate(roca);
                animator.SetBool("atacar", false);
                ataco = false;
                logicaRoca.rocaClonada = false;
            }
        }
        else
        {
            animator.SetBool("invocar", true);
        }
    }
    void hacerGuardia()
    {
        cronometro += 1 * Time.deltaTime;

        if (cronometro >= 8)
        {
            angulo = Quaternion.Euler(0, 180 * direccionGuardia, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);

            if (cronometro >= 9.5f)
            {
                if (direccionGuardia == 1)
                {
                    direccionGuardia = 0;
                }
                else
                {
                    direccionGuardia = 1;
                }

                cronometro = 0;
            }
        }
        else
        {
            transform.Translate(0, 0, 2 * Time.deltaTime);
            animator.SetBool("caminar", true);
        }
    }
    void tirarPiedra() 
    {
        logicaManos.agarraPiedra(objetivo);
    }
}