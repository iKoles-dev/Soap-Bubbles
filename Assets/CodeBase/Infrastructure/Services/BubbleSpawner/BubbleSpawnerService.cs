using System;
using CodeBase.ECS.SoapBubble.Components;
using CodeBase.Infrastructure.ObjectPools;
using CodeBase.Infrastructure.Services.OutScreenPositioner;
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
        private readonly OutScreenPositionerService _outScreenPositionerService;
        private readonly CompositeDisposable _disposables = new();

        public BubbleSpawnerService(SpawnerPreferences spawnerPreferences, BubblePool bubblePool, OutScreenPositionerService outScreenPositionerService)
        {
            _spawnerPreferences = spawnerPreferences;
            _bubblePool = bubblePool;
            _outScreenPositionerService = outScreenPositionerService;
        }

        public void StartSpawn()
        {
            Observable
                .Timer(TimeSpan.FromSeconds(1 / _spawnerPreferences.BubblesPerSecond))
                .Repeat()
                .Subscribe(_ =>
                {
                    EcsEntity bubble = _bubblePool.Get();
                    _outScreenPositionerService.SetOnPosition(bubble);
                })
                .AddTo(_disposables);
        }

        public void StopSpawn() => 
            _disposables.Clear();
    }
}