using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;

    // Components
    private PlayerController playerController;
    private Animator playerAnimator;

    // References
    private Transform playerTransform;
    private Rigidbody playerRigidBody;

    private Vector2 inputVector = Vector2.zero;

    private Vector3 moveDirection = Vector3.zero;

    //Animator Hashes
    public readonly int MovementXHash = Animator.StringToHash("MovementX");
    public readonly int MovementYHash = Animator.StringToHash("MovementY");
    public readonly int IsJumpingHash = Animator.StringToHash("IsJumping");
    public readonly int IsRunningHash = Animator.StringToHash("IsRunning");


    private void Awake()
    {
        playerTransform = transform;
        playerController = GetComponent<PlayerController>();
        playerAnimator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
    }


    public void OnMovement(InputValue value)
    {
        if (PauseMenu.isPaused) return;
        //Debug.Log(value.Get());

        inputVector = value.Get<Vector2>();

        playerAnimator.SetFloat(MovementXHash, inputVector.x);
        playerAnimator.SetFloat(MovementYHash, inputVector.y);
    }


    public void OnRun(InputValue value)
    {
        if (PauseMenu.isPaused) return;

        //Debug.Log(value.isPressed);
        playerController.isRunning = value.isPressed;
        playerAnimator.SetBool(IsRunningHash, value.isPressed);
    }


    public void OnJump(InputValue value)
    {
        if (playerController.isJumping) return;

        playerController.isJumping = value.isPressed;
        playerAnimator.SetBool(IsJumpingHash, value.isPressed);
        playerRigidBody.AddForce((playerTransform.up + moveDirection) * jumpForce, ForceMode.Impulse);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ground") && !playerController.isJumping)
        {
            return;
        }

        playerController.isJumping = false;
        playerAnimator.SetBool(IsJumpingHash, false);
    }


    // Update is called once per frame
    void Update()
    {
        
        if (PauseMenu.isPaused) return;

        if (playerController.isJumping) return;

        if (!(inputVector.magnitude > 0))
        {
            moveDirection = Vector3.zero;
        }

        moveDirection = playerTransform.forward * inputVector.y + playerTransform.right * inputVector.x;

        float currentSpeed = playerController.isRunning ? runSpeed : walkSpeed;

        Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);

        playerTransform.position += movementDirection;
    }  
}
