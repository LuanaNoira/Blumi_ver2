using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolStateSlime : StateMachineBehaviour
{
    private NavMeshAgent agent;

    public float radius;
    float timer;

    private SlimeTarget slime;

    [SerializeField] private GetPoint wPoint;
    [SerializeField] private GetWaypoint wPointCheck;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;

        slime = animator.GetComponent<SlimeTarget>();

        agent.autoBraking = false;

        wPointCheck = animator.GetComponent<GetWaypoint>();

        if (wPointCheck.wPoint1)
            wPoint = GameObject.FindGameObjectWithTag("Waypoint1").GetComponent<GetPoint>();
        if (wPointCheck.wPoint2)
            wPoint = GameObject.FindGameObjectWithTag("Waypoint2").GetComponent<GetPoint>();

        //Speed no caso de precisar mexer
        //agent.speed = 1.5f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if (!agent.hasPath)
        {
            agent.SetDestination(wPoint.GetRandomPoint());
        }

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
