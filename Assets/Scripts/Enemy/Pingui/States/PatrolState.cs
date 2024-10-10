using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PatrolState : State
{
    [SerializeField] private Transform[] _targets;
    [SerializeField] private float _speed = 0.5f;

    private Rigidbody _rigidbody;
    private int _currentTarget;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentTarget = 0;
    }

    private void FixedUpdate()
    {
        TryChangeTarget();

        Vector3 direction = (_targets[_currentTarget].position - transform.position).normalized;
        direction.y = 0;

        if (direction.sqrMagnitude > 0.1f)
        {
            LookToTarget(direction);
            Move(direction);
        }
    }

    private void TryChangeTarget()
    {
        if (_targets[_currentTarget].position.x - transform.position.x < 0.5f &&
            _targets[_currentTarget].position.z - transform.position.z < 0.5f)
            _currentTarget = (_currentTarget + 1) % _targets.Length;
    }

    private void LookToTarget(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void Move(Vector3 direction)
    {
        _rigidbody.MovePosition(transform.position + direction * _speed * Time.fixedDeltaTime);
    }
}