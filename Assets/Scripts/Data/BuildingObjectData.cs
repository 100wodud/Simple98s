using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingObjectData : Singleton<BuildingObjectData>
{
    private Dictionary<int, BuildingObjectBase> buildingObjectDictionary = new Dictionary<int, BuildingObjectBase>();
    public BuildingObjectBase[] ObjData;

    private void Awake()
    {
        foreach(var obj in ObjData)
        {
            AddBuildingObject(obj); 
        }
    }

    public void AddBuildingObject(BuildingObjectBase buildingObject)
    {
        // 이미 해당 index의 빌딩 객체가 존재하는지 확인 후 추가
        if (!buildingObjectDictionary.ContainsKey(buildingObject.Index))
        {
            buildingObjectDictionary.Add(buildingObject.Index, buildingObject);
        }
    }

    public BuildingObjectBase GetBuildingObject(int index)
    {
        if (buildingObjectDictionary.ContainsKey(index))
        {
            return buildingObjectDictionary[index];
        }
        else
        {
            return null;
        }
    }
}
