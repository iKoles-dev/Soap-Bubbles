using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameState : State
    {

        public GameState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct()
        {
        }
        public override void Enter()
        {
        }

        public override void Exit()
        {
        }
    }
}