public class StateMachine
{
    private IState previousState;
    private IState currentState;
    
    public IState PreviousState => previousState;
    public IState CurrentState => currentState;

    public void ChangeState(IState newState)
    {
        previousState = currentState;
        previousState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Execute()
    {
        currentState?.Execute();
    }
}
