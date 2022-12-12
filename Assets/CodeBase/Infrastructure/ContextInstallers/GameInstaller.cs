using CodeBase.Infrastructure.ObjectPools;
using CodeBase.Infrastructure.StateMachine;
using Zenject;

namespace CodeBase.Infrastructure.ContextInstallers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindBubblePool();
        }

        private void BindGameStateMachine() =>
            Container
                .BindInterfacesAndSelfTo<GameLoopStateMachine>()
                .AsSingle();

        private void BindBubblePool() =>
            Container
                .BindInterfacesAndSelfTo<BubblePool>()
                .AsSingle();
    }
}