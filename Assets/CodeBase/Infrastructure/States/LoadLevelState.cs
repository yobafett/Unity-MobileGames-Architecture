using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
	public class LoadLevelState : IPayloadedState<string>
	{
		private const string INITIAL_POINT_TAG = "InitialPoint";
		private readonly LoadingCurtain _curtain;
		private readonly IGameFactory _gameFactory;
		private readonly IPersistentProgressService _progressService;
		private readonly SceneLoader _sceneLoader;

		private readonly GameStateMachine _stateMachine;

		public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain,
			IGameFactory gameFactory, IPersistentProgressService progressService)
		{
			_stateMachine = stateMachine;
			_sceneLoader = sceneLoader;
			_curtain = curtain;
			_gameFactory = gameFactory;
			_progressService = progressService;
		}

		public void Enter(string sceneName)
		{
			_curtain.Show();
			_gameFactory.CleanUp();
			_sceneLoader.Load(sceneName, OnLoaded);
		}

		public void Exit()
		{
			_curtain.Hide();
		}

		private void OnLoaded()
		{
			InitGameWorld();
			InformProgressReaders();
			_stateMachine.Enter<GameLoopState>();
		}

		private void InformProgressReaders()
		{
			foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
				progressReader.LoadProgress(_progressService.Progress);
		}

		private void InitGameWorld()
		{
			GameObject hero = _gameFactory.CreateHero(GameObject.FindWithTag(INITIAL_POINT_TAG));

			_gameFactory.CreateHud();

			CameraFollow(hero);
		}

		private void CameraFollow(GameObject hero)
		{
			Camera.main
				.GetComponent<CameraFollow>()
				.Follow(hero);
		}
	}
}