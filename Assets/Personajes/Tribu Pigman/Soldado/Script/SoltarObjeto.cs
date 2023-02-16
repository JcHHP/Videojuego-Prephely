using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoltarObjeto : MonoBehaviour
{
    public GameObject objetoASoltar;

    public void Morir()
    {
        GameObject objeto = Instantiate(objetoASoltar, transform.position, Quaternion.identity);
        Rigidbody objetoRb = objeto.GetComponent<Rigidbody>();
        objetoRb.AddForce(Random.insideUnitSphere * 5, ForceMode.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

