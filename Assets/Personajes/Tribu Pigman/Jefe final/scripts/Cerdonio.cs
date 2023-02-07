using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerdonio : MonoBehaviour
{

    // Start is called before the first frame update
    public int rutina;
    public float cronometro;
    public Animator anim_jefefinal;
    public Quaternion angulo; //maneja el ángulo
    public float grado;  //para el grado de rotación
    public GameObject target;
    public bool atacar;
    void Start()
    {
        anim_jefefinal.GetComponent<Animator>(); 
        target = GameObject.Find("Prephely");
    }

    public void comportamiento()  //CONTROL DEL COMPORTAMIENTO DE Cerdonio 
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 7)
        {
          
            cronometro += 1 * Time.deltaTime;

            if (cronometro >= 50) 
            {
                rutina = Random.Range(0, 2); 
                cronometro = 0;
            }
            switch (rutina) //control de rutina
            {
                case 0: 
                    anim_jefefinal.SetBool("caminar", false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim_jefefinal.SetBool("caminar", true);
                    break;
            }
        }
 

    }
    // Update is called once per frame
    void Update()
    {
        comportamiento();

  
    }
}
