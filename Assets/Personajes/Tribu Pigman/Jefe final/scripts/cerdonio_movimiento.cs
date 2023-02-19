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
    private float seg;

    public Activador2Pregunta activar2Pregunta;

    void Start()
    {
        activar2Pregunta = GetComponentInParent<Activador2Pregunta>();
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
                   if (GetComponent<AudioSource>().enabled)
                    {
                     sonidojefe.PlayOneShot(sonidoPigman);
                    }
           }

        if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 6)
        {
            animacion_cerdonio.SetBool("lanzar_pregunta", true );

           //  sonidojefe.Pause();
           // Invoke(" Verpregunta", 1f);
            if (activar2Pregunta)
            {
                seg += Time.deltaTime;
                if (seg > 2)
                {
                    Verpregunta();
                }
            } 

          //  sonidojefe.Pause();
            //
            //Aparecer Preguntas 


        } 
    }


    // Update is called once per frame
    void Update()
    {
        comportamiento();
    }

    void Verpregunta()
    {
        activar2Pregunta.ActivarPreguntas();
    }
}
