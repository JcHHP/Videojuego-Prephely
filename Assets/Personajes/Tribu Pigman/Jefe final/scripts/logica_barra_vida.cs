using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logica_barra_vida : MonoBehaviour
{

    public int vidMax;
    public float vidaActual;
    public Image imagenBarraVida;
        
        
       
    void Start()
    {
        vidaActual = vidMax;  //Cuando empieze el juego la vida = vida máxima
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();

        if (vidaActual <= 0)  //si la vida es 0 
        {
            gameObject.SetActive(false);        
        }
    }

    public void RevisarVida()
    {
        imagenBarraVida.fillAmount= vidaActual/vidMax;
    }
}
