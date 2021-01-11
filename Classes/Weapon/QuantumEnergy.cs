using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class QuantumEnergy : MonoBehaviour
{
    private Transform playerTorso;
    private Rigidbody rb;

    private void Awake()
    {
        playerTorso = GameObject.FindWithTag("PlayerTorso").transform;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = playerTorso.transform.position - transform.position;
        rb.AddForce(direction * 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerTorso"))
        {
            Destroy(gameObject);
        }
    }
}
