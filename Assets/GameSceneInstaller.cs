using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
       
        Container.Bind<IInput>().To<DesktopInput>().AsSingle();
      //  else
       // Container.Bind<IPlayerInput>().To<MobilePlayerInput>().AsSingle();
        
    }
}
