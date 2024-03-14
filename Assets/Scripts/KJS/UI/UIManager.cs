using System;
using System.Collections.Generic;
using UnityEngine;
public class UIManager
{

    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    private List<UIPopup> popups = new List<UIPopup>();

    public UIPopup ShowPopup(string popupname)
    {
        var obj = Resources.Load($"Popups/{popupname}", typeof(GameObject)) as GameObject;
        if (!obj)
        {
            Debug.LogWarning("Failed to ShowPopup({0})");
            return null;
        }
        return ShowPopupWithPrefab(obj, popupname);
    }

    public T ShowPopup<T>() where T : UIPopup
    {
        return ShowPopup(typeof(T).Name) as T;
    }

    private UIPopup ShowPopupWithPrefab(GameObject prefab, string popupName)
    {
        var obj = GameObject.Instantiate(prefab);
        return ShowPopup(obj, popupName);
    }


    public UIPopup ShowPopup(GameObject obj, string popupname)
    {
        var popup = obj.GetComponent<UIPopup>();
        popups.Insert(0, popup);

        obj.SetActive(true);
        return popup;
    }

}