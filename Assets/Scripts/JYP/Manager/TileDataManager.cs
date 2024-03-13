using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDataManager
{
    public int index;
    public string type;
    public string name;

    public TileDataManager(int index, string type, string name) 
    {
        this.index = index;
        this.type = type;
        this.name = name;
    }
}
