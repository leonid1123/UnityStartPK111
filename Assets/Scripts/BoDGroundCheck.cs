using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoDGroundCheck : MonoBehaviour
{
    [SerializeField]
    Transform GroundCheckLeft;
    [SerializeField]
    Transform GroundCheckRight;
    [SerializeField]
    LayerMask groundMask;
    bool onGroundLeft = true;
    bool onGroundRight = true;
    void Start()
    {
        
    }
    void Update()
    {
        Collider2D left = Physics2D.OverlapCircle(new Vector2(GroundCheckLeft.position.x,GroundCheckLeft.position.y), 0.1f,groundMask);
        Collider2D right = Physics2D.OverlapCircle(new Vector2(GroundCheckRight.position.x, GroundCheckRight.position.y), 0.1f,groundMask);
        if (left == null)
        {
            onGroundLeft = false;
        } else
        {
            onGroundLeft = true;
        }
        if (right == null)
        {
            onGroundRight = false;
        } else
        {
            onGroundRight = true;
        }
    }
    public bool OnGroundRight()
    {
        return onGroundRight;
    }
    public bool OnGroundLeft()
    {
        return onGroundLeft;
    }
}
