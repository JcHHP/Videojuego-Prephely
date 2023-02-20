using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaVidaSubjefeAnkas : MonoBehaviour
{
    public Animator animador;
    public int vidaSubjefe;
    public Image barraVida;

    private float seg;
    private void Start()
    {
        vidaSubjefe = 500;
    }
    void Update()
    {
        if (vidaSubjefe <= 0)
        {
            seg += Time.deltaTime;
            if (seg > 1)
            {
                animador.Play("Morir");
            }

        }
    }
    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject.CompareTag("Espada"))
        {
            vidaSubjefe -= 10;
            barraVida.fillAmount -= 0.005f;
            animador.Play("ReaccionarAtaque");
        }
    }
    void pararJuego()
    {
        Time.timeScale = 0;
    }
}
