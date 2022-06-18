using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharmedStateSlime : StateMachineBehaviour
{
    private NavMeshAgent agent;

    float timer;

    private SlimeTarget slimePirata;

    Transform player;

    public Transform target;

    [SerializeField] private float charmedTime = 300;

    SlimeLog sLog;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = GameObject.FindGameObjectWithTag("slimePos1").transform;
        slimePirata = animator.GetComponent<SlimeTarget>();

        sLog = GameObject.FindGameObjectWithTag("SlimeLog").GetComponent<SlimeLog>();
        
        if (sLog.sPirata == false)
        {
            sLog.sPirata = true;
        }

        //slimePirata.charmed = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if (timer < charmedTime)
        {
            agent.SetDestination(target.position);
        }
        else if (timer > charmedTime)
        {
            animator.SetBool("isCharmed", false);
            slimePirata.charmed = false;
        }
        
        //mudar a animação de idle para walk se o jogador tiver-se a mover
        if (agent.transform.position == target.position)
        {
            animator.SetFloat("charmMotion", 0);
            agent.autoBraking = true;
        }
        else
        {
            animator.SetFloat("charmMotion", 1);
            agent.autoBraking = false;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isCharmed", false);
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
