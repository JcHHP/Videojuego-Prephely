using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class menu_inicial : MonoBehaviour
{
  
    public void Continuar()  //EMPEZAR JUEGO
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
    }

    public void Opciones()
    {
        Debug.Log("OPCIONES");
    }

    public void Creditos()
    {
        Debug.Log("CRÉDITOS");
    }

    public void Salir()
    {
        Debug.Log("SALIR");
        Application.Quit();
    }

}
