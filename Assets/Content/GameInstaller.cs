using System;
using UnityEngine;
using Zenject;

namespace SpacePortals
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private View _view;
        [SerializeField] private PortalsTransformController _portalsTransformController;

        [Space]
        [SerializeField] private GlobalSFXSource _globalSFXSource;

        [Space]
        [SerializeField] private TakedEffectSpawner _takedEffectSpawner;

        [Space]
        [SerializeField] private Tutorial _tutorial;

        [Space]
        [SerializeField] private BallFactoryConfig _ballFactoryConfig;
        [SerializeField] private TakedEffectFactoryConfig _takeEffectFactoryConfig;
        [SerializeField] private PlayControllerConfig _playControllerConfig;

        [Space]
        [SerializeField] private ProgressManagerConfig _progressManagerConfig;

        public override void InstallBindings()
        {
            BindSaveManager();

            BindMVP();

            BindAudioSystem();
            BindTimeIndication();

            BindBallSpawner();
            BindBallMove();

            BindPortalsTransformController();

            BindTakeEffectSpawner();

            BindPlayController();

            BindTutorial();
        }

        private void BindSaveManager()
        {
            Container.BindInstance(_progressManagerConfig);
            Container.BindInterfacesAndSelfTo<ProgressManager>().FromNew().AsSingle();
        }

        private void BindMVP()
        {
            Container.Bind<Model>().To<DefaultModel>().FromNew().AsSingle();
            Container.BindInstance(_view).AsSingle();
            Container.Bind(typeof(Presenter), typeof(IInitializable), typeof(IDisposable)).To<DefaultPresenter>().FromNew().AsSingle();
        }

        private void BindAudioSystem()
        {
            Container.Bind<AudioSystem>().FromNew().AsSingle();
            Container.BindInstance(_globalSFXSource);
        }

        private void BindTimeIndication()
        {
            Container.BindInterfacesAndSelfTo<TimeIndication>().FromNew().AsSingle();
        }

        private void BindBallSpawner()
        {
            Container.BindInstance(_ballFactoryConfig);
            Container.Bind<BallFactory>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<BallSpawner>().FromNew().AsSingle();
        } 
        
        private void BindBallMove()
        {
            Container.Bind<BallMoveController>().FromNew().AsSingle();
        }

        private void BindPortalsTransformController()
        {
            Container.BindInstance(_portalsTransformController);
        }

        private void BindTakeEffectSpawner()
        {
            Container.BindInstance(_takeEffectFactoryConfig);
            Container.BindInstance(_takedEffectSpawner);
            Container.Bind<TakedEffectFactory>().FromNew().AsSingle();
        }

        private void BindPlayController()
        {
            Container.BindInstance(_playControllerConfig);
            Container.BindInterfacesAndSelfTo<PlayController>().FromNew().AsSingle();
        }

        private void BindTutorial()
        {
            Container.BindInstance(_tutorial);
        }
    }
}
