using CodeBase.Infrastructure.StaticData;

namespace CodeBase.Infrastructure.Services.BubbleSpawner
{
    public class BubbleSpawnerService
    {
        private readonly SpawnerPreferences _spawnerPreferences;

        public BubbleSpawnerService(SpawnerPreferences spawnerPreferences) => 
            _spawnerPreferences = spawnerPreferences;

        public void StartSpawn()
        {
            
        }
    }
}