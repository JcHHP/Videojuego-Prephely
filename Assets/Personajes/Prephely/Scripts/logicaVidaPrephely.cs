using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaVidaPrephely : MonoBehaviour
{
    public int vidaPrephely = 100;
    public Animator animador;
    private CapsuleCollider capsCollider;
    public Image barraDeVida;
    private void Start()
    {
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
}
