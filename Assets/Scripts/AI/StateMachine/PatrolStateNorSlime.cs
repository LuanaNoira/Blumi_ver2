using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolStateNorSlime : StateMachineBehaviour
{
    private NavMeshAgent agent;

    public float radius;
    float timer;

    Transform player;
    [SerializeField] private float chaseRange = 8;

    private SlimeTarget slime;
    private Transform slimeChasedAzul;

    [SerializeField] private GetPoint wPoint;
    [SerializeField] private GetWaypoint wPointCheck;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.autoBraking = false;

        wPointCheck = animator.GetComponent<GetWaypoint>();

        //Speed no caso de precisar mexer
        //agent.speed = 1.5f;

        if (animator.CompareTag("SliPesadelo"))
        {
            slimeChasedAzul = GameObject.FindGameObjectWithTag("SliAzul").transform;
        }

        slime = animator.GetComponent<SlimeTarget>();

        if(wPointCheck.wPoint1)
            wPoint = GameObject.FindGameObjectWithTag("Waypoint1").GetComponent<GetPoint>();
        if(wPointCheck.wPoint2)
            wPoint = GameObject.FindGameObjectWithTag("Waypoint2").GetComponent<GetPoint>();
        if (wPointCheck.wPoint3)
            wPoint = GameObject.FindGameObjectWithTag("Waypoint3").GetComponent<GetPoint>();
        if (wPointCheck.wPoint4)
            wPoint = GameObject.FindGameObjectWithTag("Waypoint4").GetComponent<GetPoint>();
        if (wPointCheck.wPoint5)
            wPoint = GameObject.FindGameObjectWithTag("Waypoint5").GetComponent<GetPoint>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        float distance = Vector3.Distance(player.position, animator.transform.position);

        if (!agent.hasPath)
        {
            agent.SetDestination(wPoint.GetRandomPoint());
        }

        if (animator.CompareTag("Pirata"))
        {
            if (timer > Random.Range(7, 10))
            {
                animator.SetBool("isPatrolling", false);
            }
            
            if (distance < chaseRange)
            {
                animator.SetBool("isChasing", true);
            }

            if (slime.stun == true)
            {
                timer = 0;
                animator.SetBool("isPatrolling", false);
                animator.SetBool("isStunned", true);
            }
        }
        else if (animator.CompareTag("SliAzul"))
        {
            if (timer > Random.Range(7, 10))
            {
                animator.SetBool("isPatrolling", false);
            }

            if (slime.charmed)
            {
                animator.SetBool("isPatrolling", false);
                animator.SetBool("isCharmed", true);
            }
        }
        else if (animator.CompareTag("SliPesadelo"))
        {
            float distance2 = Vector3.Distance(slimeChasedAzul.position, animator.transform.position);

            if (timer > Random.Range(12, 18))
            {
                animator.SetBool("isPatrolling", false);
            }

            if ((distance < chaseRange) && (distance < distance2))
            {
                animator.SetBool("isChasing", true);
            }
            else if ((distance2 < chaseRange) && (distance2 < distance))
            {
                animator.SetBool("isChasing", true);
            }
            else if (((distance < chaseRange) || (distance2 < chaseRange)) && distance == distance2)
            {
                animator.SetBool("isChasing", true);
            }

            if (slime.purify == true)
            {
                timer = 0;
                animator.SetBool("isPatrolling", false);
                animator.SetBool("isPurified", true);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        animator.SetBool("isPatrolling", false);
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

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(agent.transform.position, agent.radius);
    }

#endif
}
