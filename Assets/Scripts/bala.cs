using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float velocidad;
    private Vector2 Direction;

    private Rigidbody2D Rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        
    }
    void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * velocidad;


    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            other.transform.parent.gameObject.SetActive(false);
        }
    
    }

    public void SetDirection(Vector2 direction) 
    {
        Direction = direction;
    }
}
