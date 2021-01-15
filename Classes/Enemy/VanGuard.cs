using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class VanGuard : MonoBehaviour
{
    private float timeBetweenShots = 3f;
    private float startTimeBetweenShots;
    private NavMeshAgent navMeshAgent;
    private Transform player;
    private Animator animator;

    private float hitPoints;

    private readonly AnimationController animationController = new AnimationController();

    private Transform torso;
    private Transform quantumSpawn;

    private GameObject bullet;

    private AudioClip[] audioClips;
    private AudioSource audioSource;

    private void Awake()
    {
        torso = GameObject.FindWithTag("PlayerTorso").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();
        bullet = Resources.Load<GameObject>("Bullet/QuantumEnergy");
        audioClips = GameManager.Instance.ResourceHolder.quantum;
        audioSource = transform.Find("EnergySource").gameObject.GetComponent<AudioSource>();
        hitPoints = GetComponent<EnemyState>().hitPoints;
    }



    private void Start()
    {
        quantumSpawn = transform.Find(
            "VanGuard/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/" +
            "mixamorig:Spine2/mixamorig:RightShoulder/" +
            "mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/SciFiGunLightBlue/EnergySpawn");
        startTimeBetweenShots = timeBetweenShots;
    }

    private void Update()
    {
        navMeshAgent.destination = player.position;

        Vector3 velocity = transform.InverseTransformDirection(navMeshAgent.velocity);
        float forward = velocity.z;
        float strafe = velocity.x;

        animationController.ControlAnimator(animator, forward, strafe);


        Debug.Log(hitPoints);
        GunFire();
    }

    private void GunFire()
    {
        float distance = Vector3.Distance(transform.position, torso.position);
        // Debug.LogWarning(distance);

        if (distance < 9 && hitPoints > 0)
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (timeBetweenShots <= 0)
        {

            if(quantumSpawn != null)
            {
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)], 1);
                Instantiate(bullet, quantumSpawn.position, quantumSpawn.rotation);
            }
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

}
