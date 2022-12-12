using System;
using CodeBase.ECS.SoapBubble.Components;
using CodeBase.Infrastructure.ObjectPools;
using CodeBase.Infrastructure.StaticData;
using Leopotam.Ecs;
using UniRx;
using Random = UnityEngine.Random;

namespace CodeBase.Infrastructure.Services.BubbleSpawner
{
    public class BubbleSpawnerService
    {
        private readonly SpawnerPreferences _spawnerPreferences;
        private readonly BubblePool _bubblePool;
        private readonly CompositeDisposable _disposables = new();

        public BubbleSpawnerService(SpawnerPreferences spawnerPreferences, BubblePool bubblePool)
        {
            _spawnerPreferences = spawnerPreferences;
            _bubblePool = bubblePool;
        }

        public void StartSpawn()
        {
            Observable
                .Timer(TimeSpan.FromSeconds(1 / _spawnerPreferences.BubblesPerSecond))
                .Repeat()
                .Subscribe(_ =>
                {
                    EcsEntity bubble = _bubblePool.Get();
                    ref TransformComponent transform = ref bubble.Get<TransformComponent>();
                    transform.Transform.position = Random.onUnitSphere;
                })
                .AddTo(_disposables);
        }

        public void StopSpawn() => 
            _disposables.Clear();
    }
}