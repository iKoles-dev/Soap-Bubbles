using CodeBase.Infrastructure.AssetManagement;
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
    }
}