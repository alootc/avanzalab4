using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool canDoubleJump;

    [Header("Raycast")]
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float distance;

    private Player player;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }
    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        moveInput = new Vector2(x * speed, rb.velocity.y);

        if (!canDoubleJump) canDoubleJump = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                Jump();
            }
            else
            {
                if (canDoubleJump)
                {
                   Jump();
                   canDoubleJump = false;
                }
            }
        }
        //Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance, whatIsGround);
        return hit.collider != null;

        //canDoubleJump = hit.collider != null;
    }

    public void Color1(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            player.ChangeColor("Red");
        }
    }

    public void Color2(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            player.ChangeColor("Blue");
        }
    }

    public void Color3(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            player.ChangeColor("Yellow");
        }
    }

}
