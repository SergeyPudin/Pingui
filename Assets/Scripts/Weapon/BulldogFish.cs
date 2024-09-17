using System.Collections;
using UnityEngine;
using Zenject;

public class BulldogFish : MonoBehaviour, IWeapon
{
    [SerializeField] private int _maxAmmo = 8;
    [SerializeField] private float _throwDeley = 0.3f;
    [SerializeField] private BulldogFishBullet _fishPrefab;
    [SerializeField] private Vector3 _offcet;
    [SerializeField] private PlayerAnimatorChanger _animatorChanger;
    [SerializeField] private ReadyThrow _readyTrhow;

    private int _currentAmmo;
    private Arm _arm;
    private Transform _bulletPoint;

    public int CurrentAmmo => throw new System.NotImplementedException();
    public int MaxAmmo => _maxAmmo;
    public bool IsReloading => throw new System.NotImplementedException();

    [Inject]
    private void Construct(Arm arm)
    {
        _arm = arm;
    }

    private void Awake()
    {
        _currentAmmo = 5;
        _bulletPoint = _arm.BulletPoint;
    }

    public void AlternativeShoot()
    {
        throw new System.NotImplementedException();
    }

    public void Shoot()
    {
        if (_currentAmmo > 0)
        {
            _currentAmmo--;

            _animatorChanger.ShootAnimation();

        }

        //if (_currentAmmo > 0)
        //{
        //    _animatorChanger.ReloadAnimation();
        //}
    }

    public void OnShoot()
    {
            BulldogFishBullet currentFish = Instantiate(_fishPrefab, _bulletPoint.transform.position, _fishPrefab.transform.rotation);
            currentFish.transform.rotation = Quaternion.LookRotation(_arm.transform.forward);
            currentFish.Initialize(_arm.CameraTransform.forward);
            currentFish.TrowingFish();        
    }
}
