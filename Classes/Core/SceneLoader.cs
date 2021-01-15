using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void SceneToLoad(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
