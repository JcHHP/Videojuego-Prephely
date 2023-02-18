using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taruca_movimientos : MonoBehaviour
{
    public Canvas Pregunta;

    public Animator animacion_taruca;

    public GameObject buscar_prephely;

    void Start()
    {
        animacion_taruca.GetComponent<Animator>();
        buscar_prephely = GameObject.Find("Prephely");
    }
    public void comportamiento()
    {


        if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 20)
        {

            animacion_taruca.SetBool("sentada_pararse", true);
            animacion_taruca.SetBool("lanzar_pregunta", false);
        }



        if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 6)
        {
           animacion_taruca.SetBool("lanzar_pregunta", true);


            //Aparecer preguntas
            //Pregunta.SetActive(true);

        }
    }


    void Update()
    {
        comportamiento();
    }
}
