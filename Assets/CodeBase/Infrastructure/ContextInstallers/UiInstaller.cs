using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.TapToStart;
using CodeBase.Infrastructure.Services.UI.CountDownTimer;
using CodeBase.Infrastructure.Services.UI.DeathCounter;
using Zenject;

namespace CodeBase.Infrastructure.ContextInstallers
{
    public class UiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindTapToStart();
            BindDeathCounter();
            BindCountDownTimer();
        }

        private void BindDeathCounter() =>
            Container
                .BindInterfacesAndSelfTo<DeathCounterService>()
                .FromComponentInNewPrefabResource(AssetPath.DeathCounter)
                .AsSingle();

        private void BindTapToStart() =>
            Container
                .BindInterfacesAndSelfTo<TapToStartService>()
                .FromComponentInNewPrefabResource(AssetPath.TapToStart)
                .AsSingle();

        private void BindCountDownTimer() =>
            Container
                .BindInterfacesAndSelfTo<CountDownTimerService>()
                .FromComponentInNewPrefabResource(AssetPath.CountDownTimer)
                .AsSingle();
    }
}