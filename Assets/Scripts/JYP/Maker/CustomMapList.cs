using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMapList : MonoBehaviour
{
    public RectTransform contents;
    private void Awake()
    {
        DataManager.Instance.Initialize();
        CustomMapManager.Instance.CustomStageList();
    }

    private void Start()
    {
        Invoke("ScrollMove", 0.2f);
    }

    void ScrollMove()
    {
        float y = contents.sizeDelta.y / 2;
        contents.anchoredPosition = new Vector2(900f, -y);
    }
}
