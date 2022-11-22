using UnityEngine;
using Zenject;

public class CharacterDetailInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CharacterDetailStateModel>().AsSingle().NonLazy();
    }
}