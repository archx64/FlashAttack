using UnityEngine;

public class FootSteps : MonoBehaviour
{
    private AudioSource footStepSource;
    private InputController inputController;
    private ResourceHolder audioHolder;

    private bool canPlay = false;

    private void Awake()
    {
        inputController = GameManager.Instance.InputController;
        audioHolder = GameManager.Instance.ResourceHolder;
    }

    private void Start()
    {
        canPlay = true;
        footStepSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector2 value = new Vector2(inputController.MovementHorizontal(), inputController.MovementVertical());
        PlaySounds(value);
    }

    private void PlaySounds(Vector2 value)
    {
        if (value.magnitude > 0.7f)
        {
            PlayFootSteps(audioHolder.footSteps, footStepSource, 1.5f - value.magnitude, value.magnitude);
        }
    }

    public void PlayFootSteps(AudioClip[] footSteps, AudioSource audioSource, float delay, float volume)
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
