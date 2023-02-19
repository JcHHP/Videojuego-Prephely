using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
using JetBrains.Annotations;

public class Activador2Pregunta : MonoBehaviour {

	public GameObject Pregunta;
    private GameObject hijo;
    private GameObject hijo2;
    private GameObject hijo3;
    public List<GameObject> gameObjectListP;
 
    private GameObject objetoCanva;
    public movimientos Prephely; // obtener scrip 
    public GameObject prephelyObj;
    public logicavida_cerdonio jefe;
    public int contador = 0;
   // public int NumTeoria;
   
    public GameObject SubjefeObj;

    public logicaVidaSubjefes Subjefe;  // CAMBIAR

    void Start () {

        jefe = FindObjectOfType<logicavida_cerdonio>();
        // SubjefeObj = GameObject.Find("Subjefe Pigman");
        prephelyObj = GameObject.Find("Prephely");
        Prephely =prephelyObj.GetComponent<movimientos>();
 
        objetoCanva = GameObject.Find("CanvasPreguntas");
        hijo = objetoCanva.transform.GetChild(1).gameObject;
        hijo2 = objetoCanva.transform.GetChild(2).gameObject;
        hijo2.gameObject.SetActive(false);

        hijo3 = objetoCanva.transform.GetChild(3).gameObject;
        //  NumTeoria = hijo2.transform.childCount;

        // iniciando lista
        gameObjectListP = new List<GameObject>();

        // Añadir algunos GameObjects a la lista
        for (int i = 0; i < hijo.transform.childCount; i += 1)
        {
            gameObjectListP.Add(hijo.transform.GetChild(i).gameObject);
        }
        gameObjectListP = gameObjectListP.OrderBy(x => Random.value).ToList();

        for ( int i=0 ;i< hijo.transform.childCount; i+= 1) 
        {
            hijo.transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i <hijo3.transform.childCount; i += 1)
        {
                hijo3.transform.GetChild(i).gameObject.SetActive(false);
           
            //hijo2.transform.GetChild(i).gameObject.SetActive(false);
           
        }

    }

    private void Update()
    {
        if(ResponderPregunta.contador== gameObjectListP.Count)
        {
            Prephely.GetComponent<movimientos>().enabled = true;
        }
        // CAMBIAR
       // if (SubjefeObj.GetComponent<logicaVidaSubjefes>().vidaSubjefe <= 0)
       // {
         //   Prephely.GetComponent<movimientos>().enabled = true;

       // }
    }

    public void ActivarPreguntas()
    {
        if (hijo)
        {

            Prephely.GetComponent<movimientos>().enabled = false;
             jefe.GetComponent<AudioSource>().enabled = false;

            for (int i = 0; i < gameObjectListP.Count; i += 1)
            { if (gameObjectListP[i])
                {
                    gameObjectListP[i].SetActive(true);
                }
            }

           
        }
        else {
            Prephely.GetComponent<movimientos>().enabled = true;
            jefe.GetComponent<AudioSource>().enabled = true;
        }
       
    }

    public void VerMensajeTriunfo()
    {
        if (hijo3)
        {
            Prephely.GetComponent<movimientos>().enabled = false;
            jefe.GetComponent<AudioSource>().enabled = false;
            hijo3.transform.GetChild(0).gameObject.SetActive(true);
        }
        
    }

    public void VerMensajeWarning()
    {
        if (hijo3)
        {
            Prephely.GetComponent<movimientos>().enabled = false;
            jefe.GetComponent<AudioSource>().enabled = false;
            hijo3.transform.GetChild(1).gameObject.SetActive(true);
        }

    }

}
