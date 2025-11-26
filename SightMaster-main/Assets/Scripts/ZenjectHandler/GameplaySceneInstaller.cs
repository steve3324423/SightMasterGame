using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private CameraRotationMobile _cameraRotation;
    [SerializeField] private CameraAimEnableHandler _cameraAim;

    public override void InstallBindings()
    {
        if (Application.isMobilePlatform)
            Container.Bind<IInput>().To<MobileWeaponInput>().AsSingle();
        else
            Container.Bind<IInput>().To<DekstopInput>().AsSingle();

        Container.Bind<CameraAimEnableHandler>().FromInstance(_cameraAim).AsSingle();
        Container.Bind<CameraRotationMobile>().FromInstance(_cameraRotation).AsSingle();
        Container.Bind<Mover>().FromComponentOnRoot().AsSingle();
    }
}
