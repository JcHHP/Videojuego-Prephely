using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class siguiente_escena : MonoBehaviour
{
    public GameObject canvasGeneral;
    public GameObject canvasCreditos;
    public void CargarEscenaSiguiente(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
    public void mostrarCreditos()
    {
        canvasCreditos.SetActive(true);
        canvasGeneral.SetActive(false);
    }
    public void cerrarCreditos()
    {
        canvasCreditos.SetActive(false);
        canvasGeneral.SetActive(true);
    }
}
