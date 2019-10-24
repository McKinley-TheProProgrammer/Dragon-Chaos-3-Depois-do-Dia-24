using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashMechanic : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField]
    private float dash_velocidade = 50f;
    private float dash_tempo;
    private float startDash = 0.1f;
    private int direcao;
    
    [SerializeField]
    private float manaRegen = 0.001f;

    public Image barraDeMana;

    Animator anim;
    public GameObject efeitoDash;
    //public ParticleSystem system;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dash_tempo = startDash;
        barraDeMana.fillAmount = 1f;

    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground_Grass")){
            gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
        }
    }*/
    void FixedUpdate()
    {
        //Debug.Log(direcao);
        if (barraDeMana.fillAmount <= 1)
        {
            barraDeMana.fillAmount += manaRegen;
        }

        if (direcao == 0)
        {

            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && barraDeMana.fillAmount >= 0.25f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetTrigger("Dashing");
                    //Instantiate(efeitoDash, transform.position, Quaternion.identity);
                    gameObject.GetComponent<PlayerDamage>().imortal = true;
                    gameObject.layer = 11;
                    // gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
                    direcao = 1;
                    
                    barraDeMana.fillAmount -= 0.25f;
                    
                }
            }
            else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && barraDeMana.fillAmount >= 0.25f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetTrigger("Dashing");
                    //Instantiate(efeitoDash, transform.position, Quaternion.identity);
                    gameObject.GetComponent<PlayerDamage>().imortal = true;
                    gameObject.layer = 11;
                    // gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
                    direcao = 2;
                    
                    barraDeMana.fillAmount -= 0.25f;

                }
            }
            else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && barraDeMana.fillAmount >= 0.25f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Instantiate(efeitoDash, transform.position, Quaternion.identity);
                    gameObject.GetComponent<PlayerDamage>().imortal = true;
                    gameObject.layer = 11;
                   // gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
                    direcao = 3;
                    
                    barraDeMana.fillAmount -= 0.25f;

                }
            }
            /*else if (Input.GetKey(KeyCode.S) && barraDeMana.fillAmount >= 0.25f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(efeitoDash, transform.position, Quaternion.identity);
                    
                    direcao = 4;
                    
                    barraDeMana.fillAmount -= 0.25f;

                }
            }*/

        }
        else
        {
            if (dash_tempo <= 0)
            {
                direcao = 0;
                dash_tempo = startDash;
                rb.velocity = Vector2.zero;
                gameObject.GetComponent<PlayerDamage>().imortal = false;
                //gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
                gameObject.layer = 10;
            }
            else
            {
                dash_tempo -= Time.deltaTime;

                if (direcao == 1)
                {
                    rb.velocity = Vector2.left * dash_velocidade;
                }
                else if (direcao == 2)
                {
                    rb.velocity = Vector2.right * dash_velocidade;
                }
                else if (direcao == 3)
                {
                    rb.velocity = Vector2.up * dash_velocidade;
                }
                /*else if (direcao == 4)
                {
                    rb.velocity = Vector2.down * dash_velocidade;
                }*/
            }
        }
    }
}
