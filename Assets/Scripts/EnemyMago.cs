using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Vector3 direction = target.transform.position-transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(target.transform.position.x - transform.position.x);

        if (distance < 20.0f && Time.time > LastShoot + 2.5)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

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
    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponTrue()
    {
        hit.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void ColliderWeaponFalse()
    {
        hit.GetComponent<BoxCollider2D>().enabled = false;
    }


}
