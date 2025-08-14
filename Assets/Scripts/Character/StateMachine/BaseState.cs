public abstract class BaseState : IState
{
    public abstract void Enter();

    public abstract void Execute();
    public abstract void Exit();
}
