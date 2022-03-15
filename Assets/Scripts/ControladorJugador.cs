using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    public static ControladorJugador instance;
    public float velocidadMovimiento;
    public Rigidbody2D rigid;

    public bool Dash;
    public float Dash_T;
    public float Speed_Dash;
   
    public float jumpForce;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;
    private bool isGrounded;
    private bool doubleJump;
    private bool girado;
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


            if (Input.GetKey(KeyCode.E))
            {
                anim.SetBool("Attack", true);
                //solo si está parado
                //Audio.instance.PlaySSFX(0);
                //si no lo está :
                Audio.instance.PlaySSFX(2);

            }
            else
            {
                anim.SetBool("Attack", false);
            }



            if (isGrounded)
            {
                doubleJump = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    Audio.instance.PlaySSFX(3);
                    rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
                }
                else
                {
                    if (doubleJump)
                    {
                        Audio.instance.PlaySSFX(3);
                        rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
                        doubleJump = false;
                    }

                }




            }

            if (Input.GetKey(KeyCode.S))
            {
                if (!girado)
                {
                    Dash_T += 1 * Time.deltaTime;
                    if (Dash_T < 0.35f)
                    {
                        Dash = true;
                        anim.SetBool("dash", true);
                        transform.Translate(Vector3.right * Speed_Dash * Time.fixedDeltaTime);

                    }
                    else
                    {
                        Dash = false;
                        anim.SetBool("dash", false);
                    }

                }
                else {
                    Dash_T += 1 * Time.deltaTime;
                    if (Dash_T < 0.35f)
                    {
                        Dash = true;
                        anim.SetBool("dash", true);
                        transform.Translate(Vector3.left * Speed_Dash * Time.fixedDeltaTime);

                    }
                    else
                    {
                        Dash = false;
                        anim.SetBool("dash", false);
                    }


                }

            }
            else 
            {
                Dash = false;
                anim.SetBool("dash", false);
                Dash_T = 0;

            }



            if (rigid.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);

                girado = true;
            }
            else if (rigid.velocity.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
               
                girado = false;

            }




        }
        else 
        {
           
            knockBackCounter -= Time.deltaTime;
            if (!girado)
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
