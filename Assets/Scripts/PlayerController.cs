using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField]
    float spd = 10f;
    bool canJump = true;
    Animator anim;
    SpriteRenderer sprite;
    bool isRight = true;
    [SerializeField]
    int HP = 100;
    bool canMove = true;
    float move;
    [SerializeField]
    LayerMask enemyMask;
    [SerializeField]
    Transform atkPoint;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (canMove)
        {
            move = Input.GetAxisRaw("Horizontal");
        }
        //на самом деле это управляет движением!!!!
        Vector2 targetVelocity = new Vector2(move * spd, rb2d.velocity.y);
        //поправить движение - сделано
        rb2d.velocity = Vector3.Lerp(rb2d.velocity, targetVelocity, 0.05f);
        //поправить прыжок
        if (Input.GetButtonDown("Jump") & canJump)
        {
            rb2d.AddRelativeForce(Vector2.up * 8, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
            canJump = false;
        }
        if (rb2d.velocity.x > 0 & !isRight)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            isRight = true;
        }
        if (rb2d.velocity.x < 0 & isRight)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            isRight = false;
        }
        anim.SetFloat("mov", rb2d.velocity.sqrMagnitude);


        if (Input.GetButtonDown("Fire1"))
        {

            canMove = false;
            move = 0;
            anim.SetTrigger("atk1");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Chicken") || other.CompareTag("BoD"))
        {
            canJump = true;
            anim.SetBool("isJump", false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Chicken") || other.CompareTag("BoD"))
        {
            canJump = false;
        }
    }
    public void TakeDmg(int _dmg, float _enemyX)
    {
        int dir = 1;
        if (_enemyX > transform.position.x)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
        HP -= _dmg;
        rb2d.AddRelativeForce(new Vector2(0, 1f), ForceMode2D.Impulse);
        move = dir;
        canMove = false;
        StartCoroutine("CanDo");
    }
    IEnumerator CanDo()
    {
        yield return new WaitForSeconds(0.2f);
        canMove = true;
        move = 0;
        Debug.Log("can move now!");
    }
    public void CanMove()
    {
        canMove = true;
    }
    public void Kill()
    {
        Collider2D enemy = Physics2D.OverlapCircle(new Vector2(atkPoint.position.x, atkPoint.position.y), 0.3f, enemyMask);
        if (enemy != null)
        {
            if (enemy.CompareTag("Chicken"))
            {
                enemy.GetComponent<ChickenController>().Death();
            }
            if (enemy.CompareTag("BoD"))
            {
                enemy.GetComponent<BoDController>().TakeDmg(10);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + new Vector3(1.5f, -1.9f, 0), 0.3f);
    }
    //x + 1,5
    //y - 1,9
}
