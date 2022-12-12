using CodeBase.ECS.SoapBubble.Flags;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.SoapBubble
{
    [RequireComponent(typeof(EntityHolder))]
    public class ClickDetector : MonoBehaviour
    {
        private EntityHolder _entityHolder;

        private void Awake() => 
            _entityHolder = GetComponent<EntityHolder>();

        public void OnClick() => 
            _entityHolder.Entity.Get<ReturnToPool>();
    }
}