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
    // Start is called before the first frame update
    void Start()
    {
        Teoria = 0;
    }

    // Update is called once per frame
    void Update()
    {
        desbloquearCerca();
        RevisarTeoria();
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
}
