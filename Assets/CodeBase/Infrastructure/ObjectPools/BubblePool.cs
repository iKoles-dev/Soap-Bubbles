using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.ObjectPools
{
    public class BubblePool : BasePool<GameObject>
    {
        public BubblePool(BubblePreferences bubblePreferences)
        {
            Fill(bubblePreferences.PoolSize, bubblePreferences.BubblePrefab);
        }

        protected override GameObject CreateObject(GameObject prefab)
        {
            return Object.Instantiate(prefab);
        }

        protected override void Deactivate(GameObject obj)
        {
            obj.SetActive(false);
        }

        protected override void Activate(GameObject obj)
        {
            obj.SetActive(true);
        }
    }
}