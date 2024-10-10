using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class State : MonoBehaviour
{
    [SerializeField] private State _nextState;

    protected StateMachine CurrentStateMachine;

    protected State NextState => _nextState;

    public void SetStateaMachine(StateMachine stateMachine)
    {
          CurrentStateMachine = stateMachine;
    }

    protected void NeedTransit()
    {
        if (CurrentStateMachine != null) 
            CurrentStateMachine.ChangeState(_nextState);
    }
}