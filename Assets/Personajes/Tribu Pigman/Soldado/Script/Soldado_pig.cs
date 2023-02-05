using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldado_pig : MonoBehaviour
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
        if (Vector3.Distance(transform.position, target.transform.position) > 7)
        {
            anim_soldado.SetBool("correr", false);
            anim_soldado.SetBool("atacar", false);
            atacar= false;
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    anim_soldado.SetBool("caminar", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim_soldado.SetBool("caminar", true);
                    break;
            }
        }
        else
        {
            if(Vector3.Distance(transform.position, target.transform.position)>1.2 && !atacar)
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
            else
            {
                anim_soldado.SetBool("caminar", false);
                anim_soldado.SetBool("correr", false);
                anim_soldado.SetBool("atacar", true);
                atacar = true;
            }
            
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        comportamiento();

        if (Input.GetKeyDown(KeyCode.X))
        {
            anim_soldado.SetBool("muere", true);
        }
    }
}
