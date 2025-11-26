using UnityEngine;

public class AudioGames : MonoBehaviour
{
    private static AudioGames _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this);
    }
}
