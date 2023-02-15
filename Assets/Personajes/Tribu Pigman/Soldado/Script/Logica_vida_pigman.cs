using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logica_vida_pigman : MonoBehaviour
{

    public int vidMaxSoldadoPig;
    public float vidaActualSolpig;
    public Image imgBarraVida;
    public Animator anim_soldado;


    void Start()
    {
        vidMaxSoldadoPig = 50;
        vidaActualSolpig = vidMaxSoldadoPig;  //Cuando empieze el juego la vida = vida máxima
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();

        if (vidaActualSolpig <= 0)  //si la vida es 0 
        {
            //gameObject.SetActive(false);
            anim_soldado.SetBool("muere", true);
            Invoke("desactivar",3f);
        }
    }

    public void RevisarVida()
    {
        imgBarraVida.fillAmount = vidaActualSolpig / vidMaxSoldadoPig;
    }

    public void desactivar()
    {
        gameObject.SetActive(false);
    }
}
