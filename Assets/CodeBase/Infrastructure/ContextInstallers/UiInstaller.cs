using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.TapToStart;
using Zenject;

namespace CodeBase.Infrastructure.ContextInstallers
{
    public class UiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BinTapToStart();
        }

        private void BinTapToStart() =>
            Container
                .BindInterfacesAndSelfTo<TapToStartService>()
                .FromComponentInNewPrefabResource(AssetPath.TapToStart)
                .AsSingle();
    }
}