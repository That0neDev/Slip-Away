using GameTiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class FinishLine : ControlTileBase, ITriggerable
{
    public Vector2? Trigger()
    {
        level.OnWin();
        return null;
    }
}
