using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D _componentRigidbody2D;
    float xDirection;
    float yDirection;
    [Header("Player customization")]
    [SerializeField] float playerSpeed;
    private void Awake()
    {
        _componentRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _componentRigidbody2D.velocity = new Vector2(xDirection * playerSpeed, yDirection * playerSpeed);
    }
    public void OnMovementX(InputAction.CallbackContext context)
    {
        xDirection = context.ReadValue<float>();
    }
    public void OnMovementY(InputAction.CallbackContext context)
    {
        yDirection = context.ReadValue<float>();
    }
    private void OnEnable()
    {
        PlayerInput.OnPlayerMovementX += OnMovementX;
        PlayerInput.OnPlayerMovementY += OnMovementY;
    }
    private void OnDisable()
    {
        PlayerInput.OnPlayerMovementX -= OnMovementX;
        PlayerInput.OnPlayerMovementY -= OnMovementY;
    }
}
