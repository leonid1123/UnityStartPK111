using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector3 startPos;
    [SerializeField]
    float maxDistance = 2f;
    int dir = 1;
    float rad = 0.65f;
    [SerializeField]
    LayerMask mask;
    Animator anim;
    bool alive = true;
    void Start()
    {
        startPos = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (alive)
        {
            float currentDistance = Vector2.Distance(startPos, transform.position);
            if (currentDistance >= maxDistance)
            {
                dir *= -1;
                ChickenFlip();
            }
            rb2d.velocity = Vector2.right * dir * 2;

            Collider2D player = Physics2D.OverlapCircle(transform.position, rad, mask);
            Debug.Log(player);
            if (player != null && player.name.Equals("Player"))
            {
                player.GetComponent<PlayerController>().TakeDmg(1, transform.position.x);
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + new Vector3(maxDistance, 0, 0), 0.1f);
        Gizmos.DrawWireSphere(transform.position - new Vector3(maxDistance, 0, 0), 0.1f);

        Gizmos.DrawWireSphere(transform.position, rad);
    }
    void ChickenFlip()
    {
        transform.Rotate(0, 180, 0);
    }
    public void Death()
    {
        alive= false;
        rb2d.velocity = Vector2.zero;
        anim.SetBool("isDead", true);
        Destroy(gameObject, 0.5f);
    }
}
