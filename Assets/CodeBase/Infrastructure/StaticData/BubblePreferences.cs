using CodeBase.SoapBubble;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "BubblePreferences", menuName = "Preferences/Create Bubble Preferences")]
    public class BubblePreferences : ScriptableObject
    {
        public EntityHolder BubblePrefab;
        public int PoolSize;
    }
}