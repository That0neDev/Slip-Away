using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GameTiles
{

    internal class ControlTileBase : MonoBehaviour
    {
        protected Level level;

        public Vector2 GetStopPos(Vector2 direction)
        {
            Vector2 stopPos = (Vector2)transform.position + (direction * -1);
            stopPos = new(Mathf.Round(stopPos.x), Mathf.Round(stopPos.y));
            return stopPos;
        }

        private void Awake()
        {
            level = FindFirstObjectByType<Level>();

            if (TryGetComponent(out IAnimatable animatable))
                animatable.Animate();
        }

        private void OnDestroy()
        {
            if (TryGetComponent(out IAnimatable animatable))
                animatable.Kill();
        }
    }
    public interface ITriggerable
    {
        public Vector2? Trigger();
    }
    public interface IAnimatable
    {
        public void Animate();

        public void Kill();
    }
}
