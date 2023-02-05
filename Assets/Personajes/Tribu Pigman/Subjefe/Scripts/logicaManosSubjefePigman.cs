using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaManosSubjefePigman : MonoBehaviour
{
    public Transform posicionManos;
    public Transform direccionCuerpo;
    public GameObject piedra;
    public void agarraPiedra(GameObject objetivo)
    {
        piedra.transform.SetParent(posicionManos);
        piedra.transform.position = posicionManos.position;
        piedra.transform.rotation= direccionCuerpo.rotation;
        piedra.GetComponent<Rigidbody>().isKinematic = true;
        Invoke("tirarPiedra", 0.5f);
    }
    public void tirarPiedra()
    {
        piedra.transform.SetParent(null);
        piedra.GetComponent<Rigidbody>().isKinematic = false;
        piedra.GetComponent<Rigidbody>().AddForce(direccionCuerpo.forward * 40, ForceMode.Impulse);
    }
}
