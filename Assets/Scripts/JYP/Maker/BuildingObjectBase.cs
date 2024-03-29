using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum Category
{
    Walls,
    Tiles,
    Obstacles,
    Delete
}

[CreateAssetMenu(fileName = "Buildable", menuName = "BuildingObjects/Create Buildable")]
public class BuildingObjectBase : ScriptableObject
{
    [SerializeField] int index;
    [SerializeField] Category category;
    [SerializeField] TileBase tileBase;

    public int Index
    {
        get
        {
            return index;
        }
    }

    public TileBase TileBase
    {
        get
        {
            return tileBase;
        }
    }

    public Category Category
    {
        get
        {
            return category;
        }
    }
}