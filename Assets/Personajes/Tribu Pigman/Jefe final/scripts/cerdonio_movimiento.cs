using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerdonio_movimiento : MonoBehaviour
{
    
    private AudioSource sonidojefe;
    public AudioClip sonidoPigman;
    public AudioClip aparecerPreguntaPigman;

    public Animator animacion_cerdonio;
 
    public GameObject buscar_prephely;
   
  void Start()
    {
        animacion_cerdonio.GetComponent<Animator>();
        buscar_prephely = GameObject.Find("Prephely");
        sonidojefe = GetComponent<AudioSource>();
    }
    public void comportamiento()
    {
     if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 20)
            {
       
            animacion_cerdonio.SetBool("sentado_pararse", true);
            animacion_cerdonio.SetBool("lanzar_pregunta", false);
            sonidojefe.PlayOneShot(sonidoPigman);

        }


    if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 6)
        {
            animacion_cerdonio.SetBool("lanzar_pregunta", true );


            sonidojefe.Pause();
            //
            //Aparecer Preguntas 

        } 
    }





    // Update is called once per frame
    void Update()
    {
        comportamiento();
    }
}
