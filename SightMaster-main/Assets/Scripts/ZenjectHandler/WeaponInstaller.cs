using UnityEngine;
using Zenject;

public class WeaponInstaller : MonoInstaller
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PauseHandler _pauseHandler;
    [SerializeField] private ShootButton _shootButton;
    [SerializeField] private LevelEnder _levelEnder;
    [SerializeField] private AimButton _aimButton;

    public override void InstallBindings()
    {
        if (Application.isMobilePlatform)
            Container.Bind<IInputWeapon>().To<MobileInput>().AsSingle();
        else
            Container.Bind<IInputWeapon>().To<DekstopWeapon>().AsSingle();

        Container.Bind<PlayerHealth>().FromInstance(_playerHealth).AsSingle();
        Container.Bind<AimButton>().FromInstance(_aimButton).AsSingle();
        Container.Bind<ShootButton>().FromInstance(_shootButton).AsSingle();
        Container.Bind<PauseHandler>().FromInstance(_pauseHandler).AsSingle();
        Container.Bind<LevelEnder>().FromInstance(_levelEnder).AsSingle();
        Container.Bind<Aim>().FromComponentOnRoot().AsSingle();
    }
}
