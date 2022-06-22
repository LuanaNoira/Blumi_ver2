using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleStateNorSlime : StateMachineBehaviour
{
    float timer;

    private NavMeshAgent agent;

    Transform player;
    [SerializeField] private float chaseRange = 8;

    private SlimeTarget slime;
    //private Transform slimeChasedAzul;

    //teste
    private ClosestSlime slimesChased;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.autoBraking = true;

        slime = animator.GetComponent<SlimeTarget>();

        if(animator.CompareTag("SliPesadelo"))
        {
            //slimeChasedAzul = GameObject.FindGameObjectWithTag("SliAzul").transform;

            //teste
            slimesChased = animator.GetComponent<ClosestSlime>();
        }
        
        if (animator.CompareTag("Pirata") || animator.CompareTag("SliGalinha"))
        {
            animator.SetBool("isStunFace", false);
        }
        if(animator.CompareTag("SliFoca"))
        {
            animator.SetBool("isSleeping", true);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        float distance = Vector3.Distance(player.position, animator.transform.position);

        if (animator.CompareTag("Pirata"))
        {
            if (timer > Random.Range(4, 7))
            {
                animator.SetBool("isPatrolling", true);
            }

            
            if (distance < chaseRange)
            {
                animator.SetBool("isChasing", true);
            }

            if (slime.stun)
            {
                timer = 0;
                animator.SetBool("isStunned", true);
            }
        }
        else if(animator.CompareTag("SliAzul"))
        {
            if (timer > Random.Range(4, 7))
            {
                animator.SetBool("isPatrolling", true);
            }

            if (slime.charmed)
            {
                animator.SetBool("isPatrolling", false);
                animator.SetBool("isCharmed", true);
            }
        }
        else if(animator.CompareTag("SliGalinha"))
        {
            if (timer > Random.Range(4,7))
            {
                animator.SetBool("isPatrolling", true);
            }

            if (distance < chaseRange)
            {
                animator.SetBool("isRunning", true);
            }

            if (slime.stun)
            {
                animator.SetBool("isStunned", true);
            }
        }
        else if(animator.CompareTag("SliFoca"))
        {
            if(slime.sound)
            {
                animator.SetBool("isSleeping", false);
                animator.SetBool("isScared", true);
            }
        }
        else if(animator.CompareTag("SliPesadelo"))
        {
            //float distance2 = Vector3.Distance(slimeChasedAzul.position, animator.transform.position);
            //teste
            GameObject closest = slimesChased.FindClosestEnemy();
            float distance2 = Vector3.Distance(closest.transform.position, animator.transform.position);

            if (timer > Random.Range(5, 8))
            {
                animator.SetBool("isPatrolling", true);
            }


            if ((distance < chaseRange) && (distance < distance2))
            {
                animator.SetBool("isChasing", true);
            }
            else if ((distance2 < chaseRange) && (distance2 < distance))
            {
                animator.SetBool("isChasing", true);
            }
            /*
            else if(((distance < chaseRange) || (distance2 < chaseRange)) && distance == distance2)
            {
                animator.SetBool("isChasing", true);
            } */

            if (slime.purify == true)
            {
                timer = 0;
                animator.SetBool("isPurified", true);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        if(!animator.CompareTag("SliAzul"))
        {
            slime.charmed = false;
        }
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
