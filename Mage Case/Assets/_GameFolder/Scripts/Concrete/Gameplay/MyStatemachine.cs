namespace MageCase.GamePlay.States
{
    public class MyStatemachine
    {
        public State Currentstate { get; private set; }

        public void InitiliazeState(State initState)
        {
            Currentstate = initState;
            initState.Enter();
        }

        public void ChangeState(State newState)
        {
            Currentstate.Exit();
            Currentstate = newState;
            Currentstate.Enter();
        }
    }
}