using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyi : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;
    public SpriteRenderer sprite;
    void Start()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, points[currentPoint].position) < 0.05f)
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }

        }

        if (transform.position.x < points[currentPoint].position.x)
        {
            sprite.flipX = true;

        } else if (transform.position.x > points[currentPoint].position.x) 
        {
            sprite.flipX = false;   
        
        }

    }
}
