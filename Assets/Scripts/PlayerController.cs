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
    private Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;
    bool canMove = true;
    float move;
    [SerializeField]
    LayerMask enemyMask;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(canMove)
        {
            move = Input.GetAxisRaw("Horizontal");
        }

        Vector2 targetVelocity = new Vector2(move * spd,rb2d.velocity.y);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        if (Input.GetButtonUp("Jump") & canJump)
        {
            rb2d.AddRelativeForce(Vector2.up * 8, ForceMode2D.Impulse);
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
        if (Input.GetButtonUp("Jump"))
        {
            anim.SetBool("jumpStart", true);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            canMove = false;
            anim.SetTrigger("atk1");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Ой!");
        canJump = true;
        anim.SetBool("jumpStart", false);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Не ОЙ!!");
        canJump = false;
    }
    public void TakeDmg(int _dmg, float _enemyX)
    {
        int dir = 1;
        if(_enemyX > transform.position.x)
        {
            dir = -1;
        } else
        {
            dir = 1;
        }
        HP -= _dmg;
        rb2d.AddRelativeForce(new Vector2(10*dir, 2.5f), ForceMode2D.Impulse);
        canMove = false;
        StartCoroutine("CanDo");
    }
    IEnumerator CanDo()
    {
        yield return new WaitForSeconds(2f);
        canMove= true;
        Debug.Log("can move now!");
    }
    public void CanMove()
    {
        canMove = true;
    }
    public void Kill() 
    {
        Collider2D enemy = Physics2D.OverlapCircle(transform.position + new Vector3(1.5f, -1.9f, 0),1f,enemyMask);
        if(enemy != null && enemy.CompareTag("enemy")) 
        {
            Debug.Log(enemy);
            enemy.GetComponent<ChickenController>().Death();
        }
    }
    //x + 1,5
    //y - 1,9
}
