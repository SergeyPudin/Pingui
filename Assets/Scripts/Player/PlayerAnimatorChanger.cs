using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnimatorChanger : MonoBehaviour
{
    private const string Shoot = "Shoot";
    private const string Reload = "Reload";
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ShootAnimation()
    {
        _animator.SetTrigger(Shoot);
    }

    public void ReloadAnimation()
    {
        _animator.SetTrigger(Reload);
    }
}
