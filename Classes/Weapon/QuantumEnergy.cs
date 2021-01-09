using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class QuantumEnergy : MonoBehaviour
{
    private Transform playerTorso;
    private Rigidbody rb;
    private AudioSource audioSource;

    private void Awake()
    {
        playerTorso = GameObject.FindWithTag("Player").transform.Find("Torso");
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        audioSource.PlayOneShot(GameManager.Instance.AudioHolder.quantum);
    }

    private void FixedUpdate()
    {
        Vector3 direction = playerTorso.transform.position - transform.position;
        rb.AddForce(direction * 100);
    }
}
