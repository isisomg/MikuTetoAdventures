using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TetoMovement : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    // Initialization of components
    private Rigidbody2D tetoRigidBody;
    private BoxCollider2D tetoBoxCollider;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    // Teto checks and variables
    private TetoVariables tetoVariables;

    // Movement variables
    private float tetoInputHorizontal;
    private float tetoHorizontalSpeed = 8f;
    private float tetoJumpForce = 8f;

    void Start()
    {
        // Get the components
        tetoRigidBody = GetComponent<Rigidbody2D>();
        tetoBoxCollider = GetComponent<BoxCollider2D>();
        tetoVariables = GetComponent<TetoVariables>();

        // Set Teto to be alive at the start of the level
        tetoVariables.isAlive = true;
        tetoVariables.winCondition = false;
    }

    void Update()
    {
        tetoInputHorizontal = 0f;

        if (!tetoVariables.isAlive) return; // If teto is dead she wont move

        // Teto Horizontal Movement
        if (Keyboard.current != null)
        {
            if (Keyboard.current.leftArrowKey.isPressed)
                tetoInputHorizontal = -1f;
            else if (Keyboard.current.rightArrowKey.isPressed)
                tetoInputHorizontal = 1f;
        }

        // Teto Jumping
        if (Keyboard.current.upArrowKey.wasPressedThisFrame &&
            isGrounded())
        {
            tetoRigidBody.linearVelocity =
                new Vector2(
                    tetoRigidBody.linearVelocity.x,
                    tetoJumpForce
                );
        }

        _animator.SetFloat("Horizontal", tetoInputHorizontal);
        _animator.SetFloat("VerticalSpeed", tetoRigidBody.linearVelocity.y);
        _animator.SetBool("isGrounded", isGrounded());
    }

    void FixedUpdate()
    {
        tetoRigidBody.linearVelocity =
            new Vector2(tetoInputHorizontal * tetoHorizontalSpeed,
                        tetoRigidBody.linearVelocity.y);
    }

    // GroundCheck
    // Tutorial used: https://www.youtube.com/watch?v=P_6W-36QfLA
    public bool isGrounded()    // Check to see if teto is coliding with the ground, used to limit jumps and whatnot.
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