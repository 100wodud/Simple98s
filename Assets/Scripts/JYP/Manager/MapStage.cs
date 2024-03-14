using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStage
{
    public int x { get; set; }
    public int y { get; set; }
    public int tile { get; set; }

    public MapStage(int _x, int _y, int _tile)
    {
        x = _x;
        y = _y;
        tile = _tile;
    }
}
