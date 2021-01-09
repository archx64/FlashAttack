using UnityEngine;
using UnityEngine.AI;

public class EnemyState : MonoBehaviour
{
    private float hitPoints;
    private Rigidbody[] rigibodies;
    private Animator animator;
    private NavMeshAgent navMeshAgent;


    private void Awake()
    {
        rigibodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    private void Start()
    {
        DisableRagDoll(true);
        hitPoints = 100;
    }


    private void Update()
    {
        if (hitPoints <= 0)
            DeadCheck();

    }

    private void DeadCheck()
    {
        animator.enabled = false;
        DisableRagDoll(false);
        navMeshAgent.speed = 0;
        navMeshAgent.angularSpeed = 0;
    }


    private void DisableRagDoll(bool value)
    {
        foreach (Rigidbody rb in rigibodies)
        {
            rb.isKinematic = value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hitPoints -= 150;
        }
    }
}
