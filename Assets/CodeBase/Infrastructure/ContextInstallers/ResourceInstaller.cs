﻿using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.StaticData;
using Zenject;

namespace CodeBase.Infrastructure.ContextInstallers
{
    public class ResourceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBubblePreferences();
            BindSpawnerPreferences();
            BindGamePreferences();
        }
        private void BindBubblePreferences() =>
            Container
                .BindInterfacesAndSelfTo<BubblePreferences>()
                .FromResource(AssetPath.BubblePreferences)
                .AsSingle();
        private void BindSpawnerPreferences() =>
            Container
                .BindInterfacesAndSelfTo<SpawnPreferences>()
                .FromResource(AssetPath.SpawnerPreferences)
                .AsSingle();
        private void BindGamePreferences() =>
            Container
                .BindInterfacesAndSelfTo<GamePreferences>()
                .FromResource(AssetPath.GamePreferences)
                .AsSingle();
    }
}