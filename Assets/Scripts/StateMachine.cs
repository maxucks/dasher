using UnityEngine;

public class StateMachine {
  public PlayerState currentState { get; private set; }

  public void Init(PlayerState state) {
    currentState = state;
    currentState.Enter();
  }

  public void Set(PlayerState state) {
    Debug.Log(state);
    currentState?.Exit();
    currentState = state;
    currentState.Enter();
  }
}