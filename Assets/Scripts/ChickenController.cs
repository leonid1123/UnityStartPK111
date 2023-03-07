using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector3 startPos;
    [SerializeField]
    float maxDistance=2f;
    int dir=1;
    void Start()
    {
        startPos = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector2.Distance(startPos,transform.position);
        if(currentDistance>=maxDistance){
            dir*=-1;
        }
        rb2d.velocity = Vector2.right*dir;
    }
}
