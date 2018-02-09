using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    private IState CurrentlyRuningState;

    private IState previousState;

	public void ChangeState(IState newState)
    {
        if(CurrentlyRuningState !=null)
        {
            CurrentlyRuningState.Exit();
        }

        CurrentlyRuningState.Exit();
        previousState = CurrentlyRuningState;

        CurrentlyRuningState = newState;
        CurrentlyRuningState.Enter();
    }

    public void ExecuteStateUpdate()
    {
        IState runninState = CurrentlyRuningState;

        if (runninState != null)
            runninState.Execute();
    }

    public void SwitchToPreviousState()
    {
        CurrentlyRuningState.Exit();
    }
}
