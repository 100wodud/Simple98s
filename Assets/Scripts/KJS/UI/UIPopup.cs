using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{
    public virtual void Awake()
    {
        Refresh();
    }

    public virtual void Refresh()
    {
    }

    public virtual void Hide()
    {
        PopExit();
    }

    public void PopExit()
    {
        UIManager.Get().RemovePopup(this); 
        Destroy(gameObject);
    }
}
