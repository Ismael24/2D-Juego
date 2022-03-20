using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Script algo más complejo sobre el comportamiento de otro enemigo (samurai)
 * @author Ismael Paloma Narváez
 */
public class EnemigoStrong : MonoBehaviour
{
    public static EnemigoStrong instance;
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direccion;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    public bool atacando;

    public float rango_vision;
    public float rango_ataque;
    public GameObject rango;
    public GameObject hit;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Comportamientos();
    }
    //en cuanto a este comportamniento el enemigo avanzara desde un punto a otro de manera aleatoria, tanto la parada como el avance.
    //si en su rango entra el target en este caso nuestro jugador empezará a avanzar de manera más rapida hacie el target, si volvemos a salir volverá a su rutina.
    //si entra en otro rango predefinido esté parará para atacar al target
    public void Comportamientos() 
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_vision && !atacando) 
        {

            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;

            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
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
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            break;
                        case 1:
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);

                            break;


                    }
                    ani.SetBool("walk", true);
                    break;




            }
            

        }
        else
        {
            if (Mathf.Abs(transform.position.x - target.transform.position.x) < rango_vision && !atacando)
            {
                if (transform.position.x < target.transform.position.x)
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    ani.SetBool("attack", false);

                }
                else
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    ani.SetBool("attack", false);

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
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    ani.SetBool("walk", false);
                    ani.SetBool("run", false);

                }
            }


        }



    }
    //control de animaciones
    public void Final_Ani() 
    {
        ani.SetBool("attack", false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }
    //activación del collider de ataque
    public void ColliderWeaponTrue()
    {
        hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    //desactivación del collider de ataque
    public void ColliderWeaponFalse()
    {
        hit.GetComponent<BoxCollider2D>().enabled = false;
    }
    //funcion que decide si el personaje va a aparecer o no
    public void noAparezco()
    {
        this.gameObject.SetActive(false);
    }
}
