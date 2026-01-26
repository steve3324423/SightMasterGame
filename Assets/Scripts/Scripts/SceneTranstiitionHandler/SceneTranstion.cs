using UnityEngine;
using UnityEngine.SceneManagement;

namespace SightMaster.Scripts.SceneTransition
{
    public class SceneTranstion : MonoBehaviour
    {
        [SerializeField] private string _sceneName;

        public void TransitionToScene()
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
