using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MikuMovement : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    // Initialization of components
    private Rigidbody2D mikuRigidBody;
    private BoxCollider2D mikuBoxCollider;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    // Miku checks and variables
    private MikuVariables mikuVariables;

    // Movement variables
    private float mikuInputHorizontal;
    private float mikuHorizontalSpeed = 8f;
    private float mikuJumpForce = 8f;

    void Start()
    {
        // Get the components
        mikuRigidBody = GetComponent<Rigidbody2D>();
        mikuBoxCollider = GetComponent<BoxCollider2D>();
        mikuVariables = GetComponent<MikuVariables>();

        // Set Miku to be alive at the start of the level
        mikuVariables.isAlive = true;
        mikuVariables.winCondition = false;
    }

    void Update()
    {
        mikuInputHorizontal = 0f;

        if (!mikuVariables.isAlive) return; // If miku is dead she wont move

        // Miku Horizontal Movement
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed)
                mikuInputHorizontal = -1f;
            else if (Keyboard.current.dKey.isPressed)
                mikuInputHorizontal = 1f;
        }

        // Miku Jumping
        if (Keyboard.current.wKey.wasPressedThisFrame &&
        isGrounded())
        {
            mikuRigidBody.linearVelocity =
                new Vector2(
                    mikuRigidBody.linearVelocity.x,
                    mikuJumpForce
                );
        }

        _animator.SetFloat("Horizontal", mikuInputHorizontal);
        _animator.SetFloat("VerticalSpeed", mikuRigidBody.linearVelocity.y);
        _animator.SetBool("isGrounded", isGrounded());
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. So the walk speed will be consistent across different frame rates and wont be all choppy and weird
    void FixedUpdate()
    {
        mikuRigidBody.linearVelocity =
            new Vector2(mikuInputHorizontal * mikuHorizontalSpeed,
                        mikuRigidBody.linearVelocity.y);
    }

    // GroundCheck
    // Tutorial used: https://www.youtube.com/watch?v=P_6W-36QfLA

    // Draws Lines below Miku to check for the ground, if it hits the ground it returns true and if it doesn't it returns false.
    public bool isGrounded()    // Check to see if miku is coliding with the ground, used to limit jumps and whatnot.
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}