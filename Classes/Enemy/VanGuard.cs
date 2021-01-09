using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class VanGuard : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform player;
    private Animator animator;

    private readonly AnimationController animationController = new AnimationController();

    private Transform quantumSpawn;
    private Transform torso;

    private GameObject bullet;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();
        //quantumSpawn = GameObject.FindWithTag("EnergySpawn").transform;
        //torso = GameObject.FindWithTag("Player").transform.Find("Torso");
        //bullet = Resources.Load<GameObject>("Bullet/QuantumEnergy");
    }

    private void Update()
    {
        navMeshAgent.destination = player.position;

        Vector3 velocity = transform.InverseTransformDirection(navMeshAgent.velocity);
        float forward = velocity.z;
        float strafe = velocity.x;

        animationController.ControlAnimator(animator, forward, strafe);

        //GunFire();
    }


    private void GunFire()
    {
        float distance = Vector3.Distance(transform.position, torso.position);

        if (distance < 9)
        {
            Instantiate(bullet, quantumSpawn.position, quantumSpawn.rotation);
        }
    }
}
