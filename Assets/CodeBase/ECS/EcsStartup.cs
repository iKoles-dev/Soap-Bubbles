using Leopotam.Ecs;
using Zenject;

namespace CodeBase.ECS
{
    public class EcsStartup : ITickable
    {
        public EcsWorld World;
        private EcsSystems _systems;

        [Inject]
        private void Construct()
        {
            World = new EcsWorld();
            _systems = new EcsSystems(World);
            
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