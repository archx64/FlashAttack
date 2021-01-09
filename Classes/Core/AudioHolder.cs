using UnityEngine;

public class AudioHolder : MonoBehaviour
{
    public AudioClip[] footSteps;
    public AudioClip quantum;

    private void Awake()
    {
        footSteps = Resources.LoadAll<AudioClip>("Audio/Footsteps");
        quantum = Resources.Load<AudioClip>("Audio/FuturisticGunSoundFX/Laser/laser11");
    }
}
