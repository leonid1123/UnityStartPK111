using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoDAtk : StateMachineBehaviour
{
    Collider2D player;
    Transform pointA;
    Transform pointB;
    [SerializeField]
    LayerMask playerMask;
    float dst;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pointA = animator.GetComponent<Transform>().GetChild(1);
        pointB = animator.GetComponent<Transform>().GetChild(2);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = Physics2D.OverlapArea(new Vector2(pointA.position.x, pointA.position.y), new Vector2(pointB.position.x, pointB.position.y), playerMask);
        if (player != null)
        {
            dst = Vector2.Distance(player.transform.position, animator.transform.position);
        }
        if (dst >= 2 || player==null)
        {
            animator.SetBool("isAtk", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
