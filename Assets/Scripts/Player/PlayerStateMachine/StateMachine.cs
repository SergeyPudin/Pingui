using UnityEngine;
public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;

    private void Start()
    {
        if (_firstState != null)
            ChangeState(_firstState);
    }

    public void ChangeState(State newState)
    {
        if (_currentState != null)
            _currentState.enabled = false;

        _currentState = newState;

        _currentState.SetStateaMachine(this);
        _currentState.enabled = true;
    }
}