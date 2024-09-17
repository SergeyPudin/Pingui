using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class BulldogFishBullet : MonoBehaviour
{
    [SerializeField] private float _strenght = 1000f;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void TrowingFish()
    {
        if (_direction != null)
        {
            _rigidbody.velocity = _direction * _strenght;
        }
    }

    public void Initialize(Vector3 direction)
    {
        _direction = direction;
    }
}