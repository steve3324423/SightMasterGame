using SightMaster.Scripts.CameraHandlers;
using SightMaster.Scripts.Player;
using SightMaster.Scripts.Setting;
using UnityEngine;
using Zenject;

namespace SightMaster.Scripts.ZenjectHandler
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private CameraRotationMobile _cameraRotation;
        [SerializeField] private PlayerCameraController _playerCameraController;
        [SerializeField] private PlayerYawRotator _playerYawRotate;
        [SerializeField] private Sensitivity _sensitivity;

        public override void InstallBindings()
        {
            if (Application.isMobilePlatform)
                Container.Bind<IInput>().To<MobileWeaponInput>().AsSingle();
            else
                Container.Bind<IInput>().To<DekstopInput>().AsSingle();

            Container.Bind<PlayerCameraController>().FromInstance(_playerCameraController).AsSingle();
            Container.Bind<CameraRotationMobile>().FromInstance(_cameraRotation).AsSingle();
            Container.Bind<PlayerYawRotator>().FromInstance(_playerYawRotate).AsSingle();
            Container.Bind<Sensitivity>().FromInstance(_sensitivity).AsSingle();
            Container.Bind<Mover>().FromComponentOnRoot().AsSingle();
        }
    }
}
