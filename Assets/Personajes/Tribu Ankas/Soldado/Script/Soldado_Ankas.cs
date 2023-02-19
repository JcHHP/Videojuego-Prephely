using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldado_Ankas : MonoBehaviour
{
    // Start is called before the first frame update
    public int rutina;
    public float cronometro;
    public Animator anim_soldado;
    public Quaternion angulo;
    public float grado;
    public GameObject target;
    public bool atacar;
    void Start()
    {
        anim_soldado.GetComponent<Animator>();
        target = GameObject.Find("Prephely");
    }

    public void comportamiento()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 15)
        {
            anim_soldado.SetBool("correr", false);
            anim_soldado.SetBool("atacar", false);
            atacar = false;
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 7)
            {
                rutina = Random.Range(0, 1);
                cronometro = 0;
            }
            switch (rutina)
            {
                /*case 0:
                    anim_soldado.SetBool("caminar", false);
                    break;*/
                case 0:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 1:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim_soldado.SetBool("caminar", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 0.5 && !atacar)
            {
                anim_soldado.SetBool("atacar", false);
                atacar = false;
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                anim_soldado.SetBool("caminar", false);
                anim_soldado.SetBool("correr", true);
                transform.Translate(Vector3.forward * 3 * Time.deltaTime);
                anim_soldado.SetBool("atacar", false);
            }
            else //if(Vector3.Distance(transform.position, target.transform.position) < 0.5)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                anim_soldado.SetBool("caminar", true);
                anim_soldado.SetBool("correr", false);
                //anim_soldado.SetBool("atacar", true);
                atacar = true;
                Invoke("Ataque", 0.3f);
                Invoke("NoAtaque", 0.25f);

            }


        }

    }
    // Update is called once per frame
    void Update()
    {
        comportamiento();

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    morir();
        //}
    }

    void NoAtaque()
    {
        anim_soldado.SetBool("atacar", false);

    }
    void Ataque()
    {
        anim_soldado.SetBool("atacar", true);

    }
}
