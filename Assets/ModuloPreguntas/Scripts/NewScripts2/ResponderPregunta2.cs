using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResponderPregunta2 : MonoBehaviour {

	public Text canva_puntos;
    public int puntosPorRespuesta;
	public GameObject Pregunta;
	public AudioClip Correcto;
    public AudioClip inCorrecto;
	private AudioSource sonido;
	private Color verdeColor = Color.green;
	private Color rojoColor= Color.red;
    public Botones botones;

    public logicavida_cerdonio jefe;  // CAMBIAR
    public GameObject SubjefeObj;
    public logicaVidaPrephely VidaPrifely;
    public GameObject VidaPrifelyObj;
    public Activador2Pregunta activarPregunta;
   
    public GameObject objetoCanvas;
    public int VidaEnemigo;

    private float seg;
   
    public static int contador;
    public static int contadorTeorias;
    public static int puntos;

	void Start (){
     
        objetoCanvas = GameObject.Find("CanvasPreguntas");

        activarPregunta = FindObjectOfType<Activador2Pregunta>();
        jefe = FindObjectOfType<logicavida_cerdonio>();

        VidaPrifelyObj = GameObject.Find("Prephely");
        VidaPrifely = VidaPrifelyObj.GetComponent<logicaVidaPrephely>();

        botones = GetComponentInParent<Botones>();

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
    public void Update()
    {
          if(jefe.vidaCerdonio <= 0 | VidaPrifely.vidaPrephely <= 0 )
        {
            seg += Time.deltaTime;
            if (seg > 2)
            {
                Destroy(objetoCanvas.transform.GetChild(1).gameObject);
            }
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
             jefe.vidaCerdonio =  jefe.vidaCerdonio - 50;

        }
        if (puntosPorRespuesta == -1)
        {
            gameObject.GetComponent<Image>().color = rojoColor;
            VidaPrifely.vidaPrephely = VidaPrifely.vidaPrephely - 50;
        }

        sonido.Play();
   
        botones.verifyIsPressed(false);
        yield return new WaitForSeconds (2f);
		
        Destroy (Pregunta);
       
	}

    

}
