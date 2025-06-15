using UnityEngine;

class StoppingState : PlayerState {
  Vector3 direction;
  float timer;

  public StoppingState(PlayerController player, StateMachine stateMachine) : base(player, stateMachine) {
    direction = player.GetLastDirection();
  }

  public override void Enter() {
    timer = player.stopDuration;
  }

  public override void HandleInput() {
    if (player.IsMoving()) {
      var next = new WalkState(player, stateMachine);
      stateMachine.Set(next);
    }
  }

  public override void LogicUpdate() {
    direction = Vector3.Lerp(direction, Vector3.zero, player.smoothness);
    player.Move(player.speed, direction);
    timer -= Time.deltaTime;

    if (timer <= 0f) {
      var next = new IdleState(player, stateMachine);
      stateMachine.Set(next);
    }
  }
}