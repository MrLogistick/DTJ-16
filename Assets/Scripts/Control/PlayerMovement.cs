using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ground Movement")]
    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;
    float moveSpeed;
    [SerializeField] float groundMultiplier;
    [SerializeField] float drag;
    bool isRunning;
    Vector2 movement;
    Vector3 moveDir;

    [Header("Air Movement")]
    [SerializeField] float jumpPower;

    [SerializeField] float coyoteTime;
    float coyoteElapsed;
    [SerializeField] float jumpBuffer;
    float bufferElapsed;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    [Space]
    [SerializeField] Transform orientation;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update() {
        moveSpeed = isRunning ? runSpeed : walkSpeed;
        rb.linearDamping = IsGrounded() ? drag : 0;

        if (IsGrounded()) {
            coyoteElapsed = coyoteTime;
        } else {
            coyoteElapsed -= Time.deltaTime;
        }
    }

    void FixedUpdate() {
        moveDir = orientation.forward * movement.y + orientation.right * movement.x;

        if (IsGrounded()) {
            rb.AddForce(moveDir * moveSpeed * groundMultiplier, ForceMode.Force);
        }

        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (flatVel.magnitude > moveSpeed) {
            Vector3 newVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(newVel.x, rb.linearVelocity.y, newVel.z);
        }
    }

    public void MoveInput(InputAction.CallbackContext context) {
        movement = context.ReadValue<Vector2>().normalized;
    }

    public void SprintInput(InputAction.CallbackContext context) {
        isRunning = context.performed ? true : false;
    }

    public void JumpInput(InputAction.CallbackContext context) {
        float yVel = rb.linearVelocity.y;
        if (context.performed && coyoteElapsed > 0) {
            yVel = jumpPower;
        }
        if (context.canceled & yVel > 0f) {
            yVel *= 0.6f;
            coyoteElapsed = 0f;
        }
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, yVel, rb.linearVelocity.z);
    }

    bool IsGrounded() {
        return Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Killer")) {
            if (other.gameObject.name == "Falling Log") {
                if (other.transform.parent.GetComponent<FallingLogTrap>().isFalling) {
                    GameInterface.instance.Die();
                }
            }
        }
    }
}