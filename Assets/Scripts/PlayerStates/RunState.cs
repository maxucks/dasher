class RunState : PlayerState {
  float speed;

  public RunState(PlayerController player, StateMachine stateMachine) : base(player, stateMachine) {
    speed = player.speed * player.runAcceleration;
  }

  public override void HandleInput() {
    if (player.IsDashActivated()) {
      var next = new DashState(this, player, stateMachine, speed);
      stateMachine.Set(next);
    }

    if (!player.IsRunning()) {
      var next = new WalkState(player, stateMachine);
      stateMachine.Set(next);
    }
  }

  public override void LogicUpdate() {
    player.Move(speed);
  }
}