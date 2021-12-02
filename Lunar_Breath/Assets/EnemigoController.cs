using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    public float velocidad = 1f;
    public float maxVelocidad = 1f;
    public float healthPoints;

    public int rutina;
    public float cronometro;
    public int direccion;
    public GameObject target;
    public bool atacando;

    public float rango_vision;
    public float rango_ataque;
    public GameObject Rango;
    public GameObject Hit;

    public float damageToGiven;

    private Rigidbody2D rb2d;
    public Animator anima;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();

        target = GameObject.Find("Dippolo");
    }
    public void Comportamientos()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_vision && !atacando)
        {
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    anima.SetBool("Caminar", false);
                    break;

                case 1:
                    direccion = Random.Range(0, 2);
                    rutina++;
                    break;

                case 2:
                    switch (direccion)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
                            break;
                        case 1:
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
                            break;
                    }
                    anima.SetBool("Caminar", true);
                    break;
            }
        }
        else
        {
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_ataque && !atacando)
            {
                if (transform.position.x < target.transform.position.x)
                {
                    anima.SetBool("Caminar", true);
                    transform.Translate(Vector3.right * velocidad * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    anima.SetBool("Atacar", false);
                }
                else
                {
                    anima.SetBool("Caminar", true);
                    transform.Translate(Vector3.right * velocidad * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    anima.SetBool("Atacar", false);
                }
            }
            else
            {
                if (!atacando)
                {
                    if (transform.position.x < target.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    anima.SetBool("Caminar", false);
                }
            }
        }
    }

   


    void Update()
    {
        Comportamientos();
    }
    
   
}
