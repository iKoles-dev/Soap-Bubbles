using CodeBase.Infrastructure.Services.BubbleSpawner;
using CodeBase.Infrastructure.Services.ClickDetector;
using CodeBase.Infrastructure.Services.GameSpeedMultiplier;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameState : State
    {
        private BubbleSpawnerService _bubbleSpawnerService;
        private GameGameSpeedMultiplierService _gameGameSpeedMultiplierService;
        private ClickDetectorService _clickDetectorService;

        public GameState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(BubbleSpawnerService bubbleSpawnerService, GameGameSpeedMultiplierService gameGameSpeedMultiplierService,
            ClickDetectorService clickDetectorService)
        {
            _clickDetectorService = clickDetectorService;
            _gameGameSpeedMultiplierService = gameGameSpeedMultiplierService;
            _bubbleSpawnerService = bubbleSpawnerService;
        }
        public override void Enter()
        {
            _bubbleSpawnerService.StartSpawn();
            _gameGameSpeedMultiplierService.Start();
            _clickDetectorService.StartDetecting();
        }

        public override void Exit()
        {
            _bubbleSpawnerService.StopSpawn();
            _gameGameSpeedMultiplierService.Stop();
            _clickDetectorService.StopDetecting();
        }
    }
}