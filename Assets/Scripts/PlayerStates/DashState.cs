using UnityEngine;

class DashState : PlayerState {
  PlayerState previousState;
  Vector3 targetDirection;
  Vector3 currentDirection;
  float speed;
  float timer;

  public DashState(PlayerState previousState, PlayerController player, StateMachine stateMachine, float speed) :
  base(player, stateMachine) {
    this.previousState = previousState;
    this.speed = speed;
    targetDirection = player.GetDirection();
  }

  public override void Enter() {
    timer = player.dashDuration;
  }

  public override void LogicUpdate() {
    currentDirection = Vector3.Lerp(currentDirection, targetDirection, player.smoothness);
    player.Move(speed, currentDirection, player.dashAcceleration);
    timer -= Time.deltaTime;

    if (timer <= 0f) {
      targetDirection = Vector3.zero;
      stateMachine.Set(previousState);
    }
  }
}