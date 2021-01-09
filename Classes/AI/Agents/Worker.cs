using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class Worker : MonoBehaviour, IGoap
{
    private NavMeshAgent navMeshAgent;
    private Vector3 previousDestination;
    private Inventory inv;
    public Inventory windmill;
    private readonly AnimationController animationController = new AnimationController();
    private Animator animator;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        inv = GetComponent<Inventory>();
        animator = GetComponentInChildren<Animator>();
    }

    public HashSet<KeyValuePair<string, object>> GetWorldState()
    {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("hasStock", (windmill.rawEnergy > 4)),
            new KeyValuePair<string, object>("hasRawEnergy", (inv.rawEnergy > 1)),
            new KeyValuePair<string, object>("hasDelivery", (inv.quantizedEnergy > 4))
        };
        return worldData;
    }


    public HashSet<KeyValuePair<string, object>> CreateGoalState()
    {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("doJob", true)
        };
        return goal;
    }


    public bool MoveAgent(GoapAction nextAction)
    {

        //if we don't need to move anywhere
        if (previousDestination == nextAction.target.transform.position)
        {
            nextAction.SetInRange(true);
            return true;
        }

        navMeshAgent.SetDestination(nextAction.target.transform.position);

        if (navMeshAgent.hasPath && navMeshAgent.remainingDistance < 2)
        {
            nextAction.SetInRange(true);
            previousDestination = nextAction.target.transform.position;
            return true;
        }
        else
            return false;
    }

    void Update()
    {
        if (navMeshAgent.hasPath)
        {
            Vector3 toTarget = navMeshAgent.steeringTarget - transform.position;
            float turnAngle = Vector3.Angle(transform.forward, toTarget);
            navMeshAgent.acceleration = turnAngle * navMeshAgent.speed;
        }

        Vector3 velocity = transform.InverseTransformDirection(navMeshAgent.velocity);
        float forward = velocity.z;
        float strafe = velocity.x;

        animationController.ControlAnimator(animator, forward, strafe);
    }

    public void PlanFailed(HashSet<KeyValuePair<string, object>> failedGoal)
    {

    }

    public void PlanFound(HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions)
    {

    }

    public void ActionsFinished()
    {

    }

    public void PlanAborted(GoapAction aborter)
    {

    }
}
