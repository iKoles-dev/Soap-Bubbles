using Leopotam.Ecs;
using Zenject;

namespace CodeBase.ECS
{
    public class EcsStartup : ITickable
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        [Inject]
        private void Construct()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            
            // _systems
            //     .OneFrame<AddVFX>()
            //     .OneFrame<DamageComponent>()
            //     .OneFrame<DamageDealer>()
            //     .OneFrame<ExplosionComponent>()
            //     .OneFrame<PushComponent>()
            //     .Inject(fxPool)
            //     .Inject(enemyFactory)
            //     .Inject(vfxTextService)
            //     .Inject(playerStatsService);
            _systems.Init();
        }
        public void Tick() => _systems.Run();
    }
}