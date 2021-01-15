using UnityEngine;

public class ResourceHolder : MonoBehaviour
{
    public AudioClip[] footSteps;
    public AudioClip[] quantum;

    public GameObject shell;

    private void Awake()
    {
        footSteps = Resources.LoadAll<AudioClip>("Audio/Footsteps");
        quantum = Resources.LoadAll<AudioClip>("Audio/Future/Laser");
        shell = Resources.Load<GameObject>("Bullet/Shell");
    }
}
