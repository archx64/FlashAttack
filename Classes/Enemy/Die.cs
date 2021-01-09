using UnityEngine;

public class Die : MonoBehaviour
{
    public float hitPoints;
    private Rigidbody[] rigibodies;
    private Animator animator;

    void Start()
    {
        hitPoints = 100;
        rigibodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        DisableRagDoll(true);
        
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
