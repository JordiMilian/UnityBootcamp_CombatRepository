using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_ForBall : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    [Header("Input actions")]
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference jump;
    [SerializeField] InputActionReference bomb;
    [Space]
    Rigidbody rb;
    Vector2 rawInput;
    Camera mainCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        move.action.Enable();
        jump.action.Enable();
        bomb.action.Enable();
        move.action.performed += OnMovementInputChange; //cuando la accion canvia de valor
        move.action.canceled += OnMovementInputChange; //cuando la accion pasa a valor 0
        jump.action.performed += OnJumpImput;
    }
    bool mustJump;
    private void FixedUpdate()
    {
        Vector3 localVelocity = new Vector3(rawInput.x, 0, rawInput.y) * speed;
        Vector3 rotatedVector = RotateInputOnCamera(transform.position, mainCamera.transform.position, localVelocity);
        rb.linearVelocity = new Vector3(rotatedVector.x, rb.linearVelocity.y, rotatedVector.z);

        if(mustJump)
        {
            mustJump = false;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpSpeed, rb.linearVelocity.z);
        }
        
    }
    public static Vector3 RotateInputOnCamera(Vector3 characterPos, Vector3 cameraPos, Vector3 input)
    {
        Vector3 flatDirectionToCamera = (new Vector3(cameraPos.x, characterPos.y, cameraPos.z) - characterPos).normalized;
        return (-flatDirectionToCamera * input.z) + (new Vector3(-flatDirectionToCamera.z, 0, flatDirectionToCamera.x) * input.x); //rotate the input by the flatDirection
    }
    void OnJumpImput(InputAction.CallbackContext context)
    {
        mustJump = true;
    }
    private void OnMovementInputChange(InputAction.CallbackContext context)
    {
        rawInput = context.ReadValue<Vector2>();
        Debug.Log($"RawInput: {rawInput}");
    }

    private void OnDisable()
    {
        move.action.Disable();
        jump.action.Disable();
        bomb.action.Disable();
    }
    
}
