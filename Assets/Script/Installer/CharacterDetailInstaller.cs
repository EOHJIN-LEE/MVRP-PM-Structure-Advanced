using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Database>().AsSingle().NonLazy();
        Container.Bind<CharacterDetailStateModel>().AsSingle().NonLazy();
    }
}