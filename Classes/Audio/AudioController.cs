using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioClip[] footSteps;

    private AudioSource footStepSource;
    private InputController inputController;

    private bool canPlay;

    private void Awake()
    {
        inputController = GameManager.Instance.InputController;
    }

    private void Start()
    {
        canPlay = true;
        footStepSource = GameObject.FindWithTag("FootSteps").GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector2 value = new Vector2(inputController.MovementHorizontal(), inputController.MovementVertical());
        PlaySounds(value);
    }

    protected void PlaySounds(Vector2 value)
    {
        if (value.magnitude > 0.7f)
        {
            PlayFootSteps(1.5f - value.magnitude, value.magnitude, footStepSource);
        }
    }

    protected void PlayFootSteps(float delay, float volume, AudioSource audioSource)
    {
        Debug.Log("Playing");
        if (!canPlay)
        {
            return;
        }

        GameManager.Instance.Timer.Add(() =>
        {
            canPlay = true;
        }, delay);
        canPlay = false;

        AudioClip footStep = footSteps[Random.Range(0, footSteps.Length)];
        audioSource.PlayOneShot(footStep, volume);
    }
}
