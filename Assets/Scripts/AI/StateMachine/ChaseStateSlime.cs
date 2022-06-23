using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseStateSlime : StateMachineBehaviour
{
    private NavMeshAgent agent;
    
    Transform player;
    //[SerializeField] private float chaseRange = 8;

    private SlimeTarget slime;
    //private Transform slimeChasedAzul;
    private bool chasingPlayer = false;
    private bool chasingSlime = false;

    //teste
    private ClosestSlime slimesChased;
    float aniTimer;
    [SerializeField] ParticleSystem[] angryParticle;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Speed no caso de precisar mexer
        //agent.speed = 3.5f;

        agent.autoBraking = false;

        slime = animator.GetComponent<SlimeTarget>();
        
        if(animator.CompareTag("Pirata"))
        {
            angryParticle = animator.GetComponentsInChildren<ParticleSystem>();
            angryParticle[1].Play();
        }

        if (animator.CompareTag("SliPesadelo"))
        {
            //slimeChasedAzul = GameObject.FindGameObjectWithTag("SliAzul").transform;

            //teste
            slimesChased = animator.GetComponent<ClosestSlime>();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (animator.CompareTag("Pirata"))
        {
            agent.SetDestination(player.position);
            
            if (distance > 15)
            {
                animator.SetBool("isChasing", false);
            }
            if (distance < 2.5f)
            {
                animator.SetBool("isAttacking", true);
            }

            if (slime.stun == true)
            {
                animator.SetBool("isChasing", false);
                animator.SetBool("isStunned", true);
            }
        }
        else if(animator.CompareTag("SliPesadelo"))
        {
            //float distance2 = Vector3.Distance(slimeChasedAzul.position, animator.transform.position);
            //teste
            GameObject closest = slimesChased.FindClosestEnemy();
            float distance2 = Vector3.Distance(closest.transform.position, animator.transform.position);

            aniTimer += Time.deltaTime;
            if (aniTimer <= 0.7f)
                agent.speed = 0;
            else if (aniTimer <= 2.04f && aniTimer > 0.79f)
                agent.speed = 3.5f;
            else if (aniTimer > 2.04f && aniTimer <= 2.54f)
                agent.speed = 0;
            else if (aniTimer > 2.54f)
                aniTimer = 0;

            if (distance < distance2)
            {
                agent.SetDestination(player.position);
                chasingPlayer = true;
            }
            else if (distance2 < distance)
            {
                //agent.SetDestination(slimeChasedAzul.position);
                //teste
                agent.SetDestination(closest.transform.position);

                chasingSlime = true;
            }

            if ((distance > 15) && chasingPlayer && chasingSlime == false)
            {
                animator.SetBool("isChasing", false);
                aniTimer = 0;
            }
            else if ((distance2 > 15) && chasingPlayer == false && chasingSlime)
            {
                animator.SetBool("isChasing", false);
                aniTimer = 0;
            }
            if ((distance < 2.5f) && chasingPlayer && chasingSlime == false)
            {
                animator.SetBool("isAttacking", true);
            }
            else if ((distance2 < 2.5f) && chasingPlayer == false && chasingSlime)
            {
                animator.SetBool("isAttacking", true);
            }

            if (slime.purify == true)
            {
                animator.SetBool("isChasing", false);
                animator.SetBool("isPurified", true);
            }
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(slime.CompareTag("SliPesadelo"))
        {
            chasingPlayer = false;
            chasingSlime = false;
            aniTimer = 0;
        }
        if(slime.CompareTag("Pirata"))
        {
            angryParticle[1].Stop();
        }

        agent.SetDestination(animator.transform.position);
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
