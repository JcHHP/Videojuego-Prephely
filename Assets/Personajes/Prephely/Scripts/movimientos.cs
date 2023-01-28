using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientos : MonoBehaviour
{
    // Start is called before the first frame update
    public float velmov = 5.0f;
    public float velrot = 200.0f;
    private Animator anim;
    public float x, y;

    public Rigidbody rb;
    public float fuerzaDeSalto = 15f;
    public bool puedoSaltar;
    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * velrot, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velmov);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("velocidadX", x);
        anim.SetFloat("velocidadY", y);

        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Salto", true);
                rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
            }
            anim.SetBool("Toco suelo", true);
        }
        else
        {
            EstoyCayendo();
        }
    }
    public void EstoyCayendo()
    {
        anim.SetBool("Toco suelo", false);
        anim.SetBool("Salto", false);
    }
}