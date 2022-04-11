using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.Logic
{
	public class SaveTrigger : MonoBehaviour
	{
		public BoxCollider Collider;
		private ISaveLoadService _saveLoadService;

		private void Awake()
		{
			_saveLoadService = AllServices.Container.Single<ISaveLoadService>();
		}

		private void OnDrawGizmos()
		{
			if (!Collider)
				return;

			Gizmos.color = new Color32(30, 200, 30, 130);
			Gizmos.DrawCube(transform.position + Collider.center, Collider.size);
		}

		private void OnTriggerEnter(Collider other)
		{
			_saveLoadService.SaveProgress();
			Debug.Log("Progress saved.");
			gameObject.SetActive(false);
		}
	}
}