using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebadaño : MonoBehaviour
{
    public Logica_vida_pigman logicaVidaPig;
    public logicaVidaPrephely logicaVidaPre;
    public float daño = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            logicaVidaPig.vidaActualSolpig -= daño;
            logicaVidaPre.vidaPrephely -= 2;
        }
        
    }
}
