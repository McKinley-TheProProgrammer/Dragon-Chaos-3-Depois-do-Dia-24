using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public AudioClip[] birds = new AudioClip[3];
    public AudioClip walking,jumping,landing;
    float velocity = 4.5f;
    float jumpForce = 400f;
    Rigidbody2D body;
    Animator anim;
    SpriteRenderer flipa;
    
    bool isAttacking;
    bool moving = true;
    public bool inDialog = false;
    bool activatePhysics;
    public int activatePhys = 0;
    public bool isInRange;


    public Transform peDoPlayer;
    private float raio = 0.3f;
    public LayerMask groundChecker;
    public bool isOnLand = true;
    public AttackMechanic attackScript;

    #region Singleton
    static PlayerMovement instance;
    public static PlayerMovement Instance { get { return instance; } }
    #endregion

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        isOnLand = true;
        anim = GetComponent<Animator>();
        flipa = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground_Grass")
        {
            GameManager.Instance.SfxPlayer(landing);
            isOnLand = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground_Grass")
            isOnLand = false;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            body.isKinematic = true;
        }
        if(activatePhys >= 9)
        {
            body.isKinematic = false;
        }
    }*/
    public void WalkingSfx()
    {
        GameManager.Instance.SfxPlayer(walking);
    }
    public void JumpingSfx()
    {
        GameManager.Instance.SfxPlayer(jumping);
    }
    /*public void LandingSfx()
    {
        GameManager.Instance.SfxPlayer(landing);
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("AudioTrigger"))
            GameManager.Instance.SfxPlayer(birds[0]);
        if (collision.gameObject.CompareTag("AudioTrigger2"))
            GameManager.Instance.SfxPlayer(birds[1]);
        if (collision.gameObject.CompareTag("AudioTrigger3"))
            GameManager.Instance.SfxPlayer(birds[2]);
    }


    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));

        if (inDialog || isAttacking)
        {
            anim.SetBool("IsWalking", false);
            body.velocity = Vector2.zero;
            return;
        }


        float x = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(x * velocity, body.velocity.y);
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isOnLand == true)
        {
            anim.SetTrigger("Jumper");
            body.AddForce(new Vector2(0, jumpForce));
        }
        if (x > 0 && !moving)
        {
            moving = true;
            flipa.flipX = false;
        }
        else
        {
            if (x < 0 && !moving)
            {
                moving = true;
                flipa.flipX = true;
            }
            else
            {
                moving = false;
            }
        }




        if (x == 0)
        {
            anim.SetBool("IsWalking", false);
        }
        else
        {
            anim.SetBool("IsWalking", true);
        }

        isOnLand = Physics2D.OverlapCircle(peDoPlayer.position, raio, groundChecker);
    }

    public void StartAttack()
    {
        attackScript.TurnColliderOn();
        isAttacking = true;
    }
    public void StopAttack()
    {
        attackScript.TurnColliderOff();
        isAttacking = false;
    }

}
