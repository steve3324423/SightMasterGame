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
<<<<<<< HEAD
        [SerializeField] private PlayerCameraStateHandler _playerCameraStateHandler;
=======
<<<<<<< HEAD
        [SerializeField] private PlayerCameraStateHandler _playerCameraStateHandler;
=======
>>>>>>> 260d11f54f0a553fd0d0ae97e7000bb9c9251ea8
>>>>>>> 7c40df2c669c8240bcf268ac9925faf2830489a2
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
