using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PinguiMover : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private Transform[] _targets;

    private Rigidbody _rigidbody;
    private int _currentTarget;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentTarget = 0;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        Vector3 direction = (_targets[_currentTarget].position - transform.position).normalized;
        //direction.y = transform.position.y;

        Debug.Log(direction.x + ", " + direction.y + " " + direction.z);        

        _rigidbody.MovePosition(transform.position + direction * _speed * Time.fixedDeltaTime);
    }
}
