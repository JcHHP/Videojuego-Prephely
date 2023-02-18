using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaVidaPrephely : MonoBehaviour
{
    //public int vidaPrephely = 100;
    public int vidMaxPrephely=100; //1
    public float vidaPrephely; //2
    public Animator animador;
    private CapsuleCollider capsCollider;
    public Image barraDeVida;
    private void Start()
    {
        vidaPrephely = vidMaxPrephely; //3
        capsCollider= GetComponent<CapsuleCollider>();
        animador = GetComponent<Animator>();
    }
    void Update()
    {
        if (vidaPrephely<=0)
        {
            animador.Play("Muerte");
            Invoke("destruirCapsulleCollider", 0.7f);
            Invoke("pararJuego", 1.5f);
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


}
