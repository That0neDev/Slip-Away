using DG.Tweening;
using GameTiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Spike : ControlTileBase, ITriggerable, IAnimatable
{
    Sequence sequence;
    public void Animate()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DORotate(new(0, 0, 180), 1).SetEase(Ease.Linear));
        sequence.SetLoops(-1);
    }

    public void Kill()
    {
        sequence?.Kill();
    }

    public Vector2? Trigger()
    {
        level.OnDeath();
        return null;
    }
}
