using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private Animator animator;
    private Rigidbody2D rb;

    private Vector2 moveInput;
    private int lastDirection = 0;
    public Vector2 minBounds = new Vector2(-14f, -5f);
    public Vector2 maxBounds = new Vector2(14f, 5f);
    

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // --- Read input ---
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(horizontal, vertical);

        bool isMoving = moveInput.sqrMagnitude > 0.01f; 

        int newDirection = lastDirection;

        if (isMoving)
        {
            // --- Determine 8-direction facing based on angle ---
            float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;

            if (angle >= -22.5f && angle < 22.5f)
                newDirection = 3; // Right
            else if (angle >= 22.5f && angle < 67.5f)
                newDirection = 7; // Up-Right
            else if (angle >= 67.5f && angle < 112.5f)
                newDirection = 1; // Up
            else if (angle >= 112.5f && angle < 157.5f)
                newDirection = 6; // Up-Left
            else if (angle >= 157.5f || angle < -157.5f)
                newDirection = 2; // Left
            else if (angle >= -157.5f && angle < -112.5f)
                newDirection = 4; // Down-Left
            else if (angle >= -112.5f && angle < -67.5f)
                newDirection = 0; // Down
            else if (angle >= -67.5f && angle < -22.5f)
                newDirection = 5; // Down-Right

            // --- Move player ---
            Vector3 targetPos = rb.position + moveInput.normalized * speed * Time.deltaTime;

            // Clamp inside world bounds
            targetPos.x = Mathf.Clamp(targetPos.x, minBounds.x, maxBounds.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minBounds.y, maxBounds.y);
            rb.MovePosition(targetPos);
            // --- Animate movement ---
            animator.SetInteger("Direction", newDirection);
            animator.SetInteger("State", 1);

            // Save direction only while moving
            lastDirection = newDirection;
        }
        else
        {
            // --- Idle while keeping the last direction ---
            animator.SetInteger("Direction", lastDirection);
            animator.SetInteger("State", 0);
        }
    }
}
