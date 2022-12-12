using CodeBase.Infrastructure.StaticData;
using CodeBase.SoapBubble;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SizeRandomizer
{
    public class SizeAndSpeedRandomizerService
    {
        private readonly SpawnPreferences _spawnPreferences;

        public SizeAndSpeedRandomizerService(SpawnPreferences spawnPreferences)
        {
            _spawnPreferences = spawnPreferences;
        }
        public void RandomizeSizeAndSpeed(ComponentsHolder componentsHolder)
        {
            float randomValue = Random.value;
            float sizeModificator = Mathf.Lerp(_spawnPreferences.MinSize, _spawnPreferences.MaxSize, randomValue);
            Vector3 targetSize = Vector3.one * sizeModificator;
            componentsHolder.Transform.localScale = targetSize;
            componentsHolder.Radius = sizeModificator / 2;
            componentsHolder.Speed = Mathf.Lerp(_spawnPreferences.MaxSpeed, _spawnPreferences.MinSpeed, randomValue);
        }
    }
}