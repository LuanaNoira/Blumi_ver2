using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StunStateSlime : StateMachineBehaviour
{
    private NavMeshAgent agent;

    float timer;

    private SlimeTarget slimePirata;

    [SerializeField] private float stunnedTime = 7;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;
        agent.SetDestination(agent.transform.position);
        slimePirata = animator.GetComponent<SlimeTarget>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if (timer > stunnedTime && slimePirata.charmed == false)
        {
            animator.SetBool("isStunned", false);
            animator.SetBool("isPatrolling", true);
            slimePirata.stun = false;
        }
        else if (timer > stunnedTime && slimePirata.charmed == true)
        {
            animator.SetBool("isStunned", false);
            animator.SetBool("isCharmed", true);
            slimePirata.stun = false;
        }
        else if (timer < stunnedTime && slimePirata.charmed == true)
        {
            animator.SetBool("isStunned", false);
            animator.SetBool("isCharmed", true);
            slimePirata.stun = false;
        }
        else if(timer < stunnedTime)
        {
            agent.SetDestination(animator.transform.position);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

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
