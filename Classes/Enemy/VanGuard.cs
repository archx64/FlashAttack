using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class VanGuard : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform player;
    private Animator animator;

    private readonly AnimationController animationController = new AnimationController();

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        navMeshAgent.destination = player.position;

        Vector3 velocity = transform.InverseTransformDirection(navMeshAgent.velocity);
        float forward = velocity.z;
        float strafe = velocity.x;

        animationController.ControlAnimator(animator, forward, strafe);
    }


}
