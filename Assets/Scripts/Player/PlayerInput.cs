using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions actions;
    PlayerInputActions.InGameActions inGame;

    public static Vector2 MoveInput { get; private set; }
    public static Vector2 CameraMoveInput { get; private set; }

    public static Action moved;
    public static Action cameraMoved;

    private void Awake()
    {
        actions = new PlayerInputActions();
        inGame = actions.InGame;

        actions.Enable();

        inGame.Move.performed += ctx =>
        {
            MoveInput = ctx.ReadValue<Vector2>();
            moved?.Invoke();
        };

        inGame.CameraMoveX.performed += ctx =>
        {
            CameraMoveInput = new Vector2(ctx.ReadValue<float>(), CameraMoveInput.y);
            cameraMoved?.Invoke();
        };

        inGame.CameraMoveY.performed += ctx =>
        {
            CameraMoveInput = new Vector2(CameraMoveInput.x, ctx.ReadValue<float>());
            cameraMoved?.Invoke();
        };
    }
}
