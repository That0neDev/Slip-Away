using GameTiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Spawner : ControlTileBase, ITriggerable
{
    public Vector2? Trigger()
    {
        return Vector2.zero;
    }
}
