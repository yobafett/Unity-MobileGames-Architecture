using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private const string HERO_PATH = "Hero/Hero";
        private const string HUD_PATH = "Hud/Hud";

        public GameObject CreateHero(GameObject at) => 
            Instantiate(HERO_PATH, at.transform.position);

        public void CreateHud() => 
            Instantiate(HUD_PATH);

        private static GameObject Instantiate(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private static GameObject Instantiate(string path, Vector3 at)
        {
            GameObject prefab =Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}