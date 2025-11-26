using UnityEngine;
using UnityEngine.UI;

public class SpriteGet : MonoBehaviour
{
    [SerializeField] private Texture _aim;

    public Texture GetTexture()
    {
        return _aim;
    }
}
