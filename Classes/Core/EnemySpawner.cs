using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class EnemySpawner : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] GameObject vanguard;


    private Transform respawn;

    private void Awake()
    {
        respawn = GameObject.FindWithTag("Respawn").transform;
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (inventory != null && inventory.quantizedEnergy > 5)
        {
            Instantiate(vanguard, respawn);
            inventory.quantizedEnergy -= 5;
        }
    }
}
