using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    public static ControladorJugador instance;
    public float velocidadMovimiento;
    public Rigidbody2D rigid;
    public float jumpForce;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;
    private bool isGrounded;
    private bool doubleJump;
    public Animator anim;
    private SpriteRenderer sprite;

    public float knockBackLength, knockBackForce;
    public float knockBackCounter;

    private void Awake() 
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter <= 0)
        {
            rigid.velocity = new Vector2(velocidadMovimiento * Input.GetAxis("Horizontal"), rigid.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGround);

            if (isGrounded)
            {
                doubleJump = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
                }
                else
                {
                    if (doubleJump)
                    {
                        rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
                        doubleJump = false;
                    }

                }




            }
            if (rigid.velocity.x < 0)
            {
                sprite.flipX = true;
            }
            else if (rigid.velocity.x > 0)
            {
                sprite.flipX = false;

            }




        }
        else 
        {
            knockBackCounter -= Time.deltaTime;
            if (!sprite.flipX)
            {
                rigid.velocity = new Vector2(-knockBackForce, rigid.velocity.y);
            }
            else 
            {
                rigid.velocity = new Vector2(knockBackForce, rigid.velocity.y);
            }
        }

       
        anim.SetFloat("moveSpeed", Mathf.Abs(rigid.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    public void Knockback()
    {
        knockBackCounter = knockBackLength;
        rigid.velocity = new Vector2(0f, knockBackForce);
    }
}
