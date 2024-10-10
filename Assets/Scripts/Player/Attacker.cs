using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private PlayerAnimatorChanger _animatorChanger;
    [SerializeField] private BulldogFishBullet _bulldogFishPrefab;
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private State _palmState;
    [SerializeField] private State _bulldogState;

    public void OnShootBulldog()
    {
        Vector3 directon = (_target.position - _bulletPoint.position).normalized;
        
        BulldogFishBullet currentFish = Instantiate(_bulldogFishPrefab, _bulletPoint.transform.position, _bulldogFishPrefab.transform.rotation);
        currentFish.transform.rotation = Quaternion.LookRotation(directon);
        currentFish.Initialize(directon);
        currentFish.TrowingFish();
    }

    public void Shoot()
    {
        if (_palmState.enabled == true)
        {
            _animatorChanger.SlapAnimation();
        }
        else if (_bulldogState.enabled == true)
        {
            _animatorChanger.BulldogShootAnimation();
        }
    }
}