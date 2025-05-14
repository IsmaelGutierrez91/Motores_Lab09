using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController3D : MonoBehaviour
{
    Rigidbody _componentRigidbody;
    float xDirection;
    float zDirection;
    bool canJump;

    [Header("Player customization")]
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;

    [Header("RayCast Modifications")]
    [SerializeField] Transform originPoint;
    [SerializeField] float rayCastLength;
    [SerializeField] LayerMask layerMask;
    public Color inCollision = Color.white;
    public Color outCollision = Color.white;

    private void Awake()
    {
        _componentRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _componentRigidbody.velocity = new Vector3(xDirection * playerSpeed, _componentRigidbody.velocity.y, zDirection * playerSpeed);
        RaycastHit hit;
        if (Physics.Raycast(originPoint.position, Vector3.down, out hit, rayCastLength, layerMask))
        {
            Debug.DrawRay(originPoint.position, Vector3.down * hit.distance, inCollision);
            canJump = true;
        }
        else
        {
            Debug.DrawRay(originPoint.position, Vector3.down * rayCastLength, outCollision);
            canJump = false;
        }
    }
    public void OnMovementX(InputAction.CallbackContext context)
    {
        xDirection = context.ReadValue<float>();
    }
    public void OnMovementZ(InputAction.CallbackContext context)
    {
        zDirection = context.ReadValue<float>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        if (canJump == true)
        {
            _componentRigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void OnEnable()
    {
        PlayerInput.OnPlayerMovementX += OnMovementX;
        PlayerInput.OnPlayerMovementY += OnMovementZ;
        PlayerInput.OnPlayerJump += OnJump;
    }
    private void OnDisable()
    {
        PlayerInput.OnPlayerMovementX -= OnMovementX;
        PlayerInput.OnPlayerMovementY -= OnMovementZ;
        PlayerInput.OnPlayerJump -= OnJump;
    }
}
