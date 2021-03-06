using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunStateSlime : StateMachineBehaviour
{
    private NavMeshAgent agent;

    Transform player;

    private SlimeTarget slime;

    [SerializeField] float distanceRun = 5.0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = 3.5f;

        slime = animator.GetComponent<SlimeTarget>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, player.position);
        Vector3 dirToPlayer = animator.transform.position - player.position;

        Vector3 newPos = animator.transform.position + (2*dirToPlayer);


        if (distance < distanceRun)
        {
            agent.SetDestination(newPos);
        }
        else if (distance > distanceRun + 2)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isPatrolling", true);
        }

        if(slime.stun)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isStunned", true);
            animator.SetBool("isStunFace", true);
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
