using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    float spd=10f;
    bool canJump = true;
    public Animator anim;
    public SpriteRenderer sprite;
    bool isRight=true;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>(); 
        anim = gameObject.GetComponent<Animator>(); 
        sprite = gameObject.GetComponent<SpriteRenderer>();     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.H)) {
            transform.Rotate(new Vector3(0,180,0));
        }

        //rb2d.velocity = new Vector2(1,1);
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*spd,rb2d.velocity.y);
        //Debug.Log("Скорость:" + Input.GetAxisRaw("Horizontal"));
        if(Input.GetButtonUp("Jump") & canJump) {
            rb2d.AddRelativeForce(Vector2.up*8,ForceMode2D.Impulse);
            canJump=false;
        }
        /*
        if(rb2d.velocity.x>0 & !isRight) {
            sprite.flipX=!sprite.flipX;
            isRight = true;
        }
        if(rb2d.velocity.x<0 & isRight) {
            sprite.flipX=!sprite.flipX;
            isRight = false;
        }
*/
        anim.SetFloat("mov",rb2d.velocity.sqrMagnitude);
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Ой!");
        canJump = true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Не ОЙ!!");
        canJump = false;
    }
}
