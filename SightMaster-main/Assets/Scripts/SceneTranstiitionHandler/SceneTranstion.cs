using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTranstion : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void TransitionToScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
