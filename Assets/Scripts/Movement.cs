using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.InputSystem.InputAction;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float horizontalInput;
    public bool holdingJump;
    public float fallMultiplier;
    public float slowFallMultiplier;
    public bool isAirborne = true;
    public bool isOnSide = false;
    public LayerMask boxCastLayerMask;
    public int jumpStage;
    public int maxJumps;
    private float coyoteTime = .3f;
    private float coyoteTimeCounter;



    private void Update()
    {

        RaycastHit2D down = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, boxCastLayerMask);
        isAirborne = down.distance > 0.61;
        if (!isAirborne) { jumpStage = 1; coyoteTimeCounter = coyoteTime; }
        else { coyoteTimeCounter -= Time.deltaTime; }

    }
    void FixedUpdate()
    {
        RaycastHit2D right = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, boxCastLayerMask);
        RaycastHit2D left = Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity, boxCastLayerMask);
        rb.velocity = new Vector2(speed * horizontalInput, rb.velocity.y);
        tbd();
        if (left.distance < 0.52 && left.collider != null && horizontalInput < 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (right.distance < 0.52 && right.collider != null && horizontalInput > 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    public void Move(CallbackContext context)
    {
        horizontalInput = context.ReadValue<float>();
        
    }
    public void Jump(CallbackContext context)
    {
        if (context.started && isAirborne && jumpStage < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, 8);
            isAirborne = true;
            jumpStage++;
            return;
        }
        if (coyoteTimeCounter < 0)
        {
            return;
        }
        if (context.started)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isAirborne = true;
            jumpStage++;
            coyoteTimeCounter = 0f;
        }

    }
    public void Gravity(CallbackContext context) { holdingJump = context.started ? true : context.canceled ? false : holdingJump; }
    public void tbd() { rb.gravityScale = holdingJump ? slowFallMultiplier : fallMultiplier; }
   

}

