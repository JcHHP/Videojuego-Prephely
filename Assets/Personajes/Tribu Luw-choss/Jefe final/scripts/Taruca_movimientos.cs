using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taruca_movimientos : MonoBehaviour
{



    private AudioSource sonidojefe;
    public AudioClip sonidoTaruca;
   
    public Animator animacion_taruca;

    public GameObject buscar_prephely;

    void Start()
    {
        animacion_taruca.GetComponent<Animator>();
        buscar_prephely = GameObject.Find("Prephely");
        sonidojefe = GetComponent<AudioSource>();
    }
    public void comportamiento()
    {
        if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 20)
        {

            animacion_taruca.SetBool("sentado_pararse", true);
            animacion_taruca.SetBool("lanzar_pregunta", false);
            sonidojefe.PlayOneShot(sonidoTaruca);

        }


        if (Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 6)
        {
            animacion_taruca.SetBool("lanzar_pregunta", true);


            sonidojefe.Pause();
            
            //Aparecer Preguntas Aqui

        }
    }





    // Update is called once per frame
    void Update()
    {
        comportamiento();
    }
}
