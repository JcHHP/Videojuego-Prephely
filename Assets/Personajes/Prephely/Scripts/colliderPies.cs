using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderPies : MonoBehaviour
{
    public movimientos movimientosPrephely;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        movimientosPrephely.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        movimientosPrephely.puedoSaltar = false;
    }
}