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
    Rigidbody2D rb2d;
    bool gotPlayer = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    void KillPlayer()
    {
        if (gotPlayer)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().TakeDmg(10,transform.position.x);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gotPlayer);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gotPlayer= true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gotPlayer= false;
        }
    }
    public void TakeDmg(int _dmg)
    {
        HP -= _dmg;
        anim.SetTrigger("isHit");
        if (HP <= 0)
        {
            anim.SetBool("isDead", true);
        }
    }
    public void Death()
    {
        Instantiate(coin, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
