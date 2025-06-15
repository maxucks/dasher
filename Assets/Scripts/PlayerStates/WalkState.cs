using UnityEngine;

class WalkState : PlayerState {
  public WalkState(PlayerController player, StateMachine stateMachine) : base(player, stateMachine) { }

  public override void HandleInput() {
    if (!player.IsMoving()) {
      var next = new StoppingState(player, stateMachine);
      stateMachine.Set(next);
    }

    if (player.IsDashActivated()) {
      var next = new DashState(this, player, stateMachine, player.speed);
      stateMachine.Set(next);
    }

    if (player.IsRunning()) {
      var next = new RunState(player, stateMachine);
      stateMachine.Set(next);
    }
  }

  public override void LogicUpdate() {
    player.Move(player.speed);
  }
}