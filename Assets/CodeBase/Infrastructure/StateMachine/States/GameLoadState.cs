using CodeBase.Infrastructure.ObjectPools;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameLoadState : State
    {
        private BubblePool _bubblePool;

        public GameLoadState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(BubblePool bubblePool)
        {
            _bubblePool = bubblePool;
        }

        public override void Enter()
        {
            _bubblePool.Initialize();
            GameLoopStateMachine.Enter<ResetState>();
        }

        public override void Exit()
        {
        }
        
    }
}