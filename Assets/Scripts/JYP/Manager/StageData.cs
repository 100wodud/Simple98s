using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageData
{
    public int x { get; set; }
    public int y { get; set; }
    public int tile { get; set; }

    public StageData(int _x, int _y, int _tile)
    {
        x = _x;
        y = _y;
        tile = _tile;
    }
}
