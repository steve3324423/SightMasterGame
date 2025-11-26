using UnityEngine;

public class SoundGet : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    public AudioClip GetClip()
    { 
        return _clip; 
    }
}
