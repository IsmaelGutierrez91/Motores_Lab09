using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static event Action<InputAction.CallbackContext> OnPlayerMovementX;
    public static event Action<InputAction.CallbackContext> OnPlayerMovementY;
    public static event Action<InputAction.CallbackContext> OnPlayerJump;
    public static event Action<InputAction.CallbackContext> SetPreviousColor;
    public static event Action<InputAction.CallbackContext> SetNextColor;

    public void OnHorizontalMovement(InputAction.CallbackContext context)
    {
        OnPlayerMovementX?.Invoke(context);
    }
    public void OnVerticalMovement(InputAction.CallbackContext context)
    {
        OnPlayerMovementY?.Invoke(context);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        OnPlayerJump?.Invoke(context);
    }
    public void PrevColor(InputAction.CallbackContext context)
    {
        SetPreviousColor?.Invoke(context);
    }
    public void NextColor(InputAction.CallbackContext context)
    {
        SetNextColor?.Invoke(context);
    }
}
