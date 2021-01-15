using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private void Update()
    {
        Invoke(nameof(LoadMainLevel), 5);
    }

    private void LoadMainLevel()
    {
        Application.Quit();
    }
}
