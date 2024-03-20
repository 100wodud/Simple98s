using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMapList : MonoBehaviour
{
    private void Awake()
    {
        DataManager.Instance.Initialize();
    }

    private void Start()
    {
        CustomMapManager.Instance.CustomStageList();
    }
}
