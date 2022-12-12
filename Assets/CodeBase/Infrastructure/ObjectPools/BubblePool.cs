using CodeBase.ECS;
using CodeBase.ECS.SoapBubble.Components;
using CodeBase.Infrastructure.StaticData;
using CodeBase.SoapBubble;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Infrastructure.ObjectPools
{
    public class BubblePool : BasePool<EntityHolder, EcsEntity>
    {
        private readonly BubblePreferences _bubblePreferences;
        private readonly EcsStartup _ecsStartup;

        public BubblePool(BubblePreferences bubblePreferences, EcsStartup ecsStartup)
        {
            _bubblePreferences = bubblePreferences;
            _ecsStartup = ecsStartup;
        }

        public void Initialize() => 
            Fill(_bubblePreferences.PoolSize, _bubblePreferences.BubblePrefab);

        protected override EcsEntity CreateObject(EntityHolder prefab)
        {
            EntityHolder bubble = Object.Instantiate(prefab);
            EcsEntity ecsEntity = _ecsStartup.World.NewEntity();
            bubble.Entity = ecsEntity;
            
            ref ColliderComponent colliderComponent = ref ecsEntity.Get<ColliderComponent>();
            colliderComponent.Collider = bubble.GetComponent<Collider>();
            
            ref TransformComponent transformComponent = ref ecsEntity.Get<TransformComponent>();
            transformComponent.Transform = bubble.transform;
            
            ref GameObjectComponent gameObjectComponent = ref ecsEntity.Get<GameObjectComponent>();
            gameObjectComponent.GameObject = bubble.gameObject;
            
            return ecsEntity;
        }

        protected override void Deactivate(EcsEntity obj)
        {
            ref GameObjectComponent gameObject = ref obj.Get<GameObjectComponent>();
            gameObject.GameObject.SetActive(false);
        }

        protected override void Activate(EcsEntity obj)
        {
            ref GameObjectComponent gameObject = ref obj.Get<GameObjectComponent>();
            gameObject.GameObject.SetActive(true);
        }
    }
}