using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicavida_allqamari : MonoBehaviour
{
    public Animator animacion_allqamari;
    public int vidaAllqamari = 150;

    private void Start()
    {

    }
    void Update()
    {
        if (vidaAllqamari <= 0)
        {
            animacion_allqamari.Play("morir");

            Invoke("pararJuego", 3f);
        }
    }

    void pararJuego()
    {
        Time.timeScale = 0;

    }
}
