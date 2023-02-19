using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class controladorEscena : MonoBehaviour
{
    private AudioSource musicas;

    private void Start()
    {
        musicas = GetComponent<AudioSource>();
        musicas.Play();
    }
    public void cargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
