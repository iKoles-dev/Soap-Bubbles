using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "SpawnerPreferences", menuName = "Preferences/Create Spawner Preferences")]
    public class SpawnerPreferences : ScriptableObject
    {
        public int BubblesPerSecond;
        public float MinSpeed;
        public float MaxSpeed;
        public float MinSize;
        public float MaxSize;
    }
}