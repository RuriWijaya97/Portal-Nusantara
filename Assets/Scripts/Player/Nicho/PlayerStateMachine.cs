using UnityEngine;

public class PlayerStateMachine
{
    // state saat ini
    public PlayerState currentState{get; private set;}

    // inisialisasi statenya
    public void Initialize(PlayerState startingState)
    {
        currentState = startingState;
        startingState.Enter();
    }

    // buat ngubah statenya
    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        newState.Enter();
    }

    // buat ngejalanin logic nya
    public void Update()
    {
        currentState.LogicUpdate();
    }
}
