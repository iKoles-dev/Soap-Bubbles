using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.ObjectPools;
using CodeBase.Infrastructure.Services.BubblesHolder;
using CodeBase.Infrastructure.Services.BubbleSpawner;
using CodeBase.Infrastructure.Services.ClickDetector;
using CodeBase.Infrastructure.Services.GameSpeedMultiplier;
using CodeBase.Infrastructure.Services.ImpactSpawner;
using CodeBase.Infrastructure.Services.Move;
using CodeBase.Infrastructure.Services.OutScreenPositioner;
using CodeBase.Infrastructure.Services.OutScreenRemover;
using CodeBase.Infrastructure.Services.SizeRandomizer;
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
            BindOutScreenPositioner();
            BindSizeRandomizer();
            BindGamePreferences();
            BindGameSpeedMultiplier();
            BindBubbleFactory();
            BindBubblesHolder();
            BindMoveService();
            BindOutScreenRemover();
            BindImpactPool();
            BindImpactSpawner();
        }


        private void BindBubblesHolder() =>
            Container
                .BindInterfacesAndSelfTo<BubblesHolderService>()
                .AsSingle();

        private void BindGameSpeedMultiplier() =>
            Container
                .BindInterfacesAndSelfTo<GameGameSpeedMultiplierService>()
                .AsSingle();

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
                .BindInterfacesAndSelfTo<SpawnPreferences>()
                .FromResource(AssetPath.SpawnerPreferences)
                .AsSingle();

        private void BindOutScreenPositioner() =>
            Container
                .BindInterfacesAndSelfTo<OutScreenPositionerService>()
                .AsSingle();

        private void BindSizeRandomizer() =>
            Container
                .BindInterfacesAndSelfTo<SizeAndSpeedRandomizerService>()
                .AsSingle();

        private void BindGamePreferences() =>
            Container
                .BindInterfacesAndSelfTo<GamePreferences>()
                .FromResource(AssetPath.GamePreferences)
                .AsSingle();

        private void BindBubbleFactory() =>
            Container
                .BindInterfacesAndSelfTo<BubbleFactory>()
                .AsSingle();

        private void BindMoveService() =>
            Container
                .BindInterfacesAndSelfTo<MoveService>()
                .AsSingle()
                .NonLazy();

        private void BindOutScreenRemover() =>
            Container
                .BindInterfacesAndSelfTo<OutScreenRemoverService>()
                .AsSingle()
                .NonLazy();

        private void BindImpactPool() =>
            Container
                .BindInterfacesAndSelfTo<ImpactPool>()
                .AsSingle();

        private void BindImpactSpawner() =>
            Container
                .BindInterfacesAndSelfTo<ImpactSpawnerService>()
                .AsSingle();
    }
}