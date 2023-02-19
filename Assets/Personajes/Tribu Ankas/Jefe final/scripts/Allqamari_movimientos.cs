using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allqamari_movimientos : MonoBehaviour
{
  
    private AudioSource sonidojefe;
    public AudioClip sonidoPigman;
    public AudioClip aparecerPreguntaPigman;

    public Animator animacion_allqamari;

    public GameObject buscar_prephely;

    void Start()
    {
        animacion_allqamari.GetComponent<Animator>();
        buscar_prephely = GameObject.Find("Prephely");
        sonidojefe = GetComponent<AudioSource>();
    }
    public void comportamiento()
    {
        if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 20)
        {

            animacion_allqamari.SetBool("sentado_pararse", true);
            animacion_allqamari.SetBool("lanzar_pregunta", false);
            sonidojefe.PlayOneShot(sonidoPigman);

        }


        if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 6)
        {
            animacion_allqamari.SetBool("lanzar_pregunta", true);


            sonidojefe.Pause();
            //sonidojefe.PlayOneShot(aparecerPreguntaPigman);
            //Aparecer Preguntas 

        }
    }





    // Update is called once per frame
    void Update()
    {
        comportamiento();
    }
}
