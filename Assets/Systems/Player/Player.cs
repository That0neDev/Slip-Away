using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] MovementHandler movementHandler;
    [SerializeField] bool inputAllowed;
    public void InputComplete(Vector2 direction)
    {
        if (!inputAllowed)
            return;

        movementHandler.Move(direction);
    }

    public void MovementComplete()
    {
        inputAllowed = true;
    }
}
