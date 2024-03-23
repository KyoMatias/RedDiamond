using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadSceneFromString(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
