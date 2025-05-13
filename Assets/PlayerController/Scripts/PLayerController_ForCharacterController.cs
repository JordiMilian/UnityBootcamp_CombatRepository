using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PLayerController_ForCharacterController : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    [Header("Input actions")]
    [SerializeField] InputActionReference moveAction;
    [SerializeField] InputActionReference jumpAction;
    [SerializeField] InputActionReference attackAction;

    //Orientation 
    public enum OrientationMode
    {
        FollowMovement,FollowTarget, FollowCameraForward
    }
    [SerializeField] OrientationMode orientationMode;
    [SerializeField] Transform orientationTarget;

    //Private references
    CharacterController characterController;
    Camera mainCamera;
    Animator JoeAnimator;

    //Private variables
    Vector2 rawInput;
    bool mustJump;
    float verticalVelocity;
    const float gravity = -9.81f;




    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        JoeAnimator = GetComponentInChildren<Animator>();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
        attackAction.action.Enable();
        moveAction.action.performed += OnMovementInputChange; //cuando la accion canvia de valor
        moveAction.action.canceled += OnMovementInputChange; //cuando la accion pasa a valor 0
        jumpAction.action.performed += OnJumpImput;
        attackAction.action.performed += OnAttackInput;
    }

    private void Update()
    {
        Vector3 worldInput = new Vector3(rawInput.x, 0, rawInput.y);
        Vector3 rotatedInput = RotateInputOnCamera(transform.position, mainCamera.transform, worldInput);

        if (characterController.isGrounded) { verticalVelocity = -4f; } //minVerticalSpeed to about floating in rampas pa abajo
        else { verticalVelocity += gravity * Time.deltaTime; }

        Vector3 groundVelocity = new Vector3(rotatedInput.x, 0, rotatedInput.z) * speed;
        characterController.Move((groundVelocity + (Vector3.up * verticalVelocity)) * Time.deltaTime);

        if (mustJump)
        {
            mustJump = false;
            if (characterController.isGrounded) { characterController.Move(Vector3.up * jumpSpeed); }
        }

        //ANIMATOR VARIABLES
        UpdateAnimatorFloats();

        //ORIENTATION
        UpdateOrientation();

        //
        void UpdateAnimatorFloats()
        {
            Vector3 localInput = transform.InverseTransformDirection(rotatedInput);
            JoeAnimator.SetFloat("Forward", localInput.z);
            JoeAnimator.SetFloat("Horizontal", localInput.x);
        }
        void UpdateOrientation()
        {
            Vector3 desiredOrientation;
            switch (orientationMode)
            {
                case OrientationMode.FollowMovement:
                    desiredOrientation = rotatedInput.normalized; break;
                case OrientationMode.FollowTarget:
                    desiredOrientation = (orientationTarget.position - transform.position).normalized; break;
                case OrientationMode.FollowCameraForward:
                    desiredOrientation = mainCamera.transform.forward; break;
                default: desiredOrientation = Vector3.forward; break;
        }
        desiredOrientation.y = 0;

        float AngleToDesiredOrientation = Vector3.SignedAngle(transform.forward, desiredOrientation, Vector3.up);
        Quaternion rotationToDesiredOrientation = Quaternion.AngleAxis(AngleToDesiredOrientation, Vector3.up);

        transform.rotation = rotationToDesiredOrientation * transform.rotation;
        }
}

    static Vector3 RotateInputOnCamera(Vector3 characterPos, Transform cameraPos, Vector3 input)
    {
        Vector3 flatCameraForward = UsefullMethods.angle2Vector(cameraPos.eulerAngles.y * Mathf.Deg2Rad);

        //Use this commented line in case you want to use the direction to the player as the forwards
        //Vector3 flatDirectionToCharacter = (characterPos - new Vector3(cameraPos.position.x, characterPos.y, cameraPos.position.z)).normalized;

        return UsefullMethods.RotateVectorByDirection(input, flatCameraForward);
    }
    void OnJumpImput(InputAction.CallbackContext context)
    {
        mustJump = true;
    }
    private void OnMovementInputChange(InputAction.CallbackContext context)
    {
        rawInput = context.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
        attackAction.action.Disable();
        moveAction.action.performed -= OnMovementInputChange; //cuando la accion canvia de valor
        moveAction.action.canceled -= OnMovementInputChange; //cuando la accion pasa a valor 0
        jumpAction.action.performed -= OnJumpImput;
        attackAction.action.performed -= OnAttackInput;
    }

    private void OnAttackInput(InputAction.CallbackContext context)
    {
        JoeAnimator.SetTrigger("Attack");
    }
}
