using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent (typeof(PlayerSpiner))]
public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private BulldogFish _weapon; // Сделать подругее

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new();
        _playerInput.Player.Shoot.performed += OnShoot;
        _playerInput.Player.AlternativeShoot.performed += OnAlternativeShoot;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public float GetVertical()
    {
        return _playerInput.Player.Move.ReadValue<Vector2>().y;
    }

    public float GetHorizontal()
    {
        return _playerInput.Player.Move.ReadValue<Vector2>().x;
    }

    public Vector2 GetDelta()
    {
        return _playerInput.Player.Look.ReadValue<Vector2>();
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        _weapon.Shoot();
    }

    private void OnAlternativeShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Alternative Shoot");
    }
}
