using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MovementInput : MonoBehaviour
{
    [SerializeField] UnityEvent<Vector2> inputCompleted;

    [SerializeField] PlayerInput playerInput;
    [SerializeField] InputAction positionAction;

    protected Transform transformToMove;
    private Vector2 tapPos1;
    private Vector2 tapPos2;

    private void SetTap1(Vector2 input)
    {
        tapPos1 = input;
    }

    private void SetTap2(Vector2 input) 
    {
        print(tapPos1);
        print(tapPos2);
        tapPos2 = input;
        inputCompleted.Invoke(GetInput());
    }

    protected Vector2 GetInput()
    {
        float absX = Mathf.Abs(tapPos2.x - tapPos1.x);
        float absY = Mathf.Abs(tapPos2.y - tapPos1.y);
        int vX = absX > absY ? (int)Math.Round(tapPos2.x - tapPos1.x, 0, MidpointRounding.AwayFromZero) : 0;
        int vY = absX < absY ? (int)Math.Round(tapPos2.y - tapPos1.y, 0, MidpointRounding.AwayFromZero) : 0;
        return new(Math.Sign(vX), Math.Sign(vY));
    }

    public void OnMouseClick(InputAction.CallbackContext ctx)
    {
        if (!positionAction.enabled)
            positionAction.Enable();

        if (ctx.phase == InputActionPhase.Started)
            SetTap1(positionAction.ReadValue<Vector2>());

        if (ctx.phase == InputActionPhase.Canceled)
            SetTap2(positionAction.ReadValue<Vector2>());
    }
}
