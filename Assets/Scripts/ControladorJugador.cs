using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
/**
 * En este script aplicaremos los distintos controles,animaciones y efectos que sufra nuestro jugador
 * @author Ismael Paloma Narváez
 */
public class ControladorJugador : MonoBehaviour
{
    public static ControladorJugador instance;
    public float velocidadMovimiento;
    public Rigidbody2D rigid;
    public bool stopInput;
    public bool Dash;
    public float Dash_T;
    public float Speed_Dash;
   
    public float jumpForce;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;
    private bool isGrounded;
    private bool doubleJump;
    private int posDoble = 0;
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
        //saco de base de datos si tenemos desbloqueado el doble salto
        string url1 = "URI=file:" + Application.dataPath + "/database/2d.db";
        IDbConnection dbConn1 = new SqliteConnection(url1);
        dbConn1.Open();
        IDbCommand comando1 = dbConn1.CreateCommand();

        comando1.CommandText = "select * from saltoDoble";
        IDataReader reader1 = comando1.ExecuteReader();


        while (reader1.Read())
        {
            posDoble = (byte)reader1.GetInt32(reader1.GetOrdinal("activo"));
        }

        //cerramos todo lo utilizado
        reader1.Dispose();
        reader1 = null;
        comando1.Dispose();
        comando1 = null;

        dbConn1.Dispose();
        dbConn1 = null;


    }

    // Update is called once per frame
    void Update()
    {
        //este if bloqueará el movimiento del player en caso de que nos interese.
        if (!ResumeMenu.instance.isPaused && !stopInput)
        {
            //aqui aplicamos a todos los movimientos de nuestro player la posiblidad de recivir un desplazamiento hacia atrás si somos golpeados, se conoce como knockback.
            if (knockBackCounter <= 0)
            {
                //movimiento horizontal de nuestro jugador
                rigid.velocity = new Vector2(velocidadMovimiento * Input.GetAxis("Horizontal"), rigid.velocity.y);
                //boleano que nos sirve para saber si estamos tocando suelo o no para en un futuro poder saltar o no.
                isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGround);

                //efecto de ataque y su efecto de sonido
                if (Input.GetKey(KeyCode.E))
                {
                    anim.SetBool("Attack", true);
                   
                    Audio.instance.PlaySSFX(2);

                }
                else
                {
                    anim.SetBool("Attack", false);
                }


                //posiblidad de salto doble solo una vez
                if (isGrounded)
                {
                    if (posDoble == 1)
                    {
                        doubleJump = true;

                    }
                    
                }
                //establecemos el boton de salto, activamos su sonido y movemos verticalmente a nuestro jugador
                if (Input.GetButtonDown("Jump"))
                {
                    if (isGrounded)
                    {
                        Audio.instance.PlaySSFX(3);
                        rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
                    }
                    else
                    {
                        if (posDoble==1)
                        {
                            if (doubleJump)
                            {
                                Audio.instance.PlaySSFX(3);
                                rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
                                doubleJump = false;
                            }

                        }
                        

                    }




                }
                //asignamos tecla a la autosanación
                if (Input.GetKeyDown(KeyCode.W)) 
                {
                    //acudimos a una función de otro script
                    VidaJugador.instance.DarVida();
                }

               


                //establecemos un boton para deslizarnos y transformamos la velocidad de nuestro jugador en ese momento para realizar el efecto de deslizarse
                if (Input.GetKey(KeyCode.S))
                {
                    //relizaremos practicamente el mismo codigo dos veces pero cambiando el Vector3 para la orientación de nuetro personaje
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
                    else
                    {
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


                //si la velocidad es negativa nos estaremos desplazando hacia la izquierda
                if (rigid.velocity.x < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1); 
                    
                  




                    girado = true;
                }
                //si es positiva hacia la derecha
                else if (rigid.velocity.x > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    
                    


                    girado = false;

                }




            }
            else
            {

                knockBackCounter -= Time.deltaTime;
                //aplicamos el knockback en función de nuestra orientación
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



    }
    //funcion que nos sirve para activar el doble salto cuando queramos hacerlo, tambien guardará en base de datos que lo hemos desbloqueado si llamamos a la misma.
    public void ActivarDobleSalto()
    {
        posDoble = 1;

        string url = "URI=file:" + Application.dataPath + "/database/2d.db";
        IDbConnection dbConn = new SqliteConnection(url);
        dbConn.Open();
        IDbCommand comando = dbConn.CreateCommand();

        comando.CommandText = "delete from saltoDoble";
        comando.ExecuteNonQuery();

        comando.CommandText = "insert into saltoDoble values(" + posDoble + ")";
        comando.ExecuteNonQuery();

        comando.Dispose();
        comando = null;

        dbConn.Dispose();
        dbConn = null;

    }

    //funcion para efecto knockback
    public void Knockback()
    {
        knockBackCounter = knockBackLength;
        rigid.velocity = new Vector2(0f, knockBackForce);
    }

    
}
