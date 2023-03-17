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
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
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
    public void TakeDmg(int _dmg)
    {
        HP -= _dmg;
        //rb2d.AddRelativeForce(new Vector2(10, 10), ForceMode2D.Impulse);
    }
}
