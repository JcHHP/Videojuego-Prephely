using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResponderPregunta : MonoBehaviour {

	public Text canva_puntos;
    public int puntosPorRespuesta;
	public GameObject Pregunta;
	public AudioClip Correcto;
    public AudioClip inCorrecto;
	private AudioSource sonido;
	private Color verdeColor = Color.green;
	private Color rojoColor= Color.red;
    public Botones botones;

    public logicaVidaSubjefes Subjefe;  // CAMBIAR
    public GameObject SubjefeObj;
    public logicaVidaPrephely VidaPrifely;
    public GameObject VidaPrifelyObj;
    public ActivadorPregunta activarPregunta;
  
    public GameObject objetoCanvas;
    public int VidaEnemigo;

    private float seg;
   
    public static int contador;
    public static int contadorTeorias;
    public static int puntos;

	void Start (){
     
        objetoCanvas = GameObject.Find("CanvasPreguntas");

        activarPregunta = FindObjectOfType<ActivadorPregunta>();

        SubjefeObj =GameObject.Find("Subjefe Pigman");
        Subjefe = SubjefeObj.GetComponent<logicaVidaSubjefes>();  // CAMBIAR

        VidaPrifelyObj = GameObject.Find("Prephely");
        VidaPrifely = VidaPrifelyObj.GetComponent<logicaVidaPrephely>();

        VidaEnemigo = Subjefe.vidaSubjefe;
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
          if(Subjefe.vidaSubjefe <= 0 | VidaPrifely.vidaPrephely <= 0 )
        {
            seg += Time.deltaTime;
            if (seg > 2)
            {
                Destroy(objetoCanvas.transform.GetChild(1).gameObject);
            }
        }

      
            if (contadorTeorias == activarPregunta.NumTeoria)
            {
                seg += Time.deltaTime;
                if (seg > 1)
                {
                    Destroy(objetoCanvas.transform.GetChild(2).gameObject);
                    contadorTeorias = 0;
                }
            }
       
    }

	public void Preguntas(){
		contador += 1;
        puntos +=puntosPorRespuesta;
		StartCoroutine (res_correcta ());
	}

    public void Teorias()
    {
        contadorTeorias += 1;
        puntos += puntosPorRespuesta;
        StartCoroutine(res_correcta());
    }

    IEnumerator res_correcta(){


        if (puntosPorRespuesta == 1)
        {
            gameObject.GetComponent<Image>().color = verdeColor;
            Subjefe.vidaSubjefe = Subjefe.vidaSubjefe - 250;

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
