using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackStateSlime : StateMachineBehaviour
{
    private NavMeshAgent agent;

    Transform player;

    private SlimeTarget slime;
    private Transform slimeChasedAzul;
    //private bool attackingPlayer = false;
    //private bool attackingSlime = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        slime = animator.GetComponent<SlimeTarget>();

        agent.autoBraking = true;

        if (animator.CompareTag("SliPesadelo"))
        {
            slimeChasedAzul = GameObject.FindGameObjectWithTag("SliAzul").transform;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (slime.CompareTag("Pirata"))
        {
            animator.transform.LookAt(player);

            if (distance > 3.5f)
            {
                animator.SetBool("isAttacking", false);
            }
        }
        else if (slime.CompareTag("SliPesadelo"))
        {
            float distance2 = Vector3.Distance(slimeChasedAzul.position, animator.transform.position);

            if(distance < distance2)
            {
                animator.transform.LookAt(player);
                //attackingPlayer = true;
                if(distance > 3.5f)
                {
                    animator.SetBool("isAttacking", false);
                }
            }
            else if(distance2 < distance)
            {
                animator.transform.LookAt(slimeChasedAzul);
                //attackingSlime = true;
                if (distance2 > 3.5f)
                {
                    animator.SetBool("isAttacking", false);
                }
            }
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
