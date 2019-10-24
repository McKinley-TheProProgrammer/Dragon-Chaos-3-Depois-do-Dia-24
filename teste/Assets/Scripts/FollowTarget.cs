using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public float velocidade;
    public float pararDist;
    public float recuarDist;
    //public GameObject range;
    public Transform seguirAlvo;
    //Checa se tem um buraco
    public Transform edge;
    public float raioDoCanto;
    public LayerMask whereIsEdge;
    public bool isOnGround;
    bool isAttacking;
    public EnemyAttack atackscript;
    public int enemyRange = 16;
    public Transform player;

   // Animator anim;
    SpriteRenderer flipa;
    // Start is called before the first frame update
    void Start()
    {
        seguirAlvo = PlayerMovement.Instance.transform;
        //anim = GetComponent<Animator>();
        flipa = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(edge.position, raioDoCanto, whereIsEdge);
        if (seguirAlvo != null)
        {
            //Debug.Log(seguirAlvo);
            if (transform.position.x > seguirAlvo.position.x)
            {
               // Debug.Log(transform.position.x + " VS " + player.position.x);
                flipa.flipX = true;
            }
            else
            {
               // Debug.Log(flipa.flipX);
                flipa.flipX = false;
            }
            /*if (isAttacking)
            {
                return;
            }*/
            //Debug.Log("The Fim");
            if(CheckRange() && isOnGround)
            {
                //anim.SetBool("EnemySpotted",true);
                //Debug.Log(CheckRange());
                GetComponent<Animator>().SetBool("EnemySpotted", true);
                transform.position = Vector2.MoveTowards(transform.position, seguirAlvo.position, velocidade * Time.deltaTime);
            }
            //else if (Vector2.Distance(transform.position, seguirAlvo.position) < pararDist && Vector2.Distance(transform.position, seguirAlvo.position) > recuarDist && isOnGround)
            //{
            //    transform.position = this.transform.position;
            //}
            else if (Vector2.Distance(transform.position, seguirAlvo.position) < recuarDist && isOnGround)
            {
                transform.position = Vector2.MoveTowards(transform.position, seguirAlvo.position, -velocidade*Time.deltaTime);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyRange);
    }

    bool CheckRange()
    {
        return Vector2.Distance(transform.position, seguirAlvo.position) < enemyRange; //Apenas em um inimigo
    }
    public void StartAttack()
    {
        atackscript.TurnColliderOn();
        isAttacking = true;
    }
    public void StopAttack()
    {
        atackscript.TurnColliderOff();
        isAttacking = false;
    }
}
