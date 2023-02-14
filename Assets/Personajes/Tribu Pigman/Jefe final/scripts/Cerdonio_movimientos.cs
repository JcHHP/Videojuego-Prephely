using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerdonio_movimientos : MonoBehaviour
{

    public int rutina;
    public float cronometro;
    public Animator animacion_cerdonio;
    public Quaternion angulo; //maneja el ángulo
    public float grado;  //para el grado de rotación
    public GameObject buscar_prephely;
    public bool atacar;



    void Start()
    {

        animacion_cerdonio.GetComponent<Animator>();
        buscar_prephely = GameObject.Find("Prephely");
    }

    public void comportamiento()
    {


        //Si la distancia del jugador es mayor a 5
        if (Vector3.Distance(transform.position, buscar_prephely.transform.position) >= 10)
        {
            //que no corra,y no ataque sea falso 
            animacion_cerdonio.SetBool("correr", false);
            animacion_cerdonio.SetBool("atacar", false);
            atacar = false;


            cronometro += 1 * Time.deltaTime;

            if (cronometro >= 2)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    animacion_cerdonio.SetBool("caminar", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    animacion_cerdonio.SetBool("caminar", true);
                    break;
            }

        } //sino que empiece a correr y perseguir enemigo

        else
        {

            //Cuando la distancia sea mayor a 1
            if (Vector3.Distance(transform.position, buscar_prephely.transform.position) >= 6)
            {

                atacar = false;
                //crear variable lookPos = que tenga lo posicion del target- la posicion actual
                var lookPos = buscar_prephely.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                //activar la rotacion
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                //animacion caminar sea falso y activamos la animacion correr
                animacion_cerdonio.SetBool("caminar", false);
                animacion_cerdonio.SetBool("correr", true);
                transform.Translate(Vector3.forward * 3 * Time.deltaTime);
                animacion_cerdonio.SetBool("atacar", false);
                //Traslación
              

            }
            else if(Vector3.Distance(transform.position, buscar_prephely.transform.position) <= 6)
            {

                buscar_prephely = GameObject.Find("Prephely");
                var lookPos = buscar_prephely.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);

                //activar la rotacion
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                animacion_cerdonio.SetBool("caminar", false);
                animacion_cerdonio.SetBool("correr", false);
                animacion_cerdonio.SetBool("atacar", true);
                atacar = true;
            }
           
        }
    }


    void Update()
    {
        comportamiento();
    }
}
