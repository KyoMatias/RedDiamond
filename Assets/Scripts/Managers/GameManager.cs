using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameEvent _onGameStart;

    private void Start()
    {
        _onGameStart.Raise();
    }

    public void LoadSceneFromString(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
