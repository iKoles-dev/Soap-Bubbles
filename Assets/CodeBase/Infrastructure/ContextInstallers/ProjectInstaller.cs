using CodeBase.ECS;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.ObjectPools;
using CodeBase.Infrastructure.Services.BubbleSpawner;
using CodeBase.Infrastructure.StaticData;
using Zenject;

namespace CodeBase.Infrastructure.ContextInstallers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindAssetProvider();
            BindBubblePreferences();
            BindBubblePool();
            BindBubbleSpawner();
            BindSpawnerPreferences();
            BindECS();
        }

        private void BindBubblePreferences() =>
            Container
                .BindInterfacesAndSelfTo<BubblePreferences>()
                .FromResource(AssetPath.BubblePreferences)
                .AsSingle();

        private void BindAssetProvider() =>
            Container
                .BindInterfacesAndSelfTo<AssetProvider>()
                .AsSingle();

        private void BindBubblePool() =>
            Container
                .BindInterfacesAndSelfTo<BubblePool>()
                .AsSingle();

        private void BindBubbleSpawner() =>
            Container
                .BindInterfacesAndSelfTo<BubbleSpawnerService>()
                .AsSingle();

        private void BindSpawnerPreferences() =>
            Container
                .BindInterfacesAndSelfTo<SpawnerPreferences>()
                .FromResource(AssetPath.SpawnerPreferences)
                .AsSingle();

        private void BindECS() =>
            Container
                .BindInterfacesAndSelfTo<EcsStartup>()
                .AsSingle()
                .NonLazy();
    }
}