using UnityEngine;

[RequireComponent (typeof(PlayerInputController))]
public class PlayerSpiner : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _horizontalTurnSensitivity = 10f;
    [SerializeField] private float _verticalTurnSensitivity = 10f;
    [SerializeField] private float _verticalMinAngle = -89f;
    [SerializeField] private float _verticalMaxAngle = 89f;

    private float _cameraAngle = 0;
    private Transform _transform;
    private PlayerInputController _playerInputController;

    private void Awake()
    {
        _transform = transform;
        _playerInputController = GetComponent<PlayerInputController>();
        _cameraAngle = _cameraTransform.localEulerAngles.x;
    }

    private void Update()
    {
        _cameraAngle -= _playerInputController.GetDelta().y * _verticalTurnSensitivity;
        _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
        _cameraTransform.localEulerAngles = Vector3.right * _cameraAngle;

        _transform.Rotate(Vector3.up * _horizontalTurnSensitivity * _playerInputController.GetDelta().x);
    }

    public Vector3 GetDirectionForward()
    {
        return Vector3.ProjectOnPlane(_cameraTransform.forward, Vector3.up).normalized;
    }

    public Vector3 GetDirectionRight()
    {
        return Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;
    }
}