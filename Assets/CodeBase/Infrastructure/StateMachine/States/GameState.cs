using CodeBase.Infrastructure.Services.BubbleSpawner;
using CodeBase.Infrastructure.Services.ClickDetector;
using CodeBase.Infrastructure.Services.GameSpeedMultiplier;
using CodeBase.Infrastructure.Services.UI.DeathCounter;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameState : State
    {
        private BubbleSpawnerService _bubbleSpawnerService;
        private GameGameSpeedMultiplierService _gameGameSpeedMultiplierService;
        private ClickDetectorService _clickDetectorService;
        private DeathCounterService _deathCounterService;

        public GameState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(BubbleSpawnerService bubbleSpawnerService, GameGameSpeedMultiplierService gameGameSpeedMultiplierService,
            ClickDetectorService clickDetectorService, DeathCounterService deathCounterService)
        {
            _deathCounterService = deathCounterService;
            _clickDetectorService = clickDetectorService;
            _gameGameSpeedMultiplierService = gameGameSpeedMultiplierService;
            _bubbleSpawnerService = bubbleSpawnerService;
        }
        public override void Enter()
        {
            _bubbleSpawnerService.StartSpawn();
            _gameGameSpeedMultiplierService.Start();
            _clickDetectorService.StartDetecting();
            _deathCounterService.Show();
        }

        public override void Exit()
        {
            _bubbleSpawnerService.StopSpawn();
            _gameGameSpeedMultiplierService.Stop();
            _clickDetectorService.StopDetecting();
            _deathCounterService.Hide();
        }
    }
}