using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static event Action<InputAction.CallbackContext> OnPlayerMovementX;
    public static event Action<InputAction.CallbackContext> OnPlayerMovementY;

    public void OnHorizontalMovement(InputAction.CallbackContext context)
    {
        OnPlayerMovementX?.Invoke(context);
    }
    public void OnVerticalMovement(InputAction.CallbackContext context)
    {
        OnPlayerMovementY?.Invoke(context);
    }
}
