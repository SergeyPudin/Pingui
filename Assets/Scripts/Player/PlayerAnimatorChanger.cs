using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnimatorChanger : MonoBehaviour
{
    [SerializeField] private BulldogFish _bulldogFish;

    private const string Shoot = "Shoot";
    private const string Slap = "Slap";
    private const string MoveOutFish = "MoveOut";
    private const string GetBulldogFish = "GetFish";
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void BulldogShootAnimation()
    {
        _animator.SetTrigger(Shoot);
    }

    public void SlapAnimation()
    {
        _animator.SetTrigger(Slap);
    }

    public void MoveOut()
    {
        _animator.SetTrigger(MoveOutFish);
    }

    public void GetFish()
    {
        _animator.SetTrigger(GetBulldogFish);
    }

    public void TurnOnFish()
    {
        _bulldogFish.gameObject.SetActive(true);
    }

    public void TurnOffFish()
    {
        _bulldogFish.gameObject.SetActive(false);
    }
}
