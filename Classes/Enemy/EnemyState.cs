using UnityEngine;
using UnityEngine.AI;

public class EnemyState : MonoBehaviour
{
    public float hitPoints;
    private Rigidbody[] rigibodies;
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        hitPoints = 100;
        rigibodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        DisableRagDoll(true);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if (hitPoints <= 0)
            DeadCheck();

        //Vector2 value = transform.InverseTransformDirection(navMeshAgent.velocity);
        //PlaySounds(value);
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
