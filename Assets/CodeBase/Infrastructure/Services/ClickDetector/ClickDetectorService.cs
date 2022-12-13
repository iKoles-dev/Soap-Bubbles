using CodeBase.Infrastructure.Services.BubblesHolder;
using CodeBase.Infrastructure.Services.ImpactSpawner;
using CodeBase.Infrastructure.Services.UI.DeathCounter;
using CodeBase.SoapBubble;
using UniRx;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.ClickDetector
{
    public class ClickDetectorService
    {
        private const float MaxRayDistance = 10;
        private readonly BubblesHolderService _bubblesHolderService;
        private readonly ImpactSpawnerService _impactSpawnerService;
        private readonly ICounter _deathCounter;
        private readonly Camera _camera;
        private readonly RaycastHit[] _raycastHits = new RaycastHit[20];
        private readonly CompositeDisposable _compositeDisposable = new();

        public ClickDetectorService(BubblesHolderService bubblesHolderService, ImpactSpawnerService impactSpawnerService, ICounter deathCounter)
        {
            _bubblesHolderService = bubblesHolderService;
            _impactSpawnerService = impactSpawnerService;
            _deathCounter = deathCounter;
            _camera = Camera.main;
        }
        public void StartDetecting()
        {
            Observable
                .EveryUpdate()
                .Subscribe(_ => Detect())
                .AddTo(_compositeDisposable);
        }
        public void StopDetecting()
        {
            _compositeDisposable.Clear();
        }

        private void Detect()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                int size = Physics.RaycastNonAlloc(ray, _raycastHits, MaxRayDistance);
                for (int i = 0; i < size; i++)
                {
                    RaycastHit hit = _raycastHits[i];
                    if (hit.collider.TryGetComponent(out Bubble bubble))
                    {
                        _bubblesHolderService.Remove(bubble.ComponentsHolder);
                        _impactSpawnerService.Spawn(bubble.ComponentsHolder.Transform.position);
                        _deathCounter.Increment();
                    }
                }
            }
        }
    }
}