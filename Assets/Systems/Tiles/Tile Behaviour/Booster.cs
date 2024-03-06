using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTiles
{
    internal class Booster : ControlTileBase, ITriggerable
    {
        [SerializeField] Vector2 boostDirection;

        public Vector2? Trigger()
        {
            Destroy(gameObject);
            return boostDirection;
        }
    }
}
