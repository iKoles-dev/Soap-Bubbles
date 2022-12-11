using CodeBase.Infrastructure.ObjectPools;
using Zenject;

namespace CodeBase.Infrastructure.ContextInstallers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBubblePool();
        }

        private void BindBubblePool() =>
            Container
                .BindInterfacesAndSelfTo<BubblePool>()
                .AsSingle()
                .NonLazy();
    }
}