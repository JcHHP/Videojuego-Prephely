using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaVidaPrephely : MonoBehaviour
{
    public int vidMaxPrephely=100; //1
    public float vidaPrephely; //2
    public Animator animador;
    private CapsuleCollider capsCollider;
    public Image barraDeVida;

    private float seg;
    public ActivadorPregunta activarPregunta;
    public ActivadorPregunta3 activarPregunta3;
    public Activador2Pregunta activar2Pregunta;
    private void Start()
    {
        activarPregunta = FindObjectOfType<ActivadorPregunta>();
        activarPregunta3 = FindObjectOfType<ActivadorPregunta3>();
        activar2Pregunta = FindObjectOfType<Activador2Pregunta>();
        vidaPrephely = vidMaxPrephely; 
        capsCollider= GetComponent<CapsuleCollider>();
        animador = GetComponent<Animator>();
    }
    void Update()
    {
        if (vidaPrephely<=0)
        {

            seg += Time.deltaTime;
            if (seg > 2)
            {
                animador.Play("Muerte");
                Invoke("destruirCapsulleCollider", 0.7f);
                if (activarPregunta)
                {
                    Invoke("VerMensajeWarning", 2f);
                }

                if (activar2Pregunta)
                {
                    Invoke("VerMensajeWarning2", 2f);
                }

                if (activarPregunta3)
                {
                    Invoke("VerMensajeWarning3", 2f);
                }


            }
           // Invoke("pararJuego", 1.5f);
        }
    }

    void destruirCapsulleCollider()
    {
        Destroy(capsCollider);
    }
    void pararJuego()
    {
        Time.timeScale = 0;
    }

    public void OnTriggerEnter(Collider objeto) //4
    {
        if (objeto.gameObject.CompareTag("Lanza"))
        {
            animador.Play("Recibe golpe");
            vidaPrephely -= 0.25f;
            barraDeVida.fillAmount = vidaPrephely / vidMaxPrephely;
        }
        
    }
    public void OnCollisionEnter(Collision objeto)
    {
        if (objeto.gameObject.CompareTag("Corazon"))
        {

            vidaPrephely += 5f;
            barraDeVida.fillAmount = vidaPrephely / vidMaxPrephely;
            Destroy(objeto.gameObject);
        }
    }

    void VerMensajeWarning() 
    {
        activarPregunta.VerMensajeWarning();
    }

    void VerMensajeWarning2()
    {
        activar2Pregunta.VerMensajeWarning();
    }
    void VerMensajeWarning3()
    {
        activarPregunta3.VerMensajeWarning();
    }

}
