using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaVidaSubjefe : MonoBehaviour
{
    public Animator animador;
    public int vidaSubjefe = 1000;
    void Update()
    {
        if(vidaSubjefe < 500)
        {
            Debug.Log("Menos");
        }
    }
    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject.CompareTag("Espada"))
        {
            vidaSubjefe -= 10;
            animador.SetBool("atacado", true);
            Invoke("pararAtacado", 1);
        }
    }
    void pararAtacado()
    {
        animador.SetBool("atacado", false);
    }
}
