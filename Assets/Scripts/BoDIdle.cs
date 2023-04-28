using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoDIdle : StateMachineBehaviour
{
    Collider2D player;
    Transform pointA;
    Transform pointB;
    [SerializeField]
    LayerMask playerMask;
    BoDGroundCheck bodGroundCheck;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bodGroundCheck = animator.GetComponent<BoDGroundCheck>();
        pointA = animator.GetComponent<Transform>().GetChild(1);
        pointB = animator.GetComponent<Transform>().GetChild(2);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = Physics2D.OverlapArea(new Vector2(pointA.position.x, pointA.position.y), new Vector2(pointB.position.x, pointB.position.y), playerMask);
        if (player != null && player.CompareTag("Player") && bodGroundCheck.OnGroundLeft() && bodGroundCheck.OnGroundRight())
        {
            animator.SetBool("isWalk", true);
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
