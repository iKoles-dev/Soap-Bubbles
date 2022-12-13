using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.TapToStart;
using CodeBase.Infrastructure.Services.UI.DeathCounter;
using Zenject;

namespace CodeBase.Infrastructure.ContextInstallers
{
    public class UiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BinTapToStart();
            BindDeathCounter();
        }

        private void BindDeathCounter() =>
            Container
                .BindInterfacesAndSelfTo<DeathCounterService>()
                .FromComponentInNewPrefabResource(AssetPath.DeathCounter)
                .AsSingle();

        private void BinTapToStart() =>
            Container
                .BindInterfacesAndSelfTo<TapToStartService>()
                .FromComponentInNewPrefabResource(AssetPath.TapToStart)
                .AsSingle();
    }
}