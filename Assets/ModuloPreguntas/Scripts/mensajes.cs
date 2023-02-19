using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mensajes : MonoBehaviour
{
    public int puntosPorRespuesta;
    public GameObject Pregunta;
    public AudioClip Correcto;
    private AudioSource sonido;
    public Botones botones;
    public GameObject objetoCanvas;
    public int VidaEnemigo;

    private float seg;

    public static int contador;
    public static int puntos;

    void Start()
    {
        objetoCanvas = GameObject.Find("CanvasPreguntas");
        botones = GetComponentInParent<Botones>();

        sonido = GetComponent<AudioSource>();

        if (puntosPorRespuesta == 1)
        {
            sonido.clip = Correcto;
        }

    }
    public void Update()
    {
        if (contador==1)
        {
            seg += Time.deltaTime;
            if (seg > 2)
            {
                Destroy(Pregunta);
            }
        }
        
    }

    public void MensajesJuego()
    {
        sonido.Play();
        contador += 1;
        botones.verifyIsPressed(false);
    }

}