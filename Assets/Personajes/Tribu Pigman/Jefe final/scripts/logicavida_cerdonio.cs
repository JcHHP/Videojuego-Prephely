using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicavida_cerdonio : MonoBehaviour
{
    public Animator animacion_cerdonio;
    public int vidaCerdonio = 150;
    public Activador2Pregunta activar2Pregunta;
    public float seg;

    private void Start()
    {
        activar2Pregunta = GetComponentInParent<Activador2Pregunta>();

    }
    void Update()
    {
        if (vidaCerdonio <= 0)
        {
                animacion_cerdonio.Play("morir");
                Invoke("VerMensajeTriunfo", 4f);
            
            // Invoke("pararJuego", 3f);
        }
    }
  
    void pararJuego()
    {
        Time.timeScale = 0;
     
    }

    void VerMensajeTriunfo()
    {
        activar2Pregunta.VerMensajeTriunfo();
    }




}
