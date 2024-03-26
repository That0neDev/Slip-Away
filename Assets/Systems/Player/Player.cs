using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] MovementHandler movementHandler;
    public void InputComplete(Vector2 direction)
    {
        if (GameUI.OnUI)
            return;

        movementHandler.Move(direction);
    }
}
