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
    void Start()
    {
        startPos = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentDistance = Vector2.Distance(startPos, transform.position);
        if (currentDistance >= maxDistance)
        {
            dir *= -1;
            ChickenFlip();
        }
        rb2d.velocity = Vector2.right * dir * 2;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + new Vector3(maxDistance, 0, 0), 0.1f);
        Gizmos.DrawWireSphere(transform.position - new Vector3(maxDistance, 0, 0), 0.1f);
    }
    void ChickenFlip()
    {
        transform.Rotate(0, 180, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().TakeDmg(1);
            if (transform.position.x > other.transform.position.x)
            {
                other.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left*5, ForceMode2D.Impulse);
            } else {
                other.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right*5, ForceMode2D.Impulse);
            }
        }
    }
}
