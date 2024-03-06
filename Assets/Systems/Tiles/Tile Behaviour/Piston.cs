using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTiles
{
    internal class Piston : ControlTileBase, ITriggerable
    {
        public Vector2? Trigger()
        {
            return (Vector2)transform.GetChild(0).localPosition;
        }
    }
}
