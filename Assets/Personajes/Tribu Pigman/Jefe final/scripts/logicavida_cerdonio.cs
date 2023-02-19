using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicavida_cerdonio : MonoBehaviour
{
    public Animator animacion_cerdonio;
    public int vidaCerdonio = 150;
    
    private void Start()
    {
        
    }
    void Update()
    {
        if (vidaCerdonio <= 0)
        {
            animacion_cerdonio.Play("morir");
            
            Invoke("pararJuego", 3f);
        }
    }
  
    void pararJuego()
    {
        Time.timeScale = 0;
     
    }
}
