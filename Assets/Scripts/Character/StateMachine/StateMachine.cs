public class StateMachine
{
    private IState currentState;

    protected void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Execute()
    {
        currentState?.Execute();
    }
}
