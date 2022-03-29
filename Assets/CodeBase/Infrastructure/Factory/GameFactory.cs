using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject at) =>
            _assets.Instantiate(AssetPath.HERO_PATH, at.transform.position);

        public void CreateHud() =>
            _assets.Instantiate(AssetPath.HUD_PATH);
    }
}