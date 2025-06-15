using UnityEngine;

class IdleState : PlayerState {
  public IdleState(PlayerController player, StateMachine stateMachine) : base(player, stateMachine) { }

  public override void HandleInput() {
    if (player.IsMoving()) {
      var next = new WalkState(player, stateMachine);
      stateMachine.Set(next);
    }
  }
}