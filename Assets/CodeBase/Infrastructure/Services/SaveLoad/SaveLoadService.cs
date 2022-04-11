using CodeBase.Data;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
	public class SaveLoadService : ISaveLoadService
	{
		private const string PROGRESS_KEY = "Progress";
		private readonly IGameFactory _gameFactory;
		private readonly IPersistentProgressService _progressService;

		public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
		{
			_progressService = progressService;
			_gameFactory = gameFactory;
		}

		public void SaveProgress()
		{
			foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
				progressWriter.UpdateProgress(_progressService.Progress);

			PlayerPrefs.SetString(PROGRESS_KEY, _progressService.Progress.ToJson());
		}

		public PlayerProgress LoadProgress()
		{
			return PlayerPrefs.GetString(PROGRESS_KEY)?
				.ToDeserialized<PlayerProgress>();
		}
	}
}