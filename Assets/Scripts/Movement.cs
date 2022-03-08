using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.InputSystem.InputAction;

public class Movement : MonoBehaviour
{
    [SerializeField] BoxCollider2D col;
    //[SerializeField] CircleCollider2D col;
    [SerializeField] Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float horizontalInput;
    public bool holdingJump;
    public float fallMultiplier;
    public float slowFallMultiplier;
    public bool isAirborne = true;
    public LayerMask boxCastLayerMask;

    void Start()
    {
    } 

    private void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, col.size, transform.rotation.eulerAngles.z, Vector2.down, Mathf.Infinity, boxCastLayerMask);
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, boxCastLayerMask);
        isAirborne = hit.distance > 0.51;
        tbd();

    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * horizontalInput, rb.velocity.y);
        Debug.Log(holdingJump);
    }

    public void Move(CallbackContext context)
    {
        horizontalInput = context.ReadValue<float>();
        
    }
    public void Jump(CallbackContext context)
    {
        if (!context.performed || isAirborne)
        {
            return;
        }


        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        isAirborne = true;
    }
    public void Gravity(CallbackContext context)
    {
        if (context.started)
        {
            holdingJump = true;
        }
        else if (context.canceled)
        {
            holdingJump = false;
        }
    }
    public void tbd()
    {
        if (rb.velocity.y < 0 && !holdingJump)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && holdingJump)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (slowFallMultiplier - 1) * Time.deltaTime;
        }
    }
    

}
