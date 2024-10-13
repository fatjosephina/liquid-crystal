using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static Vector2 MoveInput { get; private set; }

    public static Action moved;

    private void OnMove(InputValue value)
    {
        MoveInput = value.Get<Vector2>();
        moved?.Invoke();
    }

}
