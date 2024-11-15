using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private Joystick joystick;
    public override void InstallBindings()
    {
        if (SystemInfo.deviceType != DeviceType.Desktop)
        {
            Container.Bind<IInput>().To<MobileInput>().AsSingle();
            Container.Bind<Joystick>().FromInstance(joystick).AsSingle().NonLazy();
            joystick.gameObject.SetActive(true);
        }
        else
        {
            
            Container.Bind<IInput>().To<DesktopInput>().AsSingle();
        }

    }
}
