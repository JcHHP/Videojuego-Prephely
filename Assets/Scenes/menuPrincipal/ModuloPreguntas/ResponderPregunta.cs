using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResponderPregunta : MonoBehaviour {

	public Text canva_puntos;
    public int puntosPorRespuesta;
	public GameObject activadorPregunta;
	public GameObject Pregunta;
	public AudioClip Correcto;
    public AudioClip inCorrecto;
	private AudioSource sonido;
	private Color verdeColor = Color.green;
	private Color rojoColor= Color.red;
    public Botones botones;
    //public GameObject Enemigo;
    //public Button myButton ;
    //public GameObject r;


    public static int contador;
    public static int puntos;

	void Start (){
       // Enemigo = GameObject.Find("Subjefe Pigman");

        botones = GetComponentInParent<Botones>();

        canva_puntos.text = "puntos: " + puntos;

        sonido = GetComponent<AudioSource>();

        if (puntosPorRespuesta == 1)
        {
           sonido.clip = Correcto;
        }
        else
		{
            sonido.clip = inCorrecto;
        }


    }

	public void Preguntas(){
		contador += 1;
        puntos +=puntosPorRespuesta;
		StartCoroutine (res_correcta ());
	}

	IEnumerator res_correcta(){

        if (puntosPorRespuesta == 1)
        {
            gameObject.GetComponent<Image>().color = verdeColor;
        }else
		{
            gameObject.GetComponent<Image>().color = rojoColor;
        }

        sonido.Play();
		canva_puntos.text = "puntos: " + puntos;
   
        botones.verifyIsPressed(false);
        yield return new WaitForSeconds (2f);
		canva_puntos.text = "puntos: " + puntos;
       

        Destroy (Pregunta);

        // Destroy (activadorPregunta);
       

      //  Enemigo.GetComponent<CapsuleCollider> ().enabled = false;
	}

    

}
