using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicavida_taruca : MonoBehaviour
{

    public Animator animacion_taruca;
    public int vidaTaruca = 150;

    void Update()
    {
        if (vidaTaruca <= 0)
        {
            animacion_taruca.Play("morir");

            Invoke("pararJuego", 3f);
        }
    }

    void pararJuego()
    {
        Time.timeScale = 0;

    }
}
