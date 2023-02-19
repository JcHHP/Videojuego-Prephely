using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaVida_SLC : MonoBehaviour
{
    // Start is called before the first frame update
    public int vidMaxSoldadoLuw;
    public float vidaActualSolLuw;
    public Image imgBarraVida;
    public Animator anim_soldado;
    public GameObject lanza;
    public GameObject objetoASoltar;
    public GameObject Corazon;
    private bool objetoYaInstanciado = false;
    private bool objetoYaInstanciado2 = false;
    private int probabilidadDeSoltar = 3;
    private AudioSource audios;
    public AudioClip soltarBonus;

    void Start()
    {
        vidMaxSoldadoLuw = 30;
        vidaActualSolLuw = vidMaxSoldadoLuw;  //Cuando empieze el juego la vida = vida máxima
        audios = GetComponent<AudioSource>();
        lanza.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();

        if (vidaActualSolLuw <= 0)  //si la vida es 0 
        {
            //gameObject.SetActive(false);
            anim_soldado.Play("Muerte");
            Invoke("desactivar", 2.9f);
            Invoke("SoltarPergamino", 2f);
            Invoke("SoltarCorazon", 2f);
        }
    }

    public void RevisarVida()
    {
        imgBarraVida.fillAmount = vidaActualSolLuw / vidMaxSoldadoLuw;
    }

    public void desactivar()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.gameObject.CompareTag("Espada"))
        {
            anim_soldado.Play("Recibe golpe");
            vidaActualSolLuw -= 5f;
            imgBarraVida.fillAmount = vidaActualSolLuw / vidMaxSoldadoLuw;
        }
    }

    public void SoltarPergamino()
    {

        if (!objetoYaInstanciado)
        {
            audios.PlayOneShot(soltarBonus);
            GameObject objeto = Instantiate(objetoASoltar, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            Rigidbody objetoRb = objeto.GetComponent<Rigidbody>();
            objetoRb.AddForce(new Vector3(3, 7, 3), ForceMode.Impulse);
            objetoYaInstanciado = true;
        }
    }

    public void SoltarCorazon()
    {

        if (!objetoYaInstanciado2 && Random.Range(1, 5) == probabilidadDeSoltar)
        {
            Instantiate(Corazon, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            Rigidbody objetoRb = Corazon.GetComponent<Rigidbody>();
            objetoRb.AddForce(new Vector3(3, 7, 3), ForceMode.Impulse);
            objetoYaInstanciado2 = true;
        }
    }

    void activarColliderArma()
    {
        lanza.GetComponent<BoxCollider>().enabled = true;
    }

    void desactivarColliderArma()
    {
        lanza.GetComponent<BoxCollider>().enabled = false;
    }
}
