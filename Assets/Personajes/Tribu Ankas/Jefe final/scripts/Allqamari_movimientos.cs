using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allqamari_movimientos : MonoBehaviour
{
    public Canvas Pregunta;

    public Animator animacion_allqamari;

    public GameObject buscar_prephely;

    void Start()
    {
        animacion_allqamari.GetComponent<Animator>();
        buscar_prephely = GameObject.Find("Prephely");
    }
    public void comportamiento()
    {


        if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 20)
        {

            animacion_allqamari.SetBool("sentado_pararse", true);
            animacion_allqamari.SetBool("lanzar_pregunta", false);
        }



        if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 6)
        {
            animacion_allqamari.SetBool("lanzar_pregunta", true);


            //Aparecer preguntas
            //Pregunta.SetActive(true);

        }
    }


    void Update()
    {
        comportamiento();
    }
}
