using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StunStateSlime : StateMachineBehaviour
{
    private NavMeshAgent agent;

    float timer;

    private SlimeTarget slime;

    [SerializeField] private float stunnedTime = 7;

    [SerializeField] ParticleSystem [] stunParticle;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;

        agent.autoBraking = true;

        agent.SetDestination(agent.transform.position);
        slime = animator.GetComponent<SlimeTarget>();

        //stunParticle = GameObject.FindGameObjectWithTag("StunParticle").GetComponent<ParticleSystem>();

        stunParticle = animator.GetComponentsInChildren<ParticleSystem>();

        stunParticle[0].Play();

        animator.SetBool("isStunFace", true);
        slime.charmed = false;
        if(animator.CompareTag("Pirata"))
        {
            animator.SetBool("isAttacking", false);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if (timer > stunnedTime && slime.charmed == false)
        {
            animator.SetBool("isStunned", false);
            animator.SetBool("isPatrolling", true);
            animator.SetBool("isStunFace", false);
            slime.stun = false;
        }
        /*
        else if (timer > stunnedTime && slimePirata.charmed == true)
        {
            animator.SetBool("isStunned", false);
            animator.SetBool("isCharmed", true);
            slimePirata.stun = false;
        }*/
        else if (timer < stunnedTime && slime.charmed == true)
        {
            animator.SetBool("isStunned", false);
            animator.SetBool("isCharmed", true);
            animator.SetBool("isStunFace", false);
            slime.stun = false;
        }
        else if(timer < stunnedTime && slime.charmed == false)
        {
            agent.SetDestination(animator.transform.position);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stunParticle[0].Stop();
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
