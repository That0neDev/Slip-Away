using DG.Tweening;
using GameTiles;
using UnityEngine;

[System.Serializable]
public class MovementHandler
{
    [SerializeField] Transform transformToMove;
    [SerializeField] float speed;
    [SerializeField] Ease ease;

    [SerializeField] ContactFilter2D solidColliders;
    [SerializeField] ContactFilter2D triggerColliders;
    [SerializeField] ContactFilter2D fullColliders;

    private Vector2 oldDirection;
    private Tween moveTween;

    private Vector2? GetChainDirection(out bool allowInput)
    {
        Collider2D hit = Physics2D.OverlapPoint(transformToMove.position, triggerColliders.layerMask);
        
        allowInput = true;
        if (hit == null)
            return null;

        allowInput = false;
        Vector2? newDirection = hit.GetComponentInParent<ITriggerable>().Trigger();

        if (newDirection == null)
            return null;

        if (newDirection == Vector2.zero)
            return oldDirection;

        return newDirection;
    }

    private Vector2 GetTarget(Vector2 direction)
    {

        RaycastHit2D[] results = new RaycastHit2D[1];

        Vector2 pos = transformToMove.position;
        Physics2D.Raycast(pos, direction, fullColliders, results);

        if (results[0].collider.isTrigger)
            return results[0].transform.position;

        ControlTileBase tile = results[0].collider.gameObject.GetComponent<ControlTileBase>();
        return tile.GetStopPos(direction);
    }

    private void MoveCompleted()
    {
        Vector2? chainVector = GetChainDirection(out bool allowInput);

        if (transformToMove.TryGetComponent(out Player p) == false)
            return;

        if (chainVector.HasValue)
            Move((Vector2)chainVector);

        return;
    }

    public void Move(Vector2 direction)
    {
        if (moveTween != null)
            DOTween.Kill(transformToMove);

        oldDirection = direction;
        Vector2 target = GetTarget(direction);
        float timeToMove = (target - (Vector2)transformToMove.position).magnitude / speed;
        moveTween = transformToMove.DOMove(target, timeToMove).SetEase(ease).OnComplete(MoveCompleted);
    }
}
