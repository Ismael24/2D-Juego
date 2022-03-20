using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Script que controlar� al enemigo m�s debil de este juego, tiene un dise�o b�sico en el que se queda parado x segundos y avanza otros desde una posici�n "a" a una posici�n "b"
 * @author Ismael Paloma Narv�ez
 */
public class EnemySlime : MonoBehaviour
{
    public static EnemySlime instance;
    public float moveSpeed;
    public Transform rightPoint, leftPoint;

    private bool movingRight;

    private Rigidbody2D rigid;

    public SpriteRenderer sprite;
    public float moveTime, waitTime;
    private float moveCount, waitCount;

    public Animator anim;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        leftPoint.parent = null;
        rightPoint.parent = null;  
        
        movingRight = true;

        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;
            if (movingRight)
            {
                rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);

                sprite.flipX = false;

                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                rigid.velocity = new Vector2(-moveSpeed, rigid.velocity.y);
                sprite.flipX = true;

                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }



            }

            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }


            anim.SetBool("isMoving",true);

        }
        else if (waitCount > 0) 
        {
            waitCount -= Time.deltaTime;
            rigid.velocity = new Vector2(0f, rigid.velocity.y);

            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * .75f, waitTime * 1.25f);
            }
            anim.SetBool("isMoving", false);



        }

    }
}
