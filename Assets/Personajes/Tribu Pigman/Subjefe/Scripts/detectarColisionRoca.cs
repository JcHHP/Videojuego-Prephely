using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectarColisionRoca : MonoBehaviour
{
    private logicaVidaPrephely scriptVidaPrephely;
    private void Start()
    {
        scriptVidaPrephely = FindObjectOfType<logicaVidaPrephely>();
    }
    private void OnCollisionEnter(Collision objeto)
    {
        if (objeto.gameObject.CompareTag("Prephely") && GetComponent<Rigidbody>().velocity.magnitude > 2)
        {
            scriptVidaPrephely.animador.Play("Recibe golpe");
            scriptVidaPrephely.vidaPrephely -= 10;
            scriptVidaPrephely.barraDeVida.fillAmount -= 0.1f;
        }
    }
}
