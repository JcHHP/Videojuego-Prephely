using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicateoria : MonoBehaviour
{
    public Image barraDeTeoria;
    public int TeoriaMax=3; 
    public float Teoria;
    public GameObject cerca;

    public ActivadorPregunta activarPregunta;
    public ActivadorPregunta3 activarPregunta3;
    // Start is called before the first frame update
    void Start()
    {
        activarPregunta = FindObjectOfType<ActivadorPregunta>();
        activarPregunta3 = FindObjectOfType<ActivadorPregunta3>();
        Teoria = 0;
    }

    // Update is called once per frame
    void Update()
    {
        desbloquearCerca();
        RevisarTeoria();
        if (activarPregunta)
        {
            if (Teoria == 3)
            {
                Invoke("VerTeoria", 1f);
            }
        }

        if (activarPregunta3)
        {
            if (Teoria == 3)
            {
                Invoke("VerTeoria3", 1f);
            }
        }


    }

    public void RevisarTeoria()
    {
        barraDeTeoria.fillAmount = Teoria / TeoriaMax;
    }
    public void OnCollisionEnter(Collision objeto)
    {
        if (objeto.gameObject.CompareTag("Pergamino"))
        {
            Teoria += 1;
            barraDeTeoria.fillAmount = Teoria / TeoriaMax;
            Destroy(objeto.gameObject);
        }
    }
    void desbloquearCerca()
    {
        if(Teoria == TeoriaMax)
        {
            cerca.SetActive(false);
        }
    }

    void VerTeoria()
    {
        activarPregunta.VerTeoria();
    }

    void VerTeoria3()
    {
        activarPregunta3.VerTeoria();
    }
}
