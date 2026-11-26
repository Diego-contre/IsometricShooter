
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector3 forwardDirection;
    private Vector3 rightDirection;

    private InputAction moveAction;

    void Awake()
    {
        moveAction = new InputAction("Move", InputActionType.Value);

        // WASD
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        // Flechas
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/rightArrow");

        // Gamepad
        moveAction.AddBinding("<Gamepad>/leftStick");
    }

    void OnEnable() => moveAction.Enable();

    void OnDisable() => moveAction.Disable();

    void Start()
    {
        forwardDirection = Camera.main.transform.forward;
        forwardDirection.y = 0;
        forwardDirection.Normalize();

        rightDirection = Camera.main.transform.right;
        rightDirection.y = 0;
        rightDirection.Normalize();
    }

    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();

        Vector3 direction =
            forwardDirection * input.y +
            rightDirection * input.x;

        if (direction.magnitude > 0.1f)
        {
            transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        }
    }
}
