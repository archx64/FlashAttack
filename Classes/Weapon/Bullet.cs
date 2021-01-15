using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] bool isShell = false;
    [SerializeField] float bullet = 0;
    [SerializeField] float shell = 0;

    private Rigidbody rb;

    private CharacterController player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        AddForce();
        Physics.IgnoreCollision(transform.GetChild(0).GetComponent<CapsuleCollider>(), player);
    }



    private void AddForce()
    {
        if (isShell)
        {
            rb.AddForce(transform.right * shell);
            Destroy(gameObject, 10);
        }
        else
        {
            rb.AddForce(transform.forward * bullet);
            Destroy(gameObject, 1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isShell)
        {
            return;
        }

        if (collision.relativeVelocity.magnitude > 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
