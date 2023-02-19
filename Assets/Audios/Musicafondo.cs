using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicafondo : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource musicas;
    void Start()
    {
        musicas= GetComponent<AudioSource>();
        musicas.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
