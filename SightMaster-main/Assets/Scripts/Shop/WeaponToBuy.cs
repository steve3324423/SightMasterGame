using UnityEngine;

public class WeaponToBuy : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private int _id;

    public int GetId()
    {
        return _id;
    }

    public int GetPrice()
    {
        return _price;
    }
}
