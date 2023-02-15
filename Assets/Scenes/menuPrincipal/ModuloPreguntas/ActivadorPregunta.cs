using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;

public class ActivadorPregunta : MonoBehaviour {

	public GameObject Pregunta;
    private GameObject hijo;
    public List<GameObject> gameObjectListP;
    //public List<GameObject> gameObjectListAux;
    private GameObject objetoCanva;
    public movimientos Prephely; // obtener scrip 
    public GameObject prephelyObj;
    public int contador = 0;
    public ResponderPregunta canPreguntas;

    //public GameObject canva;
    // Use this for initialization
    void Start () {
       
        Prephely =prephelyObj.GetComponent<movimientos>();
    
       
        objetoCanva = GameObject.Find("CanvasPreguntas");
        hijo = objetoCanva.transform.GetChild(1).gameObject;
       
        
        // iniciando lista
        gameObjectListP = new List<GameObject>();

        // Añadir algunos GameObjects a la lista
        for (int i = 0; i < hijo.transform.childCount; i += 1)
        {
           gameObjectListP.Add(hijo.transform.GetChild(i).gameObject);
        }

        gameObjectListP = gameObjectListP.OrderBy(x => Random.value).ToList();

        for ( int i=0 ;i< gameObjectListP.Count ; i+= 1) 
        {
            gameObjectListP[i].SetActive(false);
           
        }

    }

    private void Update()
    {
        if(ResponderPregunta.contador== gameObjectListP.Count)
        {
            Prephely.GetComponent<movimientos>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider col){

        switch (col.gameObject.tag){
		case "Prephely":

                Prephely.GetComponent<movimientos>().enabled = false;

                for (int i = 0; i < gameObjectListP.Count; i += 1)
                {
                    gameObjectListP[i].SetActive(true);

                }
                break;
        }
	}
	void OnTriggerExit(Collider col){
        /*
		switch (col.gameObject.tag){
		case "Prephely":

                for (int i = 0; i < gameObjectListP.Count; i += 1)
                {
                     gameObjectListP[i].SetActive(false);
                }
                break;
        }*/

    }


}
