using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaRoca : MonoBehaviour
{
    public GameObject roca;
    public bool rocaFueClonada = false;
    public bool clonacion = false;
    private logicaVidaPrephely scriptVidaPrephely;
    private void Start()
    {
        scriptVidaPrephely= FindObjectOfType<logicaVidaPrephely>();
    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            if (hit.collider.gameObject.tag == "Piso")
            {
                var velocidadRoca = GetComponent<Rigidbody>().velocity;
                GameObject rocaNueva = Instantiate(roca, transform.position, transform.rotation);
                transform.position = new Vector3(0.082f, 1.919f, 0);
                rocaNueva.GetComponent<Rigidbody>().velocity = velocidadRoca;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                logicaRoca scriptRocaNueva = rocaNueva.GetComponent<logicaRoca>();
                Destroy(scriptRocaNueva);
                rocaNueva.AddComponent<detectarColisionRoca>();
                rocaFueClonada = true;
                clonacion = true;
            }
        }
    }

    private void OnCollisionEnter(Collision objeto)
    {
        if (objeto.gameObject.CompareTag("Prephely"))
        {
            scriptVidaPrephely.animador.Play("Recibe golpe");
            scriptVidaPrephely.vidaPrephely -= 10;
            scriptVidaPrephely.barraDeVida.fillAmount -= 0.1f;
        }
    }
}
