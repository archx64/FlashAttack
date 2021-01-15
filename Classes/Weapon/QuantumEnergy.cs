using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class QuantumEnergy : MonoBehaviour
{
    private Transform playerTorso;
    private Rigidbody rb;

    private SceneLoader sceneLoader;

    public static float damageDealt;

    private void Awake()
    {
        playerTorso = GameObject.FindWithTag("PlayerTorso").transform;
        sceneLoader = GameManager.Instance.SceneLoader;
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
            damageDealt += 10;

            if(damageDealt > 100)
            {
                damageDealt = 0;
                sceneLoader.SceneToLoad(2);
            }

            Destroy(gameObject);
        }
    }
}
