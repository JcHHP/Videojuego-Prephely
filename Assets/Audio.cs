using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource soundPlayer;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BotonClick()
    {
        soundPlayer.Play();
    }
}
