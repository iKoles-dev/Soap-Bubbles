using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameLoadState : State
    {

        public GameLoadState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

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