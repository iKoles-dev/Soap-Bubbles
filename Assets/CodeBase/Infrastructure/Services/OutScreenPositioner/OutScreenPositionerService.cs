using CodeBase.ECS.SoapBubble.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.OutScreenPositioner
{
    public class OutScreenPositionerService
    {
        private readonly float _borderSize;
        private readonly float _downBorder;
        public OutScreenPositionerService()
        {
            float orthographicSize = Camera.main.orthographicSize;
            _borderSize = orthographicSize * Screen.width / Screen.height;
            _downBorder = - orthographicSize;
        }
        public void SetOnPosition(EcsEntity ecsEntity)
        {
            ref ColliderComponent colliderComponent = ref ecsEntity.Get<ColliderComponent>();
            float halfSize = colliderComponent.Collider.bounds.size.x / 2;
            ref TransformComponent transformComponent = ref ecsEntity.Get<TransformComponent>();
            transformComponent.Transform.position = new Vector3(Mathf.Lerp(-_borderSize + halfSize, _borderSize - halfSize, Random.value), _downBorder - halfSize, 0);
        }
    }
}