using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTiles
{
    internal class Orb : ControlTileBase, ITriggerable , IAnimatable
    {
        [SerializeField] int orbWhenHit;
        Sequence s;

        public void Animate()
        {
            float yTop = transform.localPosition.y + 0.3f;
            float yBot = transform.localPosition.y;

            s = DOTween.Sequence();
            s.Append(transform.DOLocalMoveY(yTop, 3)).SetEase(Ease.InOutQuad);
            s.AppendInterval(0.5f);
            s.Append(transform.DOLocalMoveY(yBot, 3).SetEase(Ease.InOutQuad));
            s.AppendInterval(2f);
            s.SetLoops(-1);
        }

        public void Kill()
        {
            s.Kill();
        }

        public Vector2? Trigger()
        {
            Destroy(gameObject);
            return Vector2.zero;
        }
    }
}
