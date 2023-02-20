using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class volverMenuNiveles : MonoBehaviour
{
    public AudioSource musicas;

    private void Start()
    {
        musicas.Play();
    }
    public void cargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
