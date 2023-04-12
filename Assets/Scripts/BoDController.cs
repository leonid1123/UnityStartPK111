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

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
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
