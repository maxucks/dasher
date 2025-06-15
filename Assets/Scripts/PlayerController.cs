using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Movement")]
    [SerializeField] public float speed = 12f;
    [SerializeField] public float stopDuration = 0.25f;
    [SerializeField] public float runAcceleration = 1.5f;
    [SerializeField] public float smoothness = .03f;

    [Header("Dash")]
    [SerializeField] public float dashAcceleration = 2f;
    [SerializeField] public float dashDuration = 0.25f;

    private CharacterController controller;
    private StateMachine stateMachine;

    private Vector3 inputDirection;
    private Vector3 currentDirection;
    private Vector3 lastDirection;

    public Vector3 GetDirection() => inputDirection;
    public Vector3 GetLastDirection() => lastDirection;

    public bool IsMoving() => Input.GetKey(GameSettings.moveUpKey) ||
      Input.GetKey(GameSettings.moveDownKey) ||
      Input.GetKey(GameSettings.moveLeftKey) ||
      Input.GetKey(GameSettings.moveRightKey);

    public bool IsRunning() => Input.GetKey(GameSettings.runKey);

    public bool IsDashActivated() => Input.GetKeyDown(GameSettings.dashKey);

    void Start() {
        controller = GetComponent<CharacterController>();
        stateMachine = new StateMachine();

        var idleState = new IdleState(this, stateMachine);
        stateMachine.Init(idleState);
    }

    void Update() {
        CollectInput();

        stateMachine.currentState.HandleInput();
        stateMachine.currentState.LogicUpdate();
    }

    void FixedUpdate() {
        stateMachine.currentState.PhysicsUpdate();
    }

    void CollectInput() {
        var horizontalMovement = Input.GetAxisRaw("Horizontal");
        var verticalMovement = Input.GetAxisRaw("Vertical");

        inputDirection.x = horizontalMovement;
        inputDirection.z = verticalMovement;
        inputDirection.Normalize();
        inputDirection = inputDirection.ToIso();

        currentDirection = Vector3.Lerp(currentDirection, inputDirection, smoothness);

        if (inputDirection != Vector3.zero) {
            lastDirection = inputDirection;
        }
    }

    public void Move(float speed) {
        var destination = currentDirection * speed * Time.deltaTime;
        controller.Move(destination);
    }

    public void Move(float speed, Vector3 direction) {
        var destination = direction * speed * Time.deltaTime;
        controller.Move(destination);
    }

    public void Move(float speed, Vector3 direction, float acceleration) {
        var destination = direction * speed * acceleration * Time.deltaTime;
        controller.Move(destination);
    }
}
