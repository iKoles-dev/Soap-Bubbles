using CodeBase.Infrastructure.Services.BubbleSpawner;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameState : State
    {
        private BubbleSpawnerService _bubbleSpawnerService;

        public GameState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(BubbleSpawnerService bubbleSpawnerService)
        {
            _bubbleSpawnerService = bubbleSpawnerService;
        }
        public override void Enter()
        {
            _bubbleSpawnerService.StartSpawn();
        }

        public override void Exit()
        {
            _bubbleSpawnerService.StopSpawn();
        }
    }
}