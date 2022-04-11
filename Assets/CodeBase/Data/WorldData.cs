using System;

namespace CodeBase.Data
{
    [Serializable]
    public class WorldData
    {
        public Vector3Data Position;
        public PositionOnLevel PositionOnLevel;

        public WorldData(string initialLevel)
        {
            PositionOnLevel = new PositionOnLevel(initialLevel);
        }
    }
}