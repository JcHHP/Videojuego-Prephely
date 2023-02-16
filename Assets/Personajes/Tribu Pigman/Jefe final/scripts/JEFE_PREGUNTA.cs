using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JEFE_PREGUNTA : MonoBehaviour
{
    public Canvas Pregunta;
    
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


     if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 20)
            {
       
            animacion_cerdonio.SetBool("sentado_pararse", true);
            animacion_cerdonio.SetBool("lanzar_pregunta", false);
            //  Pregunta.SetActive(true);
        }
    if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 6)
        {
            animacion_cerdonio.SetBool("lanzar_pregunta", true );
           
        } 
    }





    // Update is called once per frame
    void Update()
    {
        comportamiento();
    }
}
