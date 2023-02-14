using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JEFE_PREGUNTA : MonoBehaviour
{
    public GameObject Pregunta;
    
    public Animator animacion_cerdonio;
  //para el grado de rotación
    public GameObject buscar_prephely;
   
  void Start()
    {
        animacion_cerdonio.GetComponent<Animator>();
        buscar_prephely = GameObject.Find("Prephely");
    }


    public void comportamiento()
    {


        //Si la distancia del jugador es mayor a 4
        if (Vector3.Distance(transform.position, buscar_prephely.transform.position) >= 4)
        {
            //que no corra,y no ataque sea falso 
            animacion_cerdonio.SetBool("lanzar_pregunta", false);
        }

        else if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 6)
        {
            animacion_cerdonio.SetBool("lanzar_pregunta", true);
          //  Pregunta.SetActive(true);
        }

    }


    // Update is called once per frame
    void Update()
    {
        comportamiento();
    }
}
