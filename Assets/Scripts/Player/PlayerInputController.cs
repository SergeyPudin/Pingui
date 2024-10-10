using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent (typeof(PlayerSpiner))]
[RequireComponent(typeof(Attacker))]
public class PlayerInputController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Palm _palm;
    private Bulldog _bulldog;
    private Attacker _attacker;

    private void Awake()
    {
        _playerInput = new();
        _palm = GetComponent<Palm>();
        _bulldog = GetComponent<Bulldog>();
        _attacker = GetComponent<Attacker>();
        _playerInput.Player.Shoot.performed += OnShoot;
        _playerInput.Player.AlternativeShoot.performed += OnAlternativeShoot;
        _playerInput.Player.PalmChoose.performed += GetPalm;
        _playerInput.Player.BulldogChoose.performed += GetBulldog;
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
        _attacker.Shoot();
    }

    private void OnAlternativeShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Alternative Shoot");
    }

    private void GetPalm(InputAction.CallbackContext context)
    {
        _bulldog.TryGetPalm();
    }

    private void GetBulldog(InputAction.CallbackContext context)
    {
        _palm.TrySetBulldog();
    }
}