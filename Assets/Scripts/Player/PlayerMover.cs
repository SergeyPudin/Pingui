using UnityEngine;

[RequireComponent(typeof(PlayerSpiner))]
[RequireComponent (typeof(PlayerInputController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _strafeSpeed = 3f;
    [SerializeField] private float _jumpSpeed = 5f;
    [SerializeField] private float _gravityFactor = 2f;
  
    private Transform _transform;
    private CharacterController _characterController;   
    private Vector3 _verticalVelocity;
    private PlayerSpiner _playerSpiner;
    private PlayerInputController _playerInputController;

    private void Awake()
    {
        _playerInputController = GetComponent<PlayerInputController>();
        _characterController = GetComponent<CharacterController>();
        
        _playerSpiner = GetComponent<PlayerSpiner>();
    }

    private void Update()
    {
        if (_characterController != null)
        {
            Vector3 playerSpeed = _playerSpiner.GetDirectionForward() * _playerInputController.GetVertical() * _moveSpeed +
                                  _playerSpiner.GetDirectionRight() * _playerInputController.GetHorizontal() * _strafeSpeed;

            if (_characterController.isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _verticalVelocity = Vector3.up * _jumpSpeed;
                }
                else
                {
                    _verticalVelocity = Vector3.down;
                }

                _characterController.Move((playerSpeed + _verticalVelocity) * Time.deltaTime);
            }
            else
            {
                Vector3 horizontalVelociy = _characterController.velocity;
                horizontalVelociy.y = 0;
                _verticalVelocity += Physics.gravity * Time.deltaTime * _gravityFactor;
                _characterController.Move((horizontalVelociy + _verticalVelocity) * Time.deltaTime);
            }
        }
    }
}