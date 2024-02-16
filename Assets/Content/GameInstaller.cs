using System;
using UnityEngine;
using Zenject;

namespace SpacePortals
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private View _view;

        public override void InstallBindings()
        {
            BindAudioSystem();
            BindTimeIndication();

            BindMVP();  
        }
        private void BindAudioSystem()
        {
            Container.Bind<AudioSystem>().FromNew().AsSingle();
        }

        private void BindTimeIndication()
        {
            Container.BindInterfacesAndSelfTo<TimeIndication>().FromNew().AsSingle();
        }

        private void BindMVP()
        {
            Container.Bind<Model>().To<DefaultModel>().FromNew().AsSingle();
            Container.BindInstance(_view).AsSingle();
            Container.Bind(typeof(Presenter), typeof(IInitializable), typeof(IDisposable)).To<DefaultPresenter>().FromNew().AsSingle();
        }

        
    }
}
