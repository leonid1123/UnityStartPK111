using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoDController : MonoBehaviour
{
    [SerializeField]
    int HP = 100;
    Animator anim;
    [SerializeField]
    GameObject coin;
    Transform player;
    Rigidbody2D rb2d;
    bool isRight = false;
    enum State { idle, move, atk, death, dmg }
    State BoDState = State.idle;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (BoDState)
        {
            case State.idle:
                rb2d.velocity = Vector2.zero;
                anim.SetBool("isWalk", false);
                break;
            case State.move:
                //double dst = Vector2.Distance(transform.position, player.position);
                if (DistanceToPlayer() < 2)
                {
                    BoDState = State.atk;
                }
                
                anim.SetBool("isWalk", true);
                if (transform.position.x > player.position.x)
                {
                    if (isRight)
                    {
                        transform.Rotate(0, 180, 0);
                        isRight = false;
                    }
                    rb2d.velocity = new Vector2(-1, rb2d.velocity.y);//Vector2.left;
                }
                else
                {
                    if (!isRight)
                    {
                        transform.Rotate(0, 180, 0);
                        isRight = true;
                    }
                    rb2d.velocity = new Vector2(1, rb2d.velocity.y); //Vector2.right;
                }
                break;
            case State.dmg:
                rb2d.velocity = Vector2.zero;
                break;
            case State.atk:
                rb2d.velocity = Vector2.zero;
                anim.SetBool("isAtk", true);
                if(DistanceToPlayer() > 2)
                {
                    BoDState= State.move;
                    anim.SetBool("isAtk", false);
                }
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            BoDState = State.move;
            player = collision.transform;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            BoDState = State.idle;
        }
    }
    public void TakeDmg(int _dmg)
    {
        BoDState = State.dmg;
        HP -= _dmg;
        anim.SetTrigger("isHit");
        if (HP <= 0)
        {
            anim.SetBool("isDead", true);
        }
    }
    public void Death()
    {
        BoDState = State.death;
        Instantiate(coin, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public void ToMoveState()
    {
        BoDState = State.move;
    }
    double DistanceToPlayer()
    {
        return Vector2.Distance(transform.position, player.position);
    }
}
