using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class controladorEscena : MonoBehaviour
{
    private AudioSource musicas;
    public GameObject canvasMenu;
    public GameObject canvasEleccionNivel;

    private void Start()
    {
        musicas = GetComponent<AudioSource>();
        musicas.Play();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvasEleccionNivel.SetActive(false);
            canvasMenu.SetActive(true);
        }
    }
    public void cargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
