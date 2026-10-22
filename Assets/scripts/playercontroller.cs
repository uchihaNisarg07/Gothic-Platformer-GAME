
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    public float jumpImpulse = 5f;
    [SerializeField] private bool _isMoving;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator animator;
    private TouchingDirections touchingDirections;

    public bool _isFacingRight = true;

    public bool IsFacingRight
    {
        get { return _isFacingRight; }
        private set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }

            _isFacingRight = value;
        }
    }

    public bool IsMoving
    {
        get { return _isMoving; }
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationString.isMoving, value);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    private void Update()
    {
        IsMoving = moveInput.x != 0 && !touchingDirections.IsOnWall;
    }

    private void FixedUpdate()
    {
        float horizontalSpeed = moveInput.x * walkSpeed;

        // Stop horizontal movement when pushing into a wall
        if (touchingDirections.IsOnWall)
        {
            if ((IsFacingRight && moveInput.x > 0) ||
                (!IsFacingRight && moveInput.x < 0))
            {
                horizontalSpeed = 0;
            }
        }

        rb.linearVelocity = new Vector2(
            horizontalSpeed,
            rb.linearVelocity.y
        );

        animator.SetFloat(
            AnimationString.yVelocity,
            rb.linearVelocity.y
        );
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 input)
    {
        if (input.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if (input.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && touchingDirections.IsGrounded)
        {
            animator.SetTrigger(AnimationString.jump);

            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpImpulse
            );
        }
    }
}
