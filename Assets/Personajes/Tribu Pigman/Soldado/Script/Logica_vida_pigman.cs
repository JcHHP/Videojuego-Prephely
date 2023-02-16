using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logica_vida_pigman : MonoBehaviour
{

    public int vidMaxSoldadoPig;
    public float vidaActualSolpig;
    public Image imgBarraVida;
    public Animator anim_soldado;
    public GameObject objetoASoltar;
    public GameObject Corazon;
    private bool objetoYaInstanciado = false;
    private bool objetoYaInstanciado2 = false;
    private int probabilidadDeSoltar = 2;


    void Start()
    {
        vidMaxSoldadoPig = 50;
        vidaActualSolpig = vidMaxSoldadoPig;  //Cuando empieze el juego la vida = vida máxima
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();

        if (vidaActualSolpig <= 0)  //si la vida es 0 
        {
            //gameObject.SetActive(false);
            anim_soldado.SetBool("muere", true);
            Invoke("desactivar",4f);
            Invoke("SoltarPergamino", 4f);
            Invoke("SoltarCorazon", 4f);
        }
    }

    public void RevisarVida()
    {
        imgBarraVida.fillAmount = vidaActualSolpig / vidMaxSoldadoPig;
    }

    public void desactivar()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject.CompareTag("Espada"))
        {
            vidaActualSolpig -= 2.5f;
            imgBarraVida.fillAmount = vidaActualSolpig / vidMaxSoldadoPig;
        }
    }

    public void SoltarPergamino()
    {
        
        if (!objetoYaInstanciado)
        {
            GameObject objeto = Instantiate(objetoASoltar, transform.position, Quaternion.identity);
            Rigidbody objetoRb = objeto.GetComponent<Rigidbody>();
            objetoRb.AddForce(Random.insideUnitSphere * 5, ForceMode.Impulse);
            objetoYaInstanciado = true;
        }
    }

    public void SoltarCorazon()
    {
    
        if (!objetoYaInstanciado2 && Random.Range(1, 5) == probabilidadDeSoltar)
        {
            Instantiate(Corazon, transform.position, transform.rotation);
            objetoYaInstanciado2 = true;
        }
    }
}
