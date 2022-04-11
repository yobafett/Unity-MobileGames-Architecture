using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Inputs;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
	public class BootstrapState : IState
	{
		private const string INITIAL = "Initial";
		private readonly SceneLoader _sceneLoader;
		private readonly AllServices _services;
		private readonly GameStateMachine _stateMachine;

		public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
		{
			_stateMachine = stateMachine;
			_sceneLoader = sceneLoader;
			_services = services;

			RegisterServices();
		}

		public void Enter()
		{
			_sceneLoader.Load(INITIAL, EnterLoadLevel);
		}

		public void Exit()
		{
		}

		private void EnterLoadLevel()
		{
			_stateMachine.Enter<LoadProgressState>();
		}

		private void RegisterServices()
		{
			_services.RegisterSingle(InputService());
			_services.RegisterSingle<IAssets>(new AssetsProvider());
			_services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));
			_services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
			_services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>(),
				_services.Single<IGameFactory>()));
		}

		private static IInputService InputService()
		{
			if (Application.isEditor)
				return new StandaloneInputService();
			return new MobileInputService();
		}
	}
}