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


    void Start()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDmg(int _dmg)
    {
        HP-=_dmg;
        anim.SetTrigger("isHit");
        if (HP<=0)
        {
            anim.SetBool("isDead", true);
        }
    }
    public void Death()
    {
        Instantiate(coin,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
