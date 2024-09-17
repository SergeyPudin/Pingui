public interface IWeapon
{
    void Shoot();
    void AlternativeShoot();

    int CurrentAmmo { get; }
    int MaxAmmo { get; }
    bool IsReloading { get; }
}
