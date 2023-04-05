using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaseController : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    GameObject coin;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled= false;
        
    }
    public void CreateCoin()
    {
        float rnd = Random.Range(0,1.0f);
        if (rnd>0.5f)
        {
            GameObject newCoin = Instantiate(coin, transform.position, transform.rotation);
            newCoin.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 5,ForceMode2D.Impulse);
        }
    }
    public void DestroyVase()
    {
        CreateCoin();
        anim.enabled = true;
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}
