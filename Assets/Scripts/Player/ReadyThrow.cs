using UnityEngine;

public class ReadyThrow : MonoBehaviour
{
    [SerializeField] private BulldogFish _bulldogFish;

    public void Throw()
    {
        _bulldogFish.OnShoot();
    }
}