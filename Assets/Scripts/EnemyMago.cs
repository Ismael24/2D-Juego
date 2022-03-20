using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Script algo más complejo sobre el comportamiento de otro enemigo (Mago)
 * @author Ismael Paloma Narváez
 */
public class EnemyMago : MonoBehaviour
{
    public static EnemyMago instance;
    public GameObject BulletPrefab;
    public GameObject target;
    public Animator ani;
    private float LastShoot;
    public GameObject hit;
    public GameObject rango;
    public bool atacando;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        target = GameObject.Find("Player");
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //actualizamos la orientación de nuestro enemigo en función del target en este caso nuestro jugador, este no se mueve.
        Vector3 direction = target.transform.position-transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(target.transform.position.x - transform.position.x);
        //distancia a la que empezaremos a disparar en dirección a nuestro tarjet, aplicamos un tiempo para que no dispare demasiado continuo
        if (distance < 100.0f && Time.time > LastShoot + 2.5)
        {
            Shoot();
            Audio.instance.PlaySSFX(12);
            LastShoot = Time.time;
        }
    }
    //función para disparar si no esta atacando a de forma cercana el enemigo al tarjet
    private void Shoot()
    {
        if (atacando == false)
        {
            Vector3 direction = target.transform.position - transform.position;
            if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

            GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
            bullet.GetComponent<BulletScript>().SetDirection(direction);

        }
        
    
    }
    //control de animaciones
    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }
    //activamos el collider de ataque cercano
    public void ColliderWeaponTrue()
    {
        hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    //desactivamos el collider del ataque cercano
    public void ColliderWeaponFalse()
    {
        hit.GetComponent<BoxCollider2D>().enabled = false;
    }
    //controla si el enemigo aparecerá o no
    public void noAparezco() 
    {
        this.gameObject.SetActive(false);
    }


}
