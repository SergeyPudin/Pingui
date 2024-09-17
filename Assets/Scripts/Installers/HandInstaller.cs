using UnityEngine;
using Zenject;

public class HandInstaller : MonoInstaller
{
    [SerializeField] private Arm _arm;
    public override void InstallBindings()
    {
        Container.Bind<Arm>().FromInstance(_arm);
    }
}