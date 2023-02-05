using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaRoca : MonoBehaviour
{
    public bool rocaClonada;
    private void OnCollisionEnter(Collision objeto)
    {
        if (objeto.gameObject.tag == "Piso")
        {
            rocaClonada=true;
        }
    }
}
