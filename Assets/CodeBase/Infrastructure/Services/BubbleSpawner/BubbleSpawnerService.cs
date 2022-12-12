using System;
using CodeBase.Infrastructure.ObjectPools;
using CodeBase.Infrastructure.StaticData;
using UniRx;
using Random = UnityEngine.Random;

namespace CodeBase.Infrastructure.Services.BubbleSpawner
{
    public class BubbleSpawnerService
    {
        private readonly SpawnerPreferences _spawnerPreferences;
        private readonly BubblePool _bubblePool;
        private CompositeDisposable _disposables;

        public BubbleSpawnerService(SpawnerPreferences spawnerPreferences, BubblePool bubblePool)
        {
            _spawnerPreferences = spawnerPreferences;
            _bubblePool = bubblePool;
        }

        public void StartSpawn()
        {
            Observable
                .Timer(TimeSpan.FromMilliseconds(1 / _spawnerPreferences.BubblesPerSecond))
                .Repeat()
                .Subscribe(_ =>
                {
                    var bubble = _bubblePool.Get();
                    bubble.transform.position = Random.onUnitSphere;
                })
                .AddTo(_disposables);
        }

        public void StopSpawn() => 
            _disposables.Clear();
    }
}