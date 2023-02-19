using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class siguiente_escena : MonoBehaviour
{
    public void CargarEscenaSiguiente(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
}
