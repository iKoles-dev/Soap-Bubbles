using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "BubblePreferences", menuName = "Preferences/Create Bubble Preferences")]
    public class BubblePreferences : ScriptableObject
    {
        public GameObject BubblePrefab;
        public int PoolSize;
    }
}