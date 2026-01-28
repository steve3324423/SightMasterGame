using SightMaster.Scripts.HandlerPause;
using SightMaster.Scripts.LevelHandler;
using SightMaster.Scripts.Player;
using SightMaster.Scripts.UI;
using SightMaster.Scripts.UI.Android;
using SightMaster.Scripts.Weapon;
using SightMaster.Scripts.Weapon.AimHandler;
using UnityEngine;
using Zenject;

namespace SightMaster.Scripts.ZenjectHandler
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private DekstopInputHandler _dekstopHandler;
        [SerializeField] private PlayerCameraStateHandler _playerCameraStateHandler;
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
            Container.Bind<PlayerCameraStateHandler>().FromInstance(_playerCameraStateHandler).AsSingle();
            Container.Bind<LevelEnder>().FromInstance(_levelEnder).AsSingle();
            Container.Bind<DekstopInputHandler>().FromInstance(_dekstopHandler).AsSingle();
        }
    }
}
